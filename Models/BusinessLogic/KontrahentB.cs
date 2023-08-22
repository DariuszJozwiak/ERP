using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.BusinessLogic
{
    public class KontrahentB : DatabaseClass
    {
        public KontrahentB(Entities2 fakturyEntities)
       : base(fakturyEntities)
        {
        }
        public IQueryable<ComboBoxKeyAndValue> GetKontrahentComboBoxItems()
        {
            return (
            from kontrahent in fakturyEntities.Kontrahent
            select new ComboBoxKeyAndValue
            {
                Key = kontrahent.IdKontrahenta,
                Value = kontrahent.Nazwa + "  " 
            }).ToList().AsQueryable();
        }
    }
}
