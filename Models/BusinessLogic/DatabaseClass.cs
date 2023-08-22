using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.BusinessLogic
{
    public class DatabaseClass
    {
        #region  Fields
        protected Entities2 fakturyEntities;
        #endregion  //Fields

        #region  Constructor
        public DatabaseClass(Entities2 fakturyEntities)
        {
            this.fakturyEntities = fakturyEntities;
        }
        #endregion  //Constructor
    }
}
