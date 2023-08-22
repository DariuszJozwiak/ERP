using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.EntietiesForView
{
    public class TowaryAll
    {
        #region Propertis
public int IdTowaru { get; set; }
public string Kod { get; set; }
public string NazwaTowaru { get; set; }
public double StawkaVatSprzedazy { get; set; }
public decimal CenaNetto { get; set; }
public decimal Marza { get; set; }
public short CzyAktywny { get; set; }

public int IdStanuMagazynowego { get; set; }
public string Status { get; set; }


        #endregion
    }
}