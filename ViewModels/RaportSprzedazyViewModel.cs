using ERPNavi.Helpers;
using ERPNavi.Models.BusinessLogic;
using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERPNavi.ViewModels
{
    public class RaportSprzedazyViewModel : DataBaseViewModel
    {
        #region  Fields  and  Properties 
        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (value == _DataOd) return;
                _DataOd = value;
                OnPropertyChanged(() => DataOd);
            }
        }

        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (value == _DataDo) return;
                _DataDo = value;
                OnPropertyChanged(() => DataDo);
            }
        }
        private int _IdTowaru;
        public int IdTowaru
        {
            get
            {
                return _IdTowaru;
            }
            set
            {
                if (value == _IdTowaru) return;
                _IdTowaru = value;
                OnPropertyChanged(() => IdTowaru);
            }
        }

        public IQueryable<ComboBoxKeyAndValue> TowaryComboBoxItems
        {

            get
            {
                return new TowarB(fakturyEntities).GetTowaryComboBoxItems();
            }
        }

        private double? _Utarg; 
        
        public double? Utarg
        {
            get
            {
                return _Utarg;
            }
            set
            {
                if (value == _Utarg) return;
                _Utarg = value; OnPropertyChanged(() => Utarg);
            }
        }
        #endregion  //  Fields  and  Properties

        #region  Constructor
        public RaportSprzedazyViewModel()
        : base()
        {
            base.DisplayName = "Raport  Sprzedaży";
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            Utarg = 0;
        }
        #endregion  //  Constructor



        #region  Command
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                {

                    _ObliczCommand = new BaseCommand(() => obliczUtargClick());
                }
                return _ObliczCommand;
            }
        }
        #endregion  //Command 
        #region  Private  Helpers

        private void obliczUtargClick()
        {
            Utarg = new UtargB(fakturyEntities).UtargOkresTowar(IdTowaru, DataOd, DataDo);
        }
        #endregion  //Private  Helpers
    }
}
