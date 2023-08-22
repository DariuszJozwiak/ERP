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
    public class ZamowieniaWMSViewModel : WszystkieViewModel<ZamowieniaWMSAll>
    {
        #region Pola
       
        private ZamowieniaWMSAll _WybraneZamowieniaWMS;
        public ZamowieniaWMSAll WybraneZamowieniaWMS
        {
            get
            {
                return _WybraneZamowieniaWMS;
            }

            set
            {
                if (_WybraneZamowieniaWMS != value)
                {
                    _WybraneZamowieniaWMS = value;
                    OnPropertyChanged(() => WybraneZamowieniaWMS);
                }
            }
        }
        #endregion
        #region Konstruktor
        public ZamowieniaWMSViewModel()
             : base("Zamówienia WMS")
        {

        }
        #endregion
        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<ZamowieniaWMSAll>
                (

                  from zamowieniaWMS in FakturyEntities.ZamowieniaWMS
                  where zamowieniaWMS.CzyAktywny == true
                  select new ZamowieniaWMSAll
                  {
                      IdZamowieniaWMS = zamowieniaWMS.IdZamowieniaWMS,
                      Data_Utworzenia_zlecenia = zamowieniaWMS.Data_utworzenia_zlecenia,
                      NazwaKontrahenta = zamowieniaWMS.ZamowieniaOdKlientow.Kontrahent.Nazwa,
                      IdZamowieniaOdKlientow = zamowieniaWMS.ZamowieniaOdKlientow.IdZamowieniaOdKlientow,
                      IloscZamowionaERP = (int)zamowieniaWMS.ZamowieniaOdKlientow.IloscZamowiona,
                      IloscWydanaWMS = (int)zamowieniaWMS.IloscWydana,
                      NazwaTowaru = zamowieniaWMS.ZamowieniaOdKlientow.Towar.NazwaTowaru

                  }
                );
        }

        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "Numer" };

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Numer" };

        protected override void Search()
        {
            switch (SearchField)
            {
                case "Numer":
                    List = new ObservableCollection<ZamowieniaWMSAll>(List.Where(item => item.Numer?.Contains(SearchText) ?? false));
                    break;
            }

        }

        protected override void Sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<ZamowieniaWMSAll>(SortDescending ? List.OrderByDescending(item => item.Numer) : List.OrderBy(item => item.Numer));
                    break;
            }
        }

        protected override void Modify()
        {
            if (_WybraneZamowieniaWMS != null)
            {
                Messenger.Default.Send(_WybraneZamowieniaWMS);
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz przetarg który chcesz zmodyfikować", "Error");
            }
        }

        protected override void Delete()
        {
           //    new NoweZamowienieWMSViewModel(_WybraneZamowieniaWMS).UstawElementNiektywny();
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