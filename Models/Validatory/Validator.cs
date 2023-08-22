using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPNavi.Models.Validatory
{
    public class Validator
    {
    public static string CannotBeNull(object value) => value == null ? "To nie może być puste" : string.Empty;
    }
}
