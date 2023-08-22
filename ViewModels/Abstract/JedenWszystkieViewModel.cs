using ERPNavi.Helpers;
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
    /// <summary>
    /// ViewModel realizujacy polaczenie jeden do wielu. Np. Jedna faktura posiada wiele pozycji faktury.
    /// </summary>
    /// <typeparam name="J">Model typu "jeden", np: Faktura</typeparam>
    /// <typeparam name="W">Model typu "wiele", np. Pozycja faktury.</typeparam>
    public abstract  class JedenWszystkieViewModel<J, W> : JedenViewModel<J>
    {

        #region PolaIWlasciwosci


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

        public JedenWszystkieViewModel(string displayName, string displayListName) : base(displayName)
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
        public abstract void Load();
        #endregion
    }
}
