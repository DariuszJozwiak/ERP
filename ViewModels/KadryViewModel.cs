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
    public class KadryViewModel  : WszystkieViewModel<KadryAll>
    {
        #region
        private KadryAll _WybranyPracownikKadr;
        public KadryAll WybranyPracownikKadr
        {
            get
            {
                return _WybranyPracownikKadr;
            }

            set
            {
                if (_WybranyPracownikKadr != value)
                {
                    _WybranyPracownikKadr = value;
                    OnPropertyChanged(() => WybranyPracownikKadr);
                }
            }
        }
        #endregion

        #region Konstruktor
        public KadryViewModel()
        : base("Kadry")
        {
        }
            #endregion
             #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KadryAll>
                (
                  //to jest zapytanie linq (obiektowa wersja SQL)
                  from kadry in FakturyEntities.Kadry //dla kazdej faktury z bazy danych wybieramy nową fakturę ForAllView
              //    where kadry.CzyAktywny == true
                  select new KadryAll
                  {
                      IdPracownika = kadry.IdPracownika,
                      ImiePracownika = kadry.ImiePracownika,
                      NazwiskoPracownika = kadry.NazwiskoPracownika,

                      DataZatrudnieniaPracownika = (DateTime)kadry.DataZatrudnieniaPracownika,

                      AdresPracownika =
                      kadry.KodPocztowyPracownika + " " +
                      kadry.MiastoZamieszkaniaPracownika + ", " +
                      kadry.UlicaPracownika + " " +
                      kadry.NrDomu_mieszkaniaPracownika,

                  }
                );
            AllList = new List<KadryAll>(List);
        }
        protected override List<string> GetSearchComboBoxItems() => new List<string>() { "NazwiskoPracownika" };

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "NazwiskoPracownika" };

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "NazwiskoPracownika":
                        List = new ObservableCollection<KadryAll>(AllList.Where(item => item.NazwiskoPracownika?.ToLower().Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<KadryAll>(AllList);
            }
            Sort();

        }


        protected override void Sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<KadryAll>(SortDescending ? List.OrderByDescending(item => item.NazwiskoPracownika) : List.OrderBy(item => item.NazwiskoPracownika));
                    break;
            }
        }
        protected override void Modify()
        {
            if (_WybranyPracownikKadr != null)
            {
                Messenger.Default.Send(_WybranyPracownikKadr);
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz zaznacz pracownika którego chcesz zmodyfikować", "Error");
            }
        }

        protected override void Delete()
        {
           // new KadryViewModel(_WybranyPracownikKadr).UstawElementNiektywny();
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
    

