using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.EntietiesForView
{
    //Ta klasa jest po to rzeby w sposób czytelny dla zwykłego użytkownika wyświeltać faktury na liście faktur.
    public class FakturaForAllView
    {
        #region Propertis
        public int IdFaktury { get; set; }
        public string Numer { get; set; }
        public DateTime? DataWystawienia { get; set; }
        //niżej znajdują się pola które zastępują klucz obcy IDKontrahenta

        public string KontrahentNazwa { get; set; }
        public string KontrahentNIP { get; set; }
        public string KontrahentAdres { get; set; }
        //koniec
        public DateTime? TerminPlatnosci { get; set; }
        //poniższa własciwość zastępuje klucz obcy IDSposobuPłatności
        public string SposobPlatnosciNazwa { get; set; }
        public bool CzyAktywna { get; set; }

        #endregion



    }
}
