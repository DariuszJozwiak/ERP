using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.EntietiesForView
{
    public class PozycjeFakturyForAllView
    {
        #region PolaIWlasciwosci

        private string _Kod;
        public string Kod
        {
            get
            {
                return _Kod;
            }
            set
            {
                if (value != _Kod)
                {
                    _Kod = value;
                }
            }
        }

        private string _NazwaTowaru;
        public string NazwaTowaru
        {
            get
            {
                return _NazwaTowaru;
            }
            set
            {
                if (value != _NazwaTowaru)
                {
                    _NazwaTowaru = value;
                }
            }
        }

        private decimal _CenaNetto;
        public decimal CenaNetto
        {
            get
            {
                return _CenaNetto;
            }
            set
            {
                if (value != _CenaNetto)
                {
                    _CenaNetto = value;
                }
            }
        }

        private decimal _Ilosc;
        public decimal Ilosc
        {
            get
            {
                return _Ilosc;
            }
            set
            {
                if (value != _Ilosc)
                {
                    _Ilosc = value;
                }
            }
        }

        private decimal _Rabat;
        public decimal Rabat
        {
            get
            {
                return _Rabat;
            }
            set
            {
                if (value != _Rabat)
                {
                    _Rabat = value;
                }
            }
        }

        private int _IdFaktury;
        public int IdFaktury
        {
            get
            {
                return _IdFaktury;
            }
            set
            {
                if (value != _IdFaktury)
                {
                    _IdFaktury = value;
                }
            }
        }

        #endregion

    }
}
