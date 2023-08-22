using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.EntietiesForView
{
    public class ZamowieniaWMSAll
    {
        #region Propertis
        public int IdZamowieniaWMS { get; set; }

        public DateTime? Data_Utworzenia_zlecenia { get; set; }

        public string NazwaKontrahenta { get; set; }
        public int IdZamowieniaOdKlientow { get; set; }
        public string NazwaTowaru { get; set; }
        public string Numer { get; set; }
        public int IloscZamowionaERP { get; set; }
        public int IloscWydanaWMS { get; set; }
        public int IdKontrahenta { get; set; }

        
        #endregion
    }
}
