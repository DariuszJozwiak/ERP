using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.ViewModels
{
    public class NowyPracownikKadrViewModel : JedenViewModel<Kadry>
    {
        #region  Properties 
        bool czyNowyObiekt;
        public string ImiePracownika
        {
            get
            {
                return item.ImiePracownika;
            }
            set
            {
                if (value == item.ImiePracownika) return;
                item.ImiePracownika = value; base.OnPropertyChanged(() => ImiePracownika);
            }
        }
        public string NazwiskoPracownika
        {
            get
            {
                return item.NazwiskoPracownika;
            }
            set
            {

                if (value == item.NazwiskoPracownika) return;
                item.NazwiskoPracownika = value; base.OnPropertyChanged(() => NazwiskoPracownika);


            }
        }
        public DateTime? DataZatrudnieniaPracownika
        {
            get
            {
                return item.DataZatrudnieniaPracownika;
            }
            set
            {

                if (value == item.DataZatrudnieniaPracownika) return;
                item.DataZatrudnieniaPracownika = value;
                base.OnPropertyChanged(() => DataZatrudnieniaPracownika);

            }
        }
        public string MiastoZamieszkaniaPracownika
        {
            get
            {
                return item.MiastoZamieszkaniaPracownika;
            }
            set
            {

                if (value == item.MiastoZamieszkaniaPracownika) return;
                item.MiastoZamieszkaniaPracownika = value; base.OnPropertyChanged(() => MiastoZamieszkaniaPracownika);


            }
        }


        #endregion

        #region  Constructor
        public NowyPracownikKadrViewModel()
        : base("Nowy pracownik kard")
        {
            base.DisplayName = "Nowy pracownik kadr";
            item = new Kadry();
        }
        #endregion  //  Constructor
        #region Metody
        public override void Save()
        {
            item.CzyAktywny = true;
            if (czyNowyObiekt)
            {
                Db.Kadry.AddObject(item);
            }
            Db.SaveChanges();
        }
        public void UstawElementNiektywny()
        {
            item.CzyAktywny = false;
            Db.SaveChanges();
        }



        #endregion  //Properties
    }
}

