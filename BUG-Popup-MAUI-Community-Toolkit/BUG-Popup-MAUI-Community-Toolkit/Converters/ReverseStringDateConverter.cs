using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Maui.Controls.Xaml;

namespace BUG_Popup_MAUI_Community_Toolkit.Converters
{
    public class ReverseStringDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is string date)
            {
                char[] charArrayR = date.ToCharArray();
                Array.Reverse(charArrayR);
                return new string(charArrayR);
            }
            return string.Empty;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is string dateR)
            {
                char[] charArray = dateR.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
            return string.Empty;


        }
    }
}
