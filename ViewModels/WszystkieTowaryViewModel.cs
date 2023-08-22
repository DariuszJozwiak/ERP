using ERPNavi.Models.Entieties;
using ERPNavi.Models.EntietiesForView;
using ERPNavi.ViewModels.Abstract;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ERPNavi.ViewModels
{
    public class WszystkieTowaryViewModel : WszystkieViewModel<TowaryAll>
    {
        #region Pola
       
        private TowaryAll _WybranyTowar;
        public TowaryAll WybranyTowar
        {
            get
            {
                return _WybranyTowar;
            }

            set
            {
                if (_WybranyTowar != value)
                {
                    _WybranyTowar = value;
                    OnPropertyChanged(() => WybranyTowar);
                }
            }
        }
        #endregion


        #region Konstruktor
        public WszystkieTowaryViewModel()
        : base("Towary i usługi")
        {
}

#endregion
#region Helpers
public override void Load()
{
    List = new ObservableCollection<TowaryAll>
        (
          from towary in FakturyEntities.Towar
          where towary.CzyAktywny == true
          select new TowaryAll
          {
              IdTowaru = towary.IdTowaru,
              Kod = towary.Kod,
              NazwaTowaru = towary.NazwaTowaru,
              StawkaVatSprzedazy = (double)towary.StawkaVatSprzedazy,
              CenaNetto = towary.CenaNetto,
              Marza = towary.Marza,
              Status = towary.Status.Nazwa
          }

        );
            AllList = new List<TowaryAll>(List);
        }

        protected override List<string> GetSearchComboBoxItems()
         => new List<string>() { "Kod" };

        protected override List<string> GetSortComboBoxItems() => new List<string>() { "Kod" };

        protected override void Search()
        {
            if (!string.IsNullOrEmpty(SearchText) && !string.IsNullOrEmpty(SearchField))
            {
                switch (SearchField)
                {
                    case "Kod":
                        List = new ObservableCollection<TowaryAll>(AllList.Where(item => item.Kod?.ToLower().Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<TowaryAll>(AllList);
            }
            Sort();

        }

        protected override void Sort()
        {

            switch (SortField)
            {
                case "Kod":
                    List = new ObservableCollection<TowaryAll>(SortDescending ? List.OrderByDescending(item => item.Kod) : List.OrderBy(item => item.Kod));
                    break;
            }
        }
        protected override void Modify()
        {
            if (_WybranyTowar != null)
            {
                Messenger.Default.Send(_WybranyTowar);
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz towar który chcesz zmodyfikować", "Error");
            }
        }
        protected override void Delete()
        {
        //    new NowyTowarViewModel(_WybranyTowar).UstawElementNiektywny();
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