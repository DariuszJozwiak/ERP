using ERPNavi.Models.EntietiesForView;
using ERPNavi.ViewModels;
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
    public class ZamowieniaOdKlientowViewModel :  WszystkieViewModel<ZamowieniaOdKlientowAll>
    {
        #region Pola
      
        private ZamowieniaOdKlientowAll _WybraneZamowienieOdKlienta;
        public ZamowieniaOdKlientowAll WybraneZamowienieOdKlienta
        {
            get
            {
                return _WybraneZamowienieOdKlienta;
            }

            set
            {
                if (_WybraneZamowienieOdKlienta != value)
                {
                    _WybraneZamowienieOdKlienta = value;
                    OnPropertyChanged(() => WybraneZamowienieOdKlienta);
                }
            }
        }
        #endregion
        #region Konstruktor
        public ZamowieniaOdKlientowViewModel()
             : base("Zamówienia od klientów")
        {
           
        }       
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZamowieniaOdKlientowAll>
                (
                
                  from zamowieniaOdKlientow in FakturyEntities.ZamowieniaOdKlientow 
                 where zamowieniaOdKlientow.CzyAktywny == true
                  select new ZamowieniaOdKlientowAll
                  {
                      NazwaKontrahenta = zamowieniaOdKlientow.Kontrahent.Nazwa,
                      IdZamowienia = zamowieniaOdKlientow.IdZamowieniaOdKlientow,
                     NazwaTowaru = zamowieniaOdKlientow.Towar.NazwaTowaru,
                      IloscZamowiona = (int)zamowieniaOdKlientow.IloscZamowiona,
                      Opis = zamowieniaOdKlientow.Opis,
                      Data_Utworzenia_zlecenia = zamowieniaOdKlientow.Data_utworzenia_zlecenia

                  }
                );
            AllList = new List<ZamowieniaOdKlientowAll>(List);
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
                        List = new ObservableCollection<ZamowieniaOdKlientowAll>(AllList.Where(item => item.Numer?.ToLower().Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<ZamowieniaOdKlientowAll>(AllList);
            }
            Sort();

        }


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<ZamowieniaOdKlientowAll>(SortDescending ? List.OrderByDescending(item => item.Numer) : List.OrderBy(item => item.Numer));
                    break;
            }
        }

        protected override void Modify()
        {
            if (_WybraneZamowienieOdKlienta != null)
            {
                Messenger.Default.Send(_WybraneZamowienieOdKlienta);
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz zamowienie które chcesz zmodyfikować", "Error");
            }
        }

        protected override void Delete()
        {
          //  new NoweZamowienieOdKlienta(_WybraneZamowienieOdKlienta).UstawElementNiektywny();
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

