using System;
using System.Diagnostics;
using System.Globalization;

namespace BUG_Popup_MAUI_Community_Toolkit.Converters
{
    public class RatioConverter : IValueConverter
    {
        public double Coefficient { get; set; } = 1;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value != null &&
            //    parameter != null)
            if (value != null)
            {
                double dValue;
                double.TryParse(value.ToString().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out dValue);

                if ((int)dValue == -1)
                {
                    return -1;
                }

                //double dParameter;
                //double.TryParse(parameter.ToString().Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out dParameter);

                var res = dValue * Coefficient;

                Debug.WriteLine("RatioConverter: dValue: " + dValue);
                Debug.WriteLine("RatioConverter: coefficient: " + Coefficient);
                Debug.WriteLine("RatioConverter: res: " + res);

                return res;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}