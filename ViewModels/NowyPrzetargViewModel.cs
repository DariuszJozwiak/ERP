using ERPNavi.Models.Entieties;
using ERPNavi.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.ViewModels
{
    public class NowyPrzetargViewModel : JedenViewModel<Przetargi>
    {


        #region  Properties 
        bool czyNowyObiekt;
        public string NrPrzetargu
        {
            get
            {
                return item.NrPrzetargu;
            }
            set
            {
                if (value == item.NrPrzetargu) return;
                item.NrPrzetargu = value; base.OnPropertyChanged(() => NrPrzetargu);
            }
        }
        public string NazwaPrzetargu
        {
            get
            {
                return item.NazwaPrzetargu;
            }
            set
            {

                if (value == item.NazwaPrzetargu) return;
                item.NazwaPrzetargu = value; base.OnPropertyChanged(() => NazwaPrzetargu);


            }
        }
        public DateTime? DataOgloszenia
        {
            get
            {
                return item.DataOgloszenia;
            }
            set
            {

                if (value == item.DataOgloszenia) return;
                item.DataOgloszenia = value;
                base.OnPropertyChanged(() => DataOgloszenia);

            }
        }

        public DateTime? DataZakonczenia
        {
            get
            {
                return (DateTime?)item.DataZakonczenia;
            }
            set
            {

                if (value == item.DataZakonczenia) return;
                item.DataZakonczenia = value;
                base.OnPropertyChanged(() => DataZakonczenia);

            }
        }

        #endregion
        //public override void Close()
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Load()
        //{
        //    throw new NotImplementedException();
        //}
        #region  Constructor
        public NowyPrzetargViewModel()
        : base("Nowy przetarg")
        {
            base.DisplayName = "Nowy przetarg";
            item = new Przetargi();
        }
        #endregion  //  Constructor
        #region Metody
        public override void Save()
        {
            item.CzyAktywny = true;
            if (czyNowyObiekt)
            {
                Db.Przetargi.AddObject(item);
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
  

