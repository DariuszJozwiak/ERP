using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.EntietiesForView
{
    public class KontrahenciForAllView
    {
        #region Propertis
        public int IdKontrahenta { get; set; }
        public string Kod { get; set; }
        public string KontrahentNazwa { get; set; }
        public string KontrahentNIP { get; set; }
        public string KontrahentAdres { get; set; }
        public string NIP { get;  set; }
        public string Nazwa { get;  set; }
        public string AdresKontrahenta { get;  set; }
        public DateTime DataPrzystapienia { get;  set; }
       
        //koniec


        #endregion

    }
}
