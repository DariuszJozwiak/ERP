using ERPNavi.Models.Entieties;
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
    public class PrzetargiViewModel : WszystkieViewModel<Przetargi>
    {
        #region Pola
      
        private Przetargi _WybranyPrzetarg;
        public Przetargi WybranyLekarz
        {
            get
            {
                return _WybranyPrzetarg;
            }

            set
            {
                if (_WybranyPrzetarg != value)
                {
                    _WybranyPrzetarg = value;
                    OnPropertyChanged(() => WybranyLekarz);
                }
            }
        }


        #endregion
        #region Konstruktor
        public PrzetargiViewModel()
             : base("Przetargi")
        {
           
        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<Przetargi>
                (
                  //to jest zapytanie linq (obiektowa wersja SQL)
                  from Przetargi in FakturyEntities.Przetargi //dla kazdego...
              //    where Towar.CzyAktywny == true
                  select Przetargi //wy...
                );
            AllList = new List<Przetargi>(List);
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Numer" };

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Numer" };

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Numer":
                        List = new ObservableCollection<Przetargi>(AllList.Where(item => item.NrPrzetargu?.ToLower().Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<Przetargi>(AllList);
            }
            Sort();


        }


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<Przetargi>(SortDescending ? List.OrderByDescending(item => item.NrPrzetargu) : List.OrderBy(item => item.NrPrzetargu));
                    break;
            }
        }
        protected override void Modify()
        {
            if (_WybranyPrzetarg != null)
            {
                Messenger.Default.Send(_WybranyPrzetarg);
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz który chcesz zmodyfikować", "Error");
            }
        }

        protected override void Delete()
        {
            //new NowyPrzetargViewModel(_WybranyPrzetarg).UstawElementNiektywny();
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
