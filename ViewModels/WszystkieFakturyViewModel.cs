using Elmah.ContentSyndication;
using ERPNavi.Helpers;
using ERPNavi.Models.Entieties;
using ERPNavi.Models.EntietiesForView;
using ERPNavi.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ERPNavi.ViewModels
{
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaAll>
    {
        public Entities2 Db { get; set; }
        //public string item { get; set; }
        public int IdFaktury
        {
            get
            {
                return IdFaktury;
            }
            set
            {
                if (value != IdFaktury)
                {
                    IdFaktury = value;
                    base.OnPropertyChanged(() => IdFaktury);
                }
            }
        }
       


        private FakturaAll _WybranaFaktura;
        public FakturaAll WybranaFaktura
        {
            get
            {
                return _WybranaFaktura;
            }

            set
            {
                if (_WybranaFaktura != value)
                {
                    _WybranaFaktura = value;
                    OnPropertyChanged(() => _WybranaFaktura);
                }

            }
        }
        private ICommand _WybierzNowaFaktureCommand;
        public ICommand WybierzNowaFaktureCommand
        {
            get
            {
                if (_WybierzNowaFaktureCommand == null)
                {
                    _WybierzNowaFaktureCommand = new BaseCommand(() => WybierzNowaFakture());
                }
                return _WybierzNowaFaktureCommand;
            }
        }
       

       

        public bool? CzyAktywna
        {
            get
            {
                return CzyAktywna;
            }
            set
            {
                if (value != CzyAktywna)
                {
                    CzyAktywna = value;
                    base.OnPropertyChanged(() => CzyAktywna);
                }
            }
        }


        #region Konstruktor
        public WszystkieFakturyViewModel()
              : base("Wydania zewnętrzne WZ")
        {

           

        }

        
        #endregion
        #region Helpers
        public override void Load()
       {
            List = new ObservableCollection<FakturaAll>
                (
                  //to jest zapytanie linq (obiektowa wersja SQL)
                  from faktura in FakturyEntities.Faktura //dla kazdej faktury z bazy danych wybieramy nową fakturę ForAllView
                      where faktura.CzyAktywna == true
                  select new FakturaAll
                  {
                      IdFaktury = faktura.IdFaktury,
                      Numer = faktura.Numer,
                      DataWystawienia = faktura.DataWystawienia,

                      KontrahentNazwa = faktura.Kontrahent.Nazwa,
                      KontrahentNIP = faktura.Kontrahent.NIP,
                      KontrahentAdres =
                      faktura.Kontrahent.Adres.KodPocztowy + " " +
                      faktura.Kontrahent.Adres.Miejscowosc + ", " +
                      faktura.Kontrahent.Adres.Ulica + " " +
                      faktura.Kontrahent.Adres.NrDomu,

                      TerminPlatnosci = faktura.TerminPłatnosci,
                      SposobPlatnosciNazwa = faktura.SposobPlatnosci.Nazwa,
                  }
                );

            //List = new ObservableCollection<Faktura>(from faktura in FakturyEntities.Faktura
            //                                            where faktura.(bool)CzyAktywna
            //                                            select faktura); 

            AllList = new List<FakturaAll>(List);
        }




        //private void przypiszFaktureDoUsuniecia(Faktura faktura)
        //{
        //    //DaneKontrahenta = $"{kontrahent.Nazwa} - {kontrahent.NIP} ({kontrahent.Kod})";
        //    //item.IdKontrahenta = kontrahent.IdKontrahenta;
        //    DaneFakturyDoUsuniecia = faktura.IdFaktury;
        // //   item.IdFaktury = faktura.IdFaktury;

        //}





        protected override List<string> GetSearchComboBoxItems()  =>  new List<string>() { "Numer" };

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Numer" };

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Numer":
                        List = new ObservableCollection<FakturaAll>(AllList.Where(item => item.Numer?.ToLower().Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<FakturaAll>(AllList);
            }
                Sort();


                //case "DataWystawienia":
                //    List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.DataWystawienia?.Equals(SearchText) ?? false));
                //    break;

            }
        

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<FakturaAll>(SortDescending ? List.OrderByDescending(item => item.Numer) : List.OrderBy(item => item.Numer));
                    break;
            }
        }

        #endregion
        //private void addPozycja(MessengerMessage<WszystkieFakturyViewModel, PozycjaFaktury> obj)
        //{
        //    bool cond = obj.Nadawca == this;
        //}

        private void WybierzNowaFakture()
        {
             Messenger.Default.Send("Faktury Add"); //przenosi w metodzie do Nowa faktura
        }
        private void OdswiezFakture()
        {
            Messenger.Default.Send("Faktury Refresh");  //przenosi w metodzie do Wszystkie faktury
        }

        protected override void Modify()
        {
            if (_WybranaFaktura != null)
            {
                Messenger.Default.Send(_WybranaFaktura);
                Messenger.Default.Send("Faktury Add");
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz fakturę który chcesz zmodyfikować", "Error");
            }
        }
       
           
        //  Messenger.Default.Send("Kasuj Fakturę");  //przenosi w metodzie do Wszystkie faktury


        //public void FakturaNieaktywna()
        //{

        //    CzyAktywna = false;

        //}
        protected override void Delete()
        {
            if (_WybranaFaktura != null)
            {
               new NowaFakturaViewModel().UstawElementNiektywny();



            Refresh();
           }
        
        
            else
            {
                MessageBox.Show("Zaznacz fakturę który chcesz usunąć", "Error");
            }
            // new NowaFakturaViewModel(_WybranaFakturaDoUsuniecia).UstawElementNiektywny();
            Refresh();
        }

        //public void UstawElementNiektywny()
        //{
        //    item.CzyAktywna = false;
        //    Db.SaveChanges();
        //}
        protected override void Refresh()
        {
            SearchText = null;
            Load();
        }
      
       
    }
}