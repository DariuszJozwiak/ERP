using ERPNavi.Models.Entieties;
using ERPNavi.Models.Validatory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace ERPNavi.ViewModels
{

    public class NowyTowarViewModel : JedenViewModel<Towar>, IDataErrorInfo
    {
        #region  Constructor
        public NowyTowarViewModel()
            : base("Nowy towar")
        {
            item = new Towar();
        }


        #endregion  //  Constructor
        #region  Properties 
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (value == item.Kod) return;
                item.Kod = value; base.OnPropertyChanged(() => Kod);
            }
        }
        public string NazwaTowaru
        {
            get
            {
                return item.NazwaTowaru;
            }
            set
            {

                if (value == item.NazwaTowaru) return;
                item.NazwaTowaru = value;
                base.OnPropertyChanged(() => NazwaTowaru);


            }
        }
        public decimal StawkaVatSprzedazy
        {
            get
            {
                return item.StawkaVatSprzedazy;
            }
            set
            {

                if (value == item.StawkaVatSprzedazy) return;
                item.StawkaVatSprzedazy = value;
                base.OnPropertyChanged(() => StawkaVatSprzedazy);

            }
        }

        //public int? StawkaVatZakupu
        //{
        //    get
        //    {
        //        return (int?)item.StawkaVatZakupu;
        //    }
        //    set
        //    {

        //        if (value == item.StawkaVatZakupu) return;
        //        item.StawkaVatZakupu = value; base.OnPropertyChanged(() => StawkaVatZakupu);
        //    }
        //}
        public decimal CenaNetto
        {
            get
            {
                return item.CenaNetto;
            }
            set
            {
                if (value == item.CenaNetto) return;
                item.CenaNetto = value;
                base.OnPropertyChanged(() => CenaNetto);
            }
        }
        public decimal Marza
        {
            get
            {
                return (decimal)item.Marza;
            }
            set
            {
                if (value == (decimal)item.Marza) return;
                item.Marza = (decimal)value; base.OnPropertyChanged(() => Marza);
            }
        }


        #endregion  //Properties
        #region Metody
       

        public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(CenaNetto):
                        return DecimalValidator.CzyWiekszeOdZera(CenaNetto);
                     //   return DecimalValidator.CzyProcent(StawkaVatSprzedazy.GetValueOrDefault());
                    case nameof(StawkaVatSprzedazy):
                        return DecimalValidator.CzyProcent(StawkaVatSprzedazy);

                    default:
                        return string.Empty;
                }
            }
        }


        public override void Save()
        {
            item.CzyAktywny = true;
            //najpierw dodajemy towar do lokalnej kolekcji
            Db.Towar.AddObject(item);
            //następnie zapisujemy zmiany w bazie danych
            Db.SaveChanges();
        }
        protected override bool IsValid()
        {
            return this[nameof(CenaNetto)] == string.Empty
                   && this[nameof(StawkaVatSprzedazy)] == string.Empty;
        }

        public void UstawElementNiektywny()
        {
            item.CzyAktywny = false;
            Db.SaveChanges();
        }

        //public override void Close()
        //{
        //    throw new NotImplementedException();
        //}

        //public override void Load()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}