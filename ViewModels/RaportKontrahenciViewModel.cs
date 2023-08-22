using ERPNavi.Helpers;
using ERPNavi.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERPNavi.ViewModels
{
    public class RaportKontrahenciViewModel : DataBaseViewModel
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

        private int _IdKontrahenta;
        public int IdKontrahenta
        {
            get
            {
                return _IdKontrahenta;
            }
            set
            {
                if (value == _IdKontrahenta) return;
                _IdKontrahenta = value;
                OnPropertyChanged(() => IdKontrahenta);
            }
        }

        //private string _Nazwa;
        //public string Nazwa
        //{
        //    get
        //    {
        //        return _Nazwa;
        //    }
        //    set
        //    {
        //        if (value == _Nazwa) return;
        //        _Nazwa = value;
        //        OnPropertyChanged(() => Nazwa);
        //    }
        //}

        public IQueryable<ComboBoxKeyAndValue> KontrahenciComboBoxItems
        {

            get
            {
                return new KontrahentB(fakturyEntities).GetKontrahentComboBoxItems();
            }
        }

        private int _WynikiKontrahent;

        public int WynikiKontrahent
        {
            get
            {
                return _WynikiKontrahent;
            }
            set
            {
                if (value == _WynikiKontrahent) return;
                _WynikiKontrahent = value; 
                OnPropertyChanged(() => WynikiKontrahent);
            }
        }
        #endregion  //  Fields  and  Properties
        #region  Constructor
        public RaportKontrahenciViewModel()
        : base()
        {
            base.DisplayName = "Raport Kontrahentów";
            DataOd = DateTime.MinValue;
            DataDo = DateTime.Now;
           // WynikiKontrahent =0;
        }
        #endregion  //  Constructor

        #region  Command
        private BaseCommand _PokazKontrahentowCommand;
        public ICommand PokazKontrahentowCommand
        {
            get
            {
                if (_PokazKontrahentowCommand == null)
                {

                    _PokazKontrahentowCommand = new BaseCommand(() => pokazKontrahentowCommandClick());
                }
                return _PokazKontrahentowCommand;
            }
        }
        #endregion  //Command 
        #region  Private  Helpers

        private void pokazKontrahentowCommandClick()
        {
            WynikiKontrahent = new KontrahentBRaport(fakturyEntities).RaportOkresKontrahent(IdKontrahenta, DataOd, DataDo);
        }
        #endregion  //Private  Helpers
    }
}
