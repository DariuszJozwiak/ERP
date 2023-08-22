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
using System.Windows.Documents;

namespace ERPNavi.ViewModels
{
    public class KorektaFakturyViewModel : WszystkieViewModel<KorektaFakturyAll>
    {
        #region Pola
      
        private KorektaFakturyAll _WybranaKorektaFaktury;
        public KorektaFakturyAll WybranaKorektaFaktury
        {
            get
            {
                return _WybranaKorektaFaktury;
            }

            set
            {
                if (_WybranaKorektaFaktury != value)
                {
                    _WybranaKorektaFaktury = value;
                    OnPropertyChanged(() => _WybranaKorektaFaktury);
                }
            }
        }
        #endregion
        #region Konstruktor
        public KorektaFakturyViewModel()
            : base("Korekta Faktury")
        {
        }
        #endregion

        #region Helpers
        public override void Load()
        {
            List = new ObservableCollection<KorektaFakturyAll>
                (

                  from korektaFaktury in FakturyEntities.KorektaFakturySprzedazy

                  select new KorektaFakturyAll
                  {
                     IdKorektyFaktury = korektaFaktury.IdKorektyFaktury,
                     NumerFaktury = korektaFaktury.Faktura.Numer,
                     DataWystawieniaFaktury = korektaFaktury.Faktura.DataWystawienia,
                     DataWystawieniaKorekty = korektaFaktury.DataWystawieniaKorekty


                  }
                );
            AllList = new List<KorektaFakturyAll>(List);
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
                        List = new ObservableCollection<KorektaFakturyAll>(AllList.Where(item => item.Numer?.ToLower().Trim() == SearchText));
                        break;

                }
            }
            else
            {
                List = new ObservableCollection<KorektaFakturyAll>(AllList);
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
                    List = new ObservableCollection<KorektaFakturyAll>(SortDescending ? List.OrderByDescending(item => item.Numer) : List.OrderBy(item => item.Numer));
                    break;
            }
        }
        #endregion
        protected override void Modify()
        {
            if (_WybranaKorektaFaktury != null)
            {
                Messenger.Default.Send(_WybranaKorektaFaktury);
                OnRequestClose();
            }
            else
            {
                MessageBox.Show("Zaznacz wiersz który chcesz zmodyfikować", "Error");
            }
        }

        protected override void Delete()
        {
              //  new KorektaFakturyViewModel(_WybranaKorektaFaktury).UstawElementNiektywny();
            Refresh();
        }
        protected override void Refresh()
        {
            SearchText = null;
            Load();
        }
    }
}

