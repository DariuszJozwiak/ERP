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

namespace ERPNavi.ViewModels
{
    public class KontrahenciViewModel : WszystkieViewModel<KontrahenciForAllView>
    {
        #region PolaIWlasciwosci
        //public int IdKontrahenta { get; set; }
        //public string Kod { get; set; }
        //public string KontrahentNazwa { get; set; }
        //public string KontrahentNIP { get; set; }
        //public string KontrahentAdres { get; set; }wwwww
        //public string NIP { get; set; }
        //public string Nazwa { get; set; }
        //public string AdresKontrahenta { get; set; }
       


        private KontrahenciForAllView _WybranyKontrahent;
        public KontrahenciForAllView WybranyKontrahent
        {
            get
            {
                return _WybranyKontrahent;
            }
            set
            {
                if (_WybranyKontrahent != value)
                {
                    _WybranyKontrahent = value;
                    OnPropertyChanged(() => WybranyKontrahent);
                    //TODO
                    //ShowMessageBoxInformation
                    Messenger.Default.Send(_WybranyKontrahent);
                    OnRequestClose();
                }
            }
        }

        #endregion

        #region Konstruktor
        public KontrahenciViewModel() : base("Kontrahenci") { }

        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KontrahenciForAllView>
                (
                  //to jest zapytanie linq (obiektowa wersja SQL)
                  from kontrahent in FakturyEntities.Kontrahent //
                                                                //    where kontrahent.CzyAktywny == true
                  select new KontrahenciForAllView
                  {
                      IdKontrahenta = kontrahent.IdKontrahenta,
                      Kod = kontrahent.Kod,
                      NIP = kontrahent.NIP,

                      Nazwa = kontrahent.Nazwa,

                      AdresKontrahenta =
                      kontrahent.Adres.KodPocztowy + " " +
                      kontrahent.Adres.Miejscowosc + ", " +
                      kontrahent.Adres.Ulica + " " +
                      kontrahent.Adres.NrDomu,


                  }
                );


            //List = new ObservableCollection<Kontrahent>(from kontrahent in FakturyEntities.Kontrahent
            //                                                // where kontrahent.CzyAktywny
            //                                            select kontrahent);
            AllListKontrahenci = new List<KontrahenciForAllView>(List);
        }



        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Kod " };

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Kod" };

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Kod":
                        List = new ObservableCollection<KontrahenciForAllView>(AllListKontrahenci.Where(item => item.Kod.Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<KontrahenciForAllView>(AllListKontrahenci);
            }
            Sort();
        }


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<KontrahenciForAllView>(SortDescending ? List.OrderByDescending(item => item.DataPrzystapienia) : List.OrderBy(item => item.DataPrzystapienia));
                    break;
            }
        }
        protected override void Modify()
        {
            if (_WybranyKontrahent != null)
            {
                Messenger.Default.Send(_WybranyKontrahent);
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz który chcesz zmodyfikować", "Error");
            }
        }
        protected override void Delete()
        {
         //     new NowyKontrahent(_WybranyKontrahent).UstawElementNiektywny();
            Refresh();
        }
        protected override void Refresh()
        {
            SearchText = null;
            Load();
        }

        #endregion

    }
}