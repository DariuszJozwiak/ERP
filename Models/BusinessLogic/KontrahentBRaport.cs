using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.BusinessLogic
{
   public class KontrahentBRaport :DatabaseClass
    {
        public KontrahentBRaport(Entities2 fakturyEntities)
           : base(fakturyEntities)
        {
        }
        public int RaportOkresKontrahent(int IdKontrahenta, DateTime odDaty, DateTime doDaty)
        {

            return (int)(

            from kontrahent in fakturyEntities.Kontrahent

            where kontrahent.IdKontrahenta == IdKontrahenta && kontrahent.DataPrzystapienia >= odDaty && kontrahent.DataPrzystapienia <= doDaty

            select kontrahent.Nazwa).Count();
            
           
            //   select pozycja.Towar.CenaNetto * pozycja.Ilosc

          

        }
    }
}

