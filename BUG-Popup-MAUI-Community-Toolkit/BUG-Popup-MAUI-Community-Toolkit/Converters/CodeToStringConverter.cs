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
    public class CodeToStringConverter : IValueConverter
    {

        private static bool _isEnabled = true;
        public static void Resume(Type type)
        {
            _isEnabled = true;
        }

        public static void Suspend(Type type)
        {
            _isEnabled = false;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (_isEnabled)
            {
                if (value is int)
                {
                    string _codeSTR = "";
                    int _code = (int)value;
                    if (_code == 0) { return string.Empty; }
                    if (_code < 10) _codeSTR = "0" + _code.ToString();
                    else _codeSTR = _code.ToString();
                    return _codeSTR;
                }
                return string.Empty;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
                if (value is string)
                {
                    int _code = 0;
                    string _codeSTR = (string)value;
                    if (int.TryParse(_codeSTR, result: out _code)) { return _code; }
                }
                return 0;
            
            
        }
    }
}
