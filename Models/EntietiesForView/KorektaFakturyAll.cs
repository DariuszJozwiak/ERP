using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.EntietiesForView
{
    public class KorektaFakturyAll
    {
        #region Propertis
        public int IdKorektyFaktury { get; set; }
        public string NumerFaktury { get; set; }
        public string Numer { get; set; }

        public DateTime? DataWystawieniaFaktury { get; set; }
        public DateTime? DataWystawieniaKorekty { get; set; }

        #endregion
    }
   
}