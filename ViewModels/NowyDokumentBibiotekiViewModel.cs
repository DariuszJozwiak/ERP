using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.ViewModels
{
    public class NowyDokumentBibiotekiViewModel : JedenViewModel<BibliotekaDokumentow>
    {

        #region  Constructor
        public NowyDokumentBibiotekiViewModel()
          : base("Nowy dokument biblioteki")
        {
            base.DisplayName = "Nowy dokument biblioteki";
            item = new BibliotekaDokumentow();
        }
        #endregion  //  Constructor
        #region  Properties 
        public string Odbiorca
        {
            get
            {
                return item.Odbiorca;
            }
            set
            {
                if (value == item.Odbiorca) return;
                item.Odbiorca = value; base.OnPropertyChanged(() => Odbiorca);
            }
        }
        public string NrDok
        {
            get
            {
                return item.NrDok;
            }
            set
            {

                if (value == item.NrDok) return;
                item.NrDok = value; base.OnPropertyChanged(() => NrDok);


            }
        }

        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {

                if (value == item.Opis) return;
                item.Opis = value; base.OnPropertyChanged(() => Opis);


            }
        }
        public bool? CzyAktywny
        {
            get
            {
                return item.CzyAktywny;
            }
            set
            {
                if (item.CzyAktywny != value)
                {
                    item.CzyAktywny = value;
                    OnPropertyChanged(() => CzyAktywny);
                }
            }
        }

       

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public void UstawElementNiektywny()
        {
            item.CzyAktywny = false;
            Db.SaveChanges();
        }


        #endregion  //Properties
    }
}