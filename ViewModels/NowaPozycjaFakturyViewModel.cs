using ERPNavi.Models.Entieties;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.ViewModels
{
    public class NowaPozycjaFakturyViewModel : JedenViewModel<PozycjaFaktury>
    { 
    #region PolaIWlasciwosci
    public List<Towar> Towary { get; set; }

    public int IdFaktury
    {
        get
        {
            return item.IdFaktury;
        }
        set
        {
            if (item.IdFaktury != value)
            {
                item.IdFaktury = value;
                OnPropertyChanged(() => IdFaktury);
            }
        }
    }
    public int IdTowaru
    {
        get
        {
            return item.IdTowaru;
        }
        set
        {
            if (item.IdTowaru != value)
            {
                item.IdTowaru = (int)value;
                OnPropertyChanged(() => IdTowaru);
                //Item.Towar = Towary.Find(item => item.IdTowaru == IdTowaru);
            }
        }
    }
    public decimal CenaNetto
    {
        get
        {
            return item.CenaNetto;
        }
        set
        {
            if (item.CenaNetto != value)
            {
                item.CenaNetto = value;
                OnPropertyChanged(() => CenaNetto);
            }
        }
    }
    public decimal Ilosc
    {
        get
        {
            return item.Ilosc;
        }
        set
        {
            if (item.Ilosc != value)
            {
                item.Ilosc = (decimal)value;
                OnPropertyChanged(() => Ilosc);
            }
        }
    }
    public decimal Rabat
    {
        get
        {
            return item.Rabat;
        }
        set
        {
            if (item.Rabat != value)
            {
                item.Rabat = value;
                OnPropertyChanged(() => Rabat);
            }
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
        #endregion

        #region Kontruktory

        public NowaPozycjaFakturyViewModel() : base("Pozycja faktury")
    {
        item = new PozycjaFaktury()
        {
            CzyAktywny = true
        };
        Towary = (from towar in Db.Towar
                  where towar.CzyAktywny == true
                  select towar).ToList();
    }

    #endregion

    public override void Save()
    {
        Messenger.Default.Send(item);
    }
        //public override void Close()
        //{
        //   //Messenger.Default.Close(item);
        //}
        public void UstawElementNiektywny()
        {
            item.CzyAktywny = false;
            Db.SaveChanges();
        }
    }
}
