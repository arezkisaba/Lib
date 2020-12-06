using System;
using System.Globalization;

using Windows.UI.Xaml.Data;

namespace Lib.Uwp
{
    public class DateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var format = parameter as string;
            if (format == null)
            {
                return value;
            }

            var datetime = value as DateTime?;
            if (!datetime.HasValue)
            {
                return value;
            }

            return datetime.Value.ToString(format);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}