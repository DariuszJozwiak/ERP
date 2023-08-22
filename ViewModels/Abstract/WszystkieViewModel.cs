using ERPNavi.Helpers;
using ERPNavi.Models.Entieties;
using ERPNavi.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERPNavi.ViewModels.Abstract
{
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel //bo wszystkie zakl....
    {
        #region Fields
        //to jest obiekt, ktory...
        private readonly Entities2 fakturyEntities;
        public Entities2 FakturyEntities
        {
            get
            {
                return fakturyEntities;
            }
        }
        // to jest komenda do za ladowania towarow
        private BaseCommand _LoadCommand;
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => Load());//pusta wywoluje load
                }
                return _LoadCommand;
            }
        }
        //w tym obiekcie beda wszystkie towary
        private ObservableCollection<T> _List;
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) //jak lista jest pusta wy...
                    Load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }

        public List<T> AllList { get; set; }
        public List<T> AllListKontrahenci { get; set; }
 
        public List<string> SortComboBoxItems { get; set; }
        public string SortField { get; set; }
        public bool SortDescending { get; set; }
        private ICommand _SortCommand;
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => Sort());
                }
                return _SortCommand;
            }
        }

        public List<string> SearchComboBoxItems { get; set; }
        public string SearchField { get; set; }
        private ICommand _SearchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new BaseCommand(() => Search());
                }
                return _SearchCommand;
            }
        }
        private string _SearchText { get; set; }
        public string SearchText
        {
            get 
            {
                return _SearchText;
            }
            set
            {
                if (_SearchText != value)
                {
                    _SearchText = value?.ToLower().Trim();
                    OnPropertyChanged(() => SearchText);
                }
            }
        }
        private ICommand _RefreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_RefreshCommand == null)
                {
                    _RefreshCommand = new BaseCommand(() => Refresh()); 
                }

                return _RefreshCommand;
            }
        }

        private ICommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new BaseCommand(() => Delete()); //pusta wywoluje load
                }

                return _DeleteCommand;
            }
        }

        private ICommand _ModifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                if (_ModifyCommand == null)
                {
                    _ModifyCommand = new BaseCommand(() => Modify()); //pusta wywoluje load
                }

                return _ModifyCommand;
            }
        }

        private ICommand _AddCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => Add()); //pusta wywoluje load
                }

                return _AddCommand;
            }
        }




        #endregion
        #region Konstruktor
        public WszystkieViewModel(string displayName)
        {
            base.DisplayName = displayName;
       this.fakturyEntities = new Entities2();

            SortComboBoxItems = GetSortComboBoxItems();
            SearchComboBoxItems = GetSearchComboBoxItems();
            SearchField = SearchComboBoxItems.First();
            SortField = SortComboBoxItems.First();
        }
        #endregion
        #region Helpers
        public abstract void Load();
        private void Add()
        {
            Messenger.Default.Send(DisplayName + " Add");
            OnRequestClose();
        }

        #endregion
        abstract protected List<string> GetSortComboBoxItems();
        abstract protected void Sort();
        abstract protected List<string> GetSearchComboBoxItems();
        abstract protected void Search();
        abstract protected void Delete();
        abstract protected void Modify();
        abstract protected void Refresh();
    }
}
