using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.BusinessLogic
{
    public class UtargB : DatabaseClass
    {
        public UtargB(Entities2 fakturyEntities)
        : base(fakturyEntities)
        {
        }
        public double? UtargOkresTowar(int IdTowaru, DateTime odDaty, DateTime doDaty)
        {

            return
            (double?)(
            from pozycja in fakturyEntities.PozycjaFaktury
            where
           pozycja.IdTowaru == IdTowaru && pozycja.Faktura.DataWystawienia >= odDaty && pozycja.Faktura.DataWystawienia <= doDaty
            select pozycja.CenaNetto * pozycja.Ilosc
         //   select pozycja.Towar.CenaNetto * pozycja.Ilosc
            ).Sum();

        }
    }
}


