using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.Validatory
{
    public class DecimalValidator : Validator
    {
        /// <summary>
        /// W przypadku błędu, zwracamy jego komunikat. W przypadku braku błędu zwracamy null.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CzyWiekszeOdZera(decimal value) => value < 0 ? "Ta wartość nie może być mniejsza od zera" : string.Empty;

        public static string CzyProcent(decimal value) => value <= 1 && value >= 0 ? string.Empty : "Ta wartość musi reprezentować procent";

        internal static string CzyWiekszeOdZera(object p)
        {
            throw new NotImplementedException();
        }
    }
}
