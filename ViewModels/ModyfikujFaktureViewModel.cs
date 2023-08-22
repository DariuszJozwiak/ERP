using Elmah.ContentSyndication;
using ERPNavi.Helpers;
using ERPNavi.Models.BusinessLogic;
using ERPNavi.Models.Entieties;
using ERPNavi.Models.EntietiesForView;
using ERPNavi.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERPNavi.ViewModels
{
    public class ModyfikujFaktureViewModel : JedenWszystkieViewModel<Faktura, PozycjeFakturyForAllView> //bo wszystkie zakładki dziedzicza po workspaceVM
                                                                                                                            //   public class NowaFakturaViewModel : WszystkieViewModel<FakturaAll>
    {


        #region  Fields  and  Properties 





       
        public List<SposobPlatnosci> SposobyPlatnosci { get; set; }
       public List<PozycjaFaktury> DanePozycjiFaktury { get; set; }
        //public List<ComboBoxKeyAndValue> Kontrahenci { get; set; }
        private string _DaneKontrahenta;
        public string DaneKontrahenta
        {
            get { return _DaneKontrahenta; }
            set
            {
                if (value != _DaneKontrahenta)
                {
                    _DaneKontrahenta = value;
                    OnPropertyChanged(() => DaneKontrahenta);
                }
            }
        }

        private string _DaneKontrahentaModyfikuj;
        public string DaneKontrahentaModyfikuj
        {
            get { return _DaneKontrahentaModyfikuj; }
            set
            {
                if (value != _DaneKontrahentaModyfikuj)
                {
                    _DaneKontrahentaModyfikuj = value;
                    OnPropertyChanged(() => DaneKontrahentaModyfikuj);
                }
            }
        }

        private string _DaneFaktury;
        public string DaneFaktury
        {
            get { return _DaneFaktury; }
            set
            {
                if (value != _DaneFaktury)
                {
                    _DaneFaktury = value;
                    OnPropertyChanged(() => DaneFaktury);
                }
            }
        }

       

        public string Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (value != item.Numer)
                {
                    item.Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                if (value != item.DataWystawienia)
                {
                    item.DataWystawienia = value;
                    base.OnPropertyChanged(() => DataWystawienia);
                }
            }
        }

        public int? IdKontrahenta
        {
            get
            {
                return item.IdKontrahenta;
            }
            set
            {
                if (value != item.IdKontrahenta)
                {
                    item.IdKontrahenta = value;
                    base.OnPropertyChanged(() => IdKontrahenta);
                }
            }
        }
        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPłatnosci;
            }
            set
            {
                if (value != item.TerminPłatnosci)
                {
                    item.TerminPłatnosci = value;
                    base.OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }
        public int? IdSposobuPlatnosci
        {
            get
            {
                return item.IdSposobuPlatnosci;
            }
            set
            {
                if (value != item.IdSposobuPlatnosci)
                {
                    item.IdSposobuPlatnosci = value;
                    base.OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }
        public bool? CzyZatwierdzona
        {
            get
            {
                return item.CzyZatwierdzono;
            }
            set
            {
                if (value != item.CzyZatwierdzono)
                {
                    item.CzyZatwierdzono = value;
                    base.OnPropertyChanged(() => CzyZatwierdzona);
                }
            }
        }
        public bool? CzyAktywna
        {
            get
            {
                return item.CzyAktywna;
            }
            set
            {
                if (value != item.CzyAktywna)
                {
                    item.CzyAktywna = value;
                    base.OnPropertyChanged(() => CzyAktywna);
                }
            }
        }
        #endregion

        #region Komendy

        // To wywołuje przycisk wybierz kontrahenta w NowaFakturaView
        //private ICommand _WybierzKontrahentaModyfikuj;
        //public ICommand WybierzKontrahentaModyfikuj
        //{
        //    get
        //    {
        //        if (_WybierzKontrahentaModyfikuj == null)
        //        {
        //            _WybierzKontrahentaModyfikuj = new BaseCommand(() => WybierzKontrahentaModyfikuj());
        //        }
        //        return _WybierzKontrahentaModyfikuj;
        //    }
        //}


        private ICommand _WybierzFaktureCommand;
        public ICommand WybierzFaktureCommand
        {
            get
            {
                if (_WybierzFaktureCommand == null)
                {
                    _WybierzFaktureCommand = new BaseCommand(() => WybierzFakture());
                 //   _WybierzFaktureCommand = new BaseCommand(() => WybierzKontrahenta());

                }
                return _WybierzFaktureCommand;
            }
        }

        #endregion

        #region Konstruktor
        public ModyfikujFaktureViewModel()
            : base("Faktura", "Pozycja faktury")
        {
            item = new Faktura()
            {
                CzyAktywna = true,
                CzyZatwierdzono = true
               
            };

         
            // Zapytanie LINQ
            SposobyPlatnosci = (from sposobPlatnosci in Db.SposobPlatnosci
                                where sposobPlatnosci.CzyAktywny == true    //każdy warunek jest tłumaczony na boola; tutaj musi byc ==true bo jest bool?
                                select sposobPlatnosci).ToList();

            DanePozycjiFaktury = (from danePozycjiFaktury in Db.PozycjaFaktury
                                  where danePozycjiFaktury.Faktura.IdFaktury == 77

                                  select danePozycjiFaktury).ToList();





            //   Towar towar = Db.Towar.First(item => item.IdTowaru == pozycjaFaktury.IdTowaru);
            // Czytanie z BD - czysty C#
            //Kontrahenci = Db.Kontrahent.Where(arg => arg.CzyAktywny == true).Select(arg => new ComboBoxKeyAndValue()
            //{
            //    Key = arg.IdKontrahenta,
            //    Value = arg.Nazwa + "  " + arg.NIP + " (" + arg.Kod + ")"
            //}).ToList();
            Messenger.Default.Register<Kontrahent>(this, przypiszKontrahenta);
          // Messenger.Default.Register<Kontrahent>(this, przypiszKontrahentaModyfikuj);
            Messenger.Default.Register<Faktura>(this, przypiszFakture);
            Messenger.Default.Register<PozycjaFaktury>(this, przypiszPozycjeFaktury);
          //  Messenger.Default.Register<PozycjaFaktury>(this, addPozycjaFaktury);
           // Messenger.Default.Register<MessengerMessage<ModyfikujFaktureViewModel, PozycjaFaktury>>(this, addPozycja);
           


            //   WartoscNetto = 0;

        }
        #endregion konstruktor




        //private void addPozycja(MessengerMessage<ModyfikujFaktureViewModel, PozycjaFaktury> obj)
        //{
        //    bool cond = obj.Nadawca == this;
        //}




        #region Metody
        private void przypiszKontrahenta(Kontrahent kontrahent)
        {
            //DaneKontrahenta = $"{kontrahent.Nazwa} - {kontrahent.NIP} ({kontrahent.Kod})";
            //item.IdKontrahenta = kontrahent.IdKontrahenta;
            DaneKontrahenta = $"{kontrahent.Nazwa}      NIP {kontrahent.NIP}";
            item.IdKontrahenta = kontrahent.IdKontrahenta;
        }

        private void przypiszKontrahentaModyfikuj(Kontrahent kontrahent)
        {
            //DaneKontrahenta = $"{kontrahent.Nazwa} - {kontrahent.NIP} ({kontrahent.Kod})";
            //item.IdKontrahenta = kontrahent.IdKontrahenta;
            DaneKontrahentaModyfikuj = "Aquila Hotel";
            item.IdKontrahenta = kontrahent.IdKontrahenta;
          //  Messenger.Default.Send("Dane Kontrahenta Modyfikuj");
            //DaneKontrahentaModyfikuj = (from daneKontrahentaModyfikuj in Db.PozycjaFaktury
            //                            where daneKontrahentaModyfikuj.Faktura.Kontrahent.Nazwa == "Aquila Hotel"
            //                            select daneKontrahentaModyfikuj).ToList();



        }
        private void KontrahentaModyfikuj(Kontrahent kontrahent)
        { }
           
        private void przypiszFakture(Faktura faktura)
        {
            //DaneKontrahenta = $"{kontrahent.Nazwa} - {kontrahent.NIP} ({kontrahent.Kod})";
            //item.IdKontrahenta = kontrahent.IdKontrahenta;
            DaneFaktury = $"{faktura.Numer}     IdFaktury: {faktura.IdFaktury}";
            item.IdFaktury = faktura.IdFaktury;

        }
        










        private void przypiszPozycjeFaktury(PozycjaFaktury pozycjaFaktury)
        {

            //DanePozycjiFaktury = (from danePozycjiFaktury in Db.PozycjaFaktury
            //                   //   where daneFaktury.CzyAktywny == true    //każdy warunek jest tłumaczony na boola; tutaj musi byc ==true bo jest bool?
            //                   select danePozycjiFaktury).ToList();


            //    //DaneKontrahenta = $"{kontrahent.Nazwa} - {kontrahent.NIP} ({kontrahent.Kod})";
            //    //item.IdKontrahenta = kontrahent.IdKontrahenta;



            //   DanePozycjiFaktury = $"{pozycjaFaktury.Towar.NazwaTowaru} where IdFaktury == 1 ";
            //    item.IdFaktury = pozycjaFaktury.IdFaktury;
        }







        private void WybierzKontrahenta()
        {
           // Messenger.Default.Send("Kontrahenci Show");


        }

        //private void WybierzKontrahentaModyfikuj()
        //{
        //    Messenger.Default.Send("Wybierz kontrahenta modyfikuj");
        //}
        private void WybierzFakture()
        {
            Messenger.Default.Send("Faktury Show");  //przenosi w metodzie do Wszystkie faktury
        }

        private Faktura GetItem()
        {
            return item;
        }

        public override void Save()
        {
            //  Messenger.Default.Send(item);
         //   Db.Faktura.AddObject(item);
            Db.SaveChanges();
        }

        //private void addPozycjaFaktury(PozycjaFaktury pozycjaFaktury)
        //{
        //    // Czy to jest dobrze?
        //    item.PozycjaFaktury.Add(new PozycjaFaktury()
        //    {
        //        IdTowaru = pozycjaFaktury.IdTowaru,
        //        Ilosc = pozycjaFaktury.Ilosc,
        //        CenaNetto = pozycjaFaktury.CenaNetto,
        //        Rabat = pozycjaFaktury.Rabat
        //    });

        //    //Towar towar = (from item in Db.Towar
        //    //               where item.IdTowaru == pozycjaFaktury.IdTowaru
        //    //               select item).First();

        //    Towar towar = Db.Towar.First(item => item.IdTowaru == pozycjaFaktury.IdTowaru);


        //    List.Add(new PozycjeFakturyForAllView()
        //    {
        //        CenaNetto = pozycjaFaktury.CenaNetto,
        //        Ilosc = pozycjaFaktury.Ilosc,
        //        Rabat = pozycjaFaktury.Rabat,
        //        Kod = towar.Kod,
        //        NazwaTowaru = towar.NazwaTowaru

        //    });
        //}


        public override void Load() { }

        //public override  void Load()
        //{
        //    List = new ObservableCollection<PozycjeFakturyForAllView>
        //        (
        //          //to jest zapytanie linq (obiektowa wersja SQL)
        //          from dane in Db.Faktura //dla kazdej faktury z bazy danych wybieramy nową fakturę ForAllView
        //          where dane.IdFaktury == 77                                              //    where kontrahent.CzyAktywny == true
        //                                         //   where dane.IdFaktury == 77
        //          select new PozycjeFakturyForAllView
        //          {
        //              IdFaktury = dane.IdFaktury,
        //              Kod = dane.Kontrahent.Kod

                    
                     

        //              //AdresKontrahenta =
        //              //kontrahent.Adres.KodPocztowy + " " +
        //              //kontrahent.Adres.Miejscowosc + ", " +
        //              //kontrahent.Adres.Ulica + " " +
        //              //kontrahent.Adres.NrDomu,


        //          }
        //        );
        //}


            //    List = new ObservableCollection<Faktura>(from Faktura in Db.Faktura
            //                                                 // where kontrahent.CzyAktywny
            //                                             select Faktura

            //    {
            //        NazwaTowaru = pozycjeFaktury.Towar.NazwaTowaru,
            //    IloscTowaru = (double)pozycjeFaktury.Ilosc,
            //    CenaNetto = (double)pozycjeFaktury.CenaNetto,
            //    RabatNaTowar = (double)pozycjeFaktury.Rabat,
            //    VAT_procent = (double)pozycjeFaktury.Towar.StawkaVatSprzedazy,
            //    WartoscNetto = (double)(pozycjeFaktury.Ilosc * pozycjeFaktury.CenaNetto),
            //    VAT_wyliczony = ((double)((pozycjeFaktury.CenaNetto * pozycjeFaktury.Towar.StawkaVatSprzedazy) / 100)),
            //    CenaBrutto = (double)(pozycjeFaktury.CenaNetto + ((pozycjeFaktury.CenaNetto * pozycjeFaktury.Towar.StawkaVatSprzedazy) / 100) - pozycjeFaktury.Rabat)
            //    }

            //}


            #endregion
        //    #region  Command
        //private BaseCommand _ObliczWartoscNettoCommand;
        //private string PrzypiszPozycjeFaktury;

        //public ICommand ObliczWartoscNettoCommand
        //{
        //    get
        //    {
        //        if (_ObliczWartoscNettoCommand == null)
        //        {

        //            _ObliczWartoscNettoCommand = new BaseCommand(() => obliczWartoscNettoClick());
        //        }
        //        return _ObliczWartoscNettoCommand;
        //    }
        //}

        public double WartoscNetto { get; set; }
       
        #region  Private  Helpers

       
    }

    #endregion  //Private  Helpers
}
