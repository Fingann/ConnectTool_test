using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ConnectTool.Helpers.Enum;

namespace ConnectTool.Helpers.Converters
{
    class PopupMessageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var category = parameter as PopupMessageCategory? ?? PopupMessageCategory.Unknown;

            switch (category)
            {
                    case PopupMessageCategory.Unknown:
                    return "UNKNOWN:";
                    case PopupMessageCategory.Info:
                    return "INFO:";
                    
                    case PopupMessageCategory.Exception:
                    return "EXCEPTION:";
                    case  PopupMessageCategory.Warning:
                    return "WARNING:";

                default:
                    return "UNKNOWN:";

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
