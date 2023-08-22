using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.EntietiesForView
{
    public class StanyMagazynoweAll
    {
        #region Propertis
        public int IdStanuMagazynowego { get; set; }
      
        public DateTime? DataPrzyjecia { get; set; }
        public DateTime? DataPrzydatnosciDoUzycia { get; set; }
       

        public int IloscPrzyjeta { get; set; }
     
      
        public string NazwaTowaru { get; set; }

        public string Kod{ get; set; }
        #endregion

    }
}
