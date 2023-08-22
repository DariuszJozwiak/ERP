using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.EntietiesForView
{
    public class ZamowieniaOdKlientowAll
    {
        #region Propertis
        public string NazwaKontrahenta { get; set; }
        public int IdZamowienia { get; set; }
        public string NazwaTowaru { get; set; }
        public int IloscZamowiona { get; set; }
        //niżej znajdują się pola które zastępują klucz obcy IDKontrahenta

        public string Opis { get; set; }
       
       
        public DateTime? Data_Utworzenia_zlecenia { get; set; }
        public decimal StanMagazynowy { get;  set; }
        public string Numer { get;  set; }
        //poniższa własciwość zastępuje klucz obcy IDSposobuPłatności
        #endregion
    }
}
