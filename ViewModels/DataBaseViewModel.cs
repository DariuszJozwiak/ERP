

using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.ViewModels
{
    public class DataBaseViewModel : WorkspaceViewModel
    {
        #region  Fields
        protected Entities2 fakturyEntities;
        #endregion  //  Fields
        #region  Constructor
        public DataBaseViewModel()
        {
            this.fakturyEntities = new Entities2();
        }
        #endregion  //  Constructor
    }
}
