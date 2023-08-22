using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ERPNavi.Models.BusinessLogic
{
    public class TowarB : DatabaseClass
    {
        public TowarB(Entities2 fakturyEntities)
    : base(fakturyEntities)
        {
        }
        public IQueryable<ComboBoxKeyAndValue> GetTowaryComboBoxItems()
        {
            return (
            from towar in fakturyEntities.Towar
            select new ComboBoxKeyAndValue
            {
                Key = towar.IdTowaru,
                Value = towar.NazwaTowaru + "  " + towar.Kod
            }).ToList().AsQueryable();
        }
    }
}


