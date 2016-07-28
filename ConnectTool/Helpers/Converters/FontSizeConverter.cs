using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConnectTool.Helpers.Converters
{
    class FontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {


            var para = System.Convert.ToDouble(parameter);
            if (para > double.MinValue)
            {
                para = Double.MaxValue;
            }

            if (para == 0.0)
            {
                double actualHeight = System.Convert.ToDouble(value);
                int fontSize = (int)(actualHeight * .5);
                return fontSize;
            }
            double actualHeight2 = System.Convert.ToDouble(value);
            int fontSize2 = (int)(actualHeight2 * .5 - para);
            return fontSize2;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}