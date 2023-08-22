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
    public class NowaFakturaViewModel: JedenWszystkieViewModel<Faktura , PozycjeFakturyForAllView>//bo wszystkie zakładki dziedzicza po workspaceVM
                                                                                                  //   public class NowaFakturaViewModel : WszystkieViewModel<FakturaAll>
    {

        #region  Fields  and  Properties 

        public List<SposobPlatnosci> SposobyPlatnosci { get; set; }
      //  public List<PozycjeFakturyForAllView> DanePozycjiFaktury { get; set; }
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
        public bool? CzyZatwierdzono
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
                    base.OnPropertyChanged(() => CzyZatwierdzono);
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
        private ICommand _WybierzKontrahentaCommand;   
        public ICommand WybierzKontrahentaCommand
        {
            get
            {
                if (_WybierzKontrahentaCommand == null)
                {
                    _WybierzKontrahentaCommand = new BaseCommand(() => WybierzKontrahenta());
                }
                return _WybierzKontrahentaCommand;
            }
        }


        private ICommand _WybierzFaktureCommand;
        public ICommand WybierzFaktureCommand
        {
            get
            {
                if (_WybierzFaktureCommand == null)
                {
                    _WybierzFaktureCommand = new BaseCommand(() => WybierzFakture());
                }
                return _WybierzFaktureCommand;
            }
        }

      

        #endregion

        #region Konstruktor
        public NowaFakturaViewModel()
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

            //DanePozycjiFaktury = (from danePozycjiFaktury in Db.PozycjaFaktury
            //                      where danePozycjiFaktury.CzyAktywny == true 
            //                      select danePozycjiFaktury).ToList();



         //   Towar towar = Db.Towar.First(item => item.IdTowaru == pozycjaFaktury.IdTowaru);
            // Czytanie z BD - czysty C#
            //Kontrahenci = Db.Kontrahent.Where(arg => arg.CzyAktywny == true).Select(arg => new ComboBoxKeyAndValue()
            //{
            //    Key = arg.IdKontrahenta,
            //    Value = arg.Nazwa + "  " + arg.NIP + " (" + arg.Kod + ")"
            //}).ToList();
            Messenger.Default.Register<KontrahenciForAllView>(this, przypiszKontrahenta);
          
            Messenger.Default.Register<FakturaAll>(this, przypiszFakture);
            Messenger.Default.Register<PozycjaFaktury>(this, przypiszPozycjeFaktury);
            Messenger.Default.Register<PozycjaFaktury>(this, addPozycjaFaktury);
            Messenger.Default.Register<MessengerMessage<NowaFakturaViewModel, PozycjaFaktury>>(this, addPozycja);
            List = new ObservableCollection<PozycjeFakturyForAllView>(item.PozycjaFaktury.Select(item => new PozycjeFakturyForAllView()
            {
                CenaNetto = item.CenaNetto,
                Ilosc = item.Ilosc,
                Rabat = item.Rabat,
                Kod = item.Towar.Kod,
                NazwaTowaru = item.Towar.NazwaTowaru

            }).ToList());


       //   WartoscNetto = 0;

        }
        #endregion konstruktor
        //public NowaFakturaViewModel(Faktura _WybranaFaktura) : base("Faktura , PozycjeFakturyForAllView")
        //{
        //    WybranaFaktura = _WybranaFaktura;
        //}


            private void addPozycja(MessengerMessage<NowaFakturaViewModel, PozycjaFaktury> obj)
        {
            bool cond = obj.Nadawca == this;
        }
       

       

        #region Metody
        private void przypiszKontrahenta(KontrahenciForAllView kontrahent)
        {
            //DaneKontrahenta = $"{kontrahent.Nazwa} - {kontrahent.NIP} ({kontrahent.Kod})";
            //item.IdKontrahenta = kontrahent.IdKontrahenta;
            DaneKontrahenta = $"{kontrahent.Nazwa}      NIP {kontrahent.NIP}";
            item.IdKontrahenta = kontrahent.IdKontrahenta;
        }

        private void przypiszFakture(FakturaAll faktura)
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
            Messenger.Default.Send("Kontrahenci Show");
        }
        private void WybierzFakture()
        {
            Messenger.Default.Send("Faktury Show");  //przenosi w metodzie do Wszystkie faktury
        }

        private void WybierzFaktureB()
        {
            Messenger.Default.Send("Wybierz Nową Fakture");  //przenosi w metodzie do Wszystkie faktury
        }

        private Faktura GetItem()
        {
            return item;
        }

        public override void Save()
        {
         //  Messenger.Default.Send(item);
            Db.Faktura.AddObject(item);
            Db.SaveChanges();
        }
       

        private void addPozycjaFaktury(PozycjaFaktury pozycjaFaktury)
        {
            // Czy to jest dobrze?
            item.PozycjaFaktury.Add(new PozycjaFaktury()
            {
           IdTowaru = pozycjaFaktury.IdTowaru,
                Ilosc = pozycjaFaktury.Ilosc,
                CenaNetto = pozycjaFaktury.CenaNetto,
              Rabat = pozycjaFaktury.Rabat
            });

            //Towar towar = (from item in Db.Towar
            //               where item.IdTowaru == pozycjaFaktury.IdTowaru
            //               select item).First();

            Towar towar = Db.Towar.First(item => item.IdTowaru == pozycjaFaktury.IdTowaru);


            List.Add(new PozycjeFakturyForAllView()
            {
                CenaNetto = pozycjaFaktury.CenaNetto,
                Ilosc = pozycjaFaktury.Ilosc,
                Rabat = pozycjaFaktury.Rabat,
                Kod = towar.Kod,
                NazwaTowaru = towar.NazwaTowaru

            });
        }


        //public override void Load()
        //{


        //         List = new ObservableCollection<Faktura>(from Faktura in FakturyEntities.Faktura
        //                                                         // where kontrahent.CzyAktywny
        //                                                     select Faktura);
        //}
        //          //{
        //          //    NazwaTowaru = pozycjeFaktury.Towar.NazwaTowaru,
        //          //    IloscTowaru = (double)pozycjeFaktury.Ilosc,
        //          //    CenaNetto = (double)pozycjeFaktury.CenaNetto,
        //          //    RabatNaTowar = (double)pozycjeFaktury.Rabat,
        //          //    VAT_procent = (double)pozycjeFaktury.Towar.StawkaVatSprzedazy,
        //          //    WartoscNetto = (double)(pozycjeFaktury.Ilosc * pozycjeFaktury.CenaNetto),
        //          //    VAT_wyliczony = ((double)((pozycjeFaktury.CenaNetto * pozycjeFaktury.Towar.StawkaVatSprzedazy) / 100)),
        //          //    CenaBrutto = (double)(pozycjeFaktury.CenaNetto + ((pozycjeFaktury.CenaNetto * pozycjeFaktury.Towar.StawkaVatSprzedazy) / 100) - pozycjeFaktury.Rabat)
        //          //}




        #endregion
        #region  Command
        private BaseCommand _ObliczWartoscNettoCommand;
      //  private string PrzypiszPozycjeFaktury;

        public ICommand ObliczWartoscNettoCommand
        {
            get
            {
                if (_ObliczWartoscNettoCommand == null)
                {

                    _ObliczWartoscNettoCommand = new BaseCommand(() => obliczWartoscNettoClick());
                }
                return _ObliczWartoscNettoCommand;
            }
        }

    public double WartoscNetto { get; set; }
        #endregion  //Command 
        #region  Private  Helpers

        private void obliczWartoscNettoClick()
        {
          //  WartoscNetto = new WartoscNettoNFaktura(FakturyEntities).WartoscNettoNF((decimal)Ilosc, (decimal)CenaNetto, (decimal)Rabat);

            //   Math.Round(WartoscNetto, 2);
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public void UstawElementNiektywny()
        {
            item.CzyAktywna = false;
            Db.SaveChanges();
        }

        //public override void Close()
        //{
        //    base.OnRequestClose();
        //}

        //public override void Load()
        //{
        //    throw new NotImplementedException();
        //}
    }

        #endregion  //Private  Helpers
    }
