using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ERPNavi.Views
{
    public class JedenWszystkieViewBaseModyfikuj : UserControl
    {
        static JedenWszystkieViewBaseModyfikuj()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(JedenWszystkieViewBaseModyfikuj), new FrameworkPropertyMetadata(typeof(JedenWszystkieViewBaseModyfikuj)));
        }
    }
}
