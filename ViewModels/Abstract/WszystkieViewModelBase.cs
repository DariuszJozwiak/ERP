using ERPNavi.Helpers;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ERPNavi.ViewModels.Abstract
{
    /// <summary>
    /// ViewModel realizujacy polaczenie jeden do wielu. Np. Jedna faktura posiada wiele pozycji faktury.
    /// </summary>
    /// <typeparam name="J">Model typu "jeden", np: Faktura</typeparam>
    /// <typeparam name="W">Model typu "wiele", np. Pozycja faktury.</typeparam>
    /// <typeparam name="T">Model typu "wiele", np. Pozycja faktury.</typeparam>


    public abstract class WszystkieViewModelBase<W, T> : WszystkieViewModel<T>
    {
        #region PolaIWlasciwosci

        private string _DisplayListName;
        public string DisplayListName
        {
            get
            {
                return _DisplayListName;
            }
            set
            {
                if (value != _DisplayListName)
                {
                    _DisplayListName = value;
                    OnPropertyChanged(() => DisplayListName);
                }
            }
        }

       public List<T> AllList { get; set; }

     

        //  public List<T> AllListKontrahenci { get; set; }

        private ObservableCollection<W> _List;
        /// <summary>
        /// Lista z typem wiele, np. z pozycjami faktury.
        /// </summary>
        public ObservableCollection<W> List
        {
            get
            {
                return _List;
            }
            set
            {
                if (value != _List)
                {
                    _List = value;
                    OnPropertyChanged(() => List);
                }
            }

        }
        private ICommand _ShowAddViewCommand;
        public ICommand ShowAddViewCommand
        {
            get
            {
                if (_ShowAddViewCommand == null)
                {
                    _ShowAddViewCommand = new BaseCommand(() => ShowAddView());
                }
                return _ShowAddViewCommand;
            }
        }

        #endregion

        #region Konstruktory

        public WszystkieViewModelBase(string displayName, string displayListName) : base(displayName)
        {
            DisplayListName = displayListName;
        }

        #endregion
        #region Metody

        /// <summary>
        /// Wysyla komunikat o otworzenie zakladki tworzenia nowego Modelu typu wiele. Np. Wysyla komunikat aby otworzyc zakladke nowa pozacja faktury.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void ShowAddView()
        {
            Messenger.Default.Send(DisplayListName + " Add");
        }

        #endregion
    }
}
