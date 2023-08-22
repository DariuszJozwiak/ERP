using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.EntietiesForView
{
    public class FakturaAll
    { 
        #region Propertis
    public string NazwaTowaru { get; set; }
    public double IloscTowaru { get; set; }
    public double CenaNetto { get; set; }
  
    public double RabatNaTowar { get; set; }
    public double VAT_procent { get; set; }
    public double VAT_wyliczony { get; set; }
    public double WartoscNetto { get; set; }
    public double CenaBrutto { get; set; }

    public string Numer { get; set; }

     public DateTime? DataWystawienia { get; set; }
     public int IdKontrahenta { get; set; }
     public int IdSposobuPlatnosci { get; set; }
     public bool CzyZatwierdzono { get; set; }
     public bool CzyAktywna { get; set; }

        public int IdFaktury { get; set; }
      
      

        public string KontrahentNazwa { get; set; }
        public string KontrahentNIP { get; set; }
        public string KontrahentAdres { get; set; }
        //koniec
      public DateTime? TerminPlatnosci { get; set; }
        //poniższa własciwość zastępuje klucz obcy IDSposobuPłatności
        public string SposobPlatnosciNazwa { get; set; }
     

    
       public string PozycjaFaktury { get; set; }




        #endregion
    }
}