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
    public class StratyMagazynoweViewModel : WszystkieViewModel<StratyAll>
    {
        #region Pola
       
        private StratyAll _WybranaStrata;
        public StratyAll WybranaStrata
        {
            get
            {
                return _WybranaStrata;
            }

            set
            {
                if (_WybranaStrata != value)
                {
                    _WybranaStrata = value;
                    OnPropertyChanged(() => WybranaStrata);
                }
            }
        }
        #endregion
        #region Konstruktor
        public StratyMagazynoweViewModel()
        : base("Straty magazynowe")
        {
        }  
        
         #endregion
             #region Helpers
             public override void Load()
        {
            List = new ObservableCollection<StratyAll>
                (
                  //to jest zapytanie linq (obiektowa wersja SQL)
                  from straty in FakturyEntities.StratyMagazynoweIZwroty 

                  select new StratyAll
                  {
                     IdStratMagazynowych = straty.IdStratMagazynowychIZwrotow,
                    NazwaTowaruStraty =straty.Towar.NazwaTowaru,
                     DataZgloszenia = straty.DataZgloszenia,
                     OpisStraty = straty.Opis
                  }
                );
            AllList = new List<StratyAll>(List);
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
                        List = new ObservableCollection<StratyAll>(AllList.Where(item => item.Numer?.ToLower().Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<StratyAll>(AllList);
            }
            Sort();
        }


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<StratyAll>(SortDescending ? List.OrderByDescending(item => item.Numer) : List.OrderBy(item => item.Numer));
                    break;
            }
        }
        protected override void Modify()
        {
            if (_WybranaStrata != null)
            {
                Messenger.Default.Send(_WybranaStrata);
               
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz przetarg który chcesz zmodyfikować", "Error");
            }
        }

        protected override void Delete()
        {
            // new NowaStrataMagazynowaViewModel(_WybranaStrata).UstawElementNiektywny();
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
