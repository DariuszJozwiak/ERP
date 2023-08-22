using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.BusinessLogic
{
    public class WartoscNettoNFaktura : DatabaseClass
    {
        public WartoscNettoNFaktura(Entities2 fakturyEntities)
               : base(fakturyEntities)
        {
        }

        public double  WartoscNettoNF(decimal ilosc, decimal CenaNetto, decimal Rabat)
        { 

            return
           (double)(
            from pozycja in fakturyEntities.PozycjaFaktury
        //   where
         //  pozycja.IdTowaru == 
            select (pozycja.CenaNetto) * pozycja.Ilosc
            //   select pozycja.Towar.CenaNetto * pozycja.Ilosc
            ).Sum();

        }
    }
}

