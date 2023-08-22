using ERPNavi.Models.Entieties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.ViewModels
{
    public class NoweZamowienieOdKlientowViewModel : JedenViewModel<ZamowieniaOdKlientow>
    {

        public List<Towar> Towary { get; set; }
        #region  Properties 
        bool czyNowyObiekt;
        public int? IdTowaru
        {
            get
            {
                return (int?)item.IdTowaru ;
            }
            set
            {
                if (value == item.IdTowaru) return;
                item.IdTowaru = value; base.OnPropertyChanged(() => IdTowaru);
            }
        }
        public int? IloscZamowiona
        {
            get
            {
                return (int?)item.IloscZamowiona;
            }
            set
            {
                if (value == item.IloscZamowiona) return;
                item.IloscZamowiona = value; base.OnPropertyChanged(() => IloscZamowiona);
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
        public DateTime Data_Utworzenia_zlecenia
        {
            get
            {
                return (DateTime)item.Data_utworzenia_zlecenia;
            }
            set
            {

                if (value == item.Data_utworzenia_zlecenia) return;
                item.Data_utworzenia_zlecenia = value;
                base.OnPropertyChanged(() => Data_Utworzenia_zlecenia);

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
        public NoweZamowienieOdKlientowViewModel()
           : base("Nowe zamowienie od klientow")
        {
            base.DisplayName = "Nowe zamowienie od klientow";
            item = new ZamowieniaOdKlientow();
            {
               
            };
            Towary = (from towar in Db.Towar
                      where towar.CzyAktywny == true
                      select towar).ToList();
        }
    
        #endregion  //  Constructor
        #region Metody
        public override void Save()
        {
            item.CzyAktywny = true;
            if (czyNowyObiekt)
            {
                Db.ZamowieniaOdKlientow.AddObject(item);
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


