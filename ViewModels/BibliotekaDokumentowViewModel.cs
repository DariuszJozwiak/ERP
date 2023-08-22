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
    public class BibliotekaDokumentowViewModel : WszystkieViewModel<BibliotekaDokumentow>
    {
        #region Pola
        private BibliotekaDokumentow _WybranaPozycja;
        public BibliotekaDokumentow WybranaPozycja
        {
            get
            {
                return _WybranaPozycja;
            }

            set
            {
                if (_WybranaPozycja != value)
                {
                    _WybranaPozycja = value;
                    OnPropertyChanged(() => WybranaPozycja);
                }
            }
        }
        #endregion
        #region Konstruktor
        public BibliotekaDokumentowViewModel()
             : base("Bibioteka Dokumentow")
        {

        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<BibliotekaDokumentow>
                (
                  //to jest zapytanie linq (obiektowa wersja SQL)
                  from BibliotekaDokumentow in FakturyEntities.BibliotekaDokumentow //dla kazdego...
                                                               //    where Towar.CzyAktywny == true
                  select BibliotekaDokumentow //wy...
                );
            AllList = new List<BibliotekaDokumentow>(List);
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
                        List = new ObservableCollection<BibliotekaDokumentow>(AllList.Where(item => item.Numer?.ToLower().Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<BibliotekaDokumentow>(AllList);
            }
            Sort();

        }


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<BibliotekaDokumentow>(SortDescending ? List.OrderByDescending(item => item.Numer) : List.OrderBy(item => item.Numer));
                    break;
            }
        }
        protected override void Delete()
        {
          //  new NowyDokumentBibiotekiViewModel(_WybranaPozycja).UstawElementNiektywny();
            Refresh();
        }
        protected override void Refresh()
        {
            SearchText = null;
            Load();
        }
        protected override void Modify()
        {
            if (_WybranaPozycja != null)
            {
                Messenger.Default.Send(_WybranaPozycja);
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz który chcesz zmodyfikować", "Error");
            }
        }
        #endregion
    }
}
