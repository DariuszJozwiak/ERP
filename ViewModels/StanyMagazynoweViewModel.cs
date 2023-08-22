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
    public class StanyMagazynoweViewModel : WszystkieViewModel<StanyMagazynoweAll>
    {
        #region Pola
      
        private StanyMagazynoweAll _WybranyStanMagazynowy;
        public StanyMagazynoweAll WybranyStanMagazynowy
        {
            get
            {
                return _WybranyStanMagazynowy;
            }

            set
            {
                if (_WybranyStanMagazynowy != value)
                {
                    _WybranyStanMagazynowy = value;
                    OnPropertyChanged(() => WybranyStanMagazynowy);
                }
            }
        }
        #endregion
        //private int _IdStanuMagazynowego;
        //public int IdStanuMagazynowego
        //{
        //    get
        //    {
        //        return _IdStanuMagazynowego;
        //    }
        //    set
        //    {
        //        if (value != _IdStanuMagazynowego)
        //        {
        //            _IdStanuMagazynowego = value;
        //        }
        //    }
        //}

        //private string _NazwaTowaru;
        //public string NazwaTowaru
        //{
        //    get
        //    {
        //        return _NazwaTowaru;
        //    }
        //    set
        //    {
        //        if (value != _NazwaTowaru)
        //        {
        //            _NazwaTowaru = value;
        //        }
        //    }
        //}

        #region Konstruktor
        public StanyMagazynoweViewModel()
        : base("Stany magazynowe")
        {
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<StanyMagazynoweAll>
                (

                  from stanyMagazynowe in FakturyEntities.StanyMagazynowe
               //  where IdStanuMagazynowego == 1
                  where stanyMagazynowe.IdStanuMagazynowego == 1
                  select new StanyMagazynoweAll
                  {
                      IdStanuMagazynowego = stanyMagazynowe.IdStanuMagazynowego,
                      NazwaTowaru = stanyMagazynowe.Towar.NazwaTowaru,
                      Kod = stanyMagazynowe.Towar.Kod,
                      IloscPrzyjeta = (int)stanyMagazynowe.IloscPrzyjeta,
                      DataPrzyjecia = stanyMagazynowe.DataPrzyjecia,
                      DataPrzydatnosciDoUzycia = stanyMagazynowe.DataPrzydatnosciDoUzycia

                  }
                );
            //}
            //List = new ObservableCollection<StanyMagazynoweAll>(from stanyMagazynowe in FakturyEntities.StanyMagazynowe
            //                                                        // where kontrahent.CzyAktywny
            //                                                    select stanyMagazynowe);

            AllList = new List<StanyMagazynoweAll>(List);
        }
        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Numer" };

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Numer" };

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "NazwaTowaru":
                        List = new ObservableCollection<StanyMagazynoweAll>(AllList.Where(item => item.NazwaTowaru.ToLower().Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<StanyMagazynoweAll>(AllList);
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
                case "NazwaTowaru":
                    List = new ObservableCollection<StanyMagazynoweAll>(SortDescending ? List.OrderByDescending(item => item.NazwaTowaru) : List.OrderBy(item => item.NazwaTowaru));
                    break;
            }
        }
        protected override void Modify()
        {
            if (_WybranyStanMagazynowy != null)
            {
                Messenger.Default.Send(_WybranyStanMagazynowy);
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz przetarg który chcesz zmodyfikować", "Error");
            }
        }

        protected override void Delete()
        {
        //    new NowyStanMagazynowyViewModel(_WybranyStanMagazynowy).UstawElementNiektywny();
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

    
