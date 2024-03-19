using System;
using System.Globalization;
using System.Windows.Data;

namespace CurrencyToWordsApp.Converters
{
    public class EmptyTextLengthToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null ||  value is not int  length  || length == 0)
                return false;

            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
