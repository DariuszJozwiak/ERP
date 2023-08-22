using Elmah.ContentSyndication;
using ERPNavi.Helpers;


using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ERPNavi.ViewModels
{
    /// <summary>
    /// klasa z ktorej beda dziedziczyly wszystkie zakladki np dodajace recordy
    /// </summary>
    /// <typeparam name="T">Typ Modelu z bazy danych danych (np. Faktura, Kontrahent)</typeparam>
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region  Fields

        //tu jest cala db
        public Entities2 Db { get; set; }
     //   public Entities2 FakturyEntities { get; set; }

        //tu jest dodawany towar
        /// <summary>
        /// Klasa z warstwy Model
        /// </summary>
        public T item { get; set; }
        //public T danePozycjiFaktury { get; set; }
        #endregion  //  end Fields

        #region  Konstructor 
        public JedenViewModel(string displayName)
        {
            base.DisplayName = displayName; //tu ustawiamy nazwę zakładki
            Db = new Entities2();
            //   this.Faktury2022Model = new Entities2();

          
           
        }
        #endregion  //  Constructor

        #region  Command
        // To jest komenda, która zostanie podpięta (zbindowana) z przyciskiem "Zapisz i zamknij"
        // Komenda ta wywołuje funkcję "SaveAndClose()"
        private BaseCommand _SaveAndCloseCommand;

        public ICommand SaveAndCloseCommand
        {
            get
            {
                if (_SaveAndCloseCommand == null)
                {
                    _SaveAndCloseCommand = new BaseCommand(() => saveAndClose());
                }

                return _SaveAndCloseCommand;
            }
        }
        private BaseCommand _CloseCommand;
        //public ICommand CloseCommand
        //{
        //    get
        //    {
        //        if (_CloseCommand == null)
        //        {
        //            _CloseCommand = new BaseCommand(() => Close());
        //        }

        //        return _CloseCommand;
        //    }
        //}
        //public ICommand RefreshCommand
        //{
        //    get
        //    {

        //        return RefreshCommand;
        //    }
        //}
        #endregion  //Command
        #region  Helpers
        
        public abstract void Save();
        private void saveAndClose()
        {
            if (IsValid())
            {
                Save();                 //zapisuje towar
               // MessageBox.Show("Udało sie zapisać","Sukces");
                base.OnRequestClose();  //zamyka zakładkę
            }
            else
            {
                MessageBox.Show("Popraw błędy","Błąd");
            }
        }
        //private void Close()
        //{
        //    base.OnRequestClose();
        //}

        /// <summary>
        /// Czy można zapisać.
        /// </summary>
        /// <returns>True, jeśli można zapisać</returns>
        protected virtual bool IsValid() => true;
        #endregion
       //  protected Entities2 Faktury2022Model;
    }
}


       

