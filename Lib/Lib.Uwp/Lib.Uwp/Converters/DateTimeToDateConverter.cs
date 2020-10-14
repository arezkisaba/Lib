using System;
using System.Globalization;

#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
#else
using System.Windows.Data;
#endif

namespace Lib.Uwp
{
    public class DateTimeToDateConverter : IValueConverter
    {
#if WINDOWS_UWP
        public object Convert(object value, Type targetType, object parameter, string language)
#else
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
#endif
        {
            var format = "dd/MM/yyyy";
            var datetime = value as DateTime?;
            if (!datetime.HasValue)
            {
                return string.Empty;
            }

            if (parameter != null)
            {
                format = parameter as string;
            }

            var partsFormat = format.Split(" ");
            if (format.Contains("/") && format.Contains(":")) // Date and Time
            {
                return $"{GetShortDayName(datetime.Value, partsFormat[0])} {datetime.Value.ToString(partsFormat[1], CultureInfo.CurrentUICulture)}";
            }
            else if (format.Contains("/") && !format.Contains(":")) // Date only
            {
                return $"{GetShortDayName(datetime.Value, partsFormat[0])}";
            }
            else if (!format.Contains("/") && format.Contains(":")) // Time only
            {
                return $"{datetime.Value.ToString(partsFormat[0], CultureInfo.CurrentUICulture)}";
            }
            else
            {
                return string.Empty;
            }
        }

#if WINDOWS_UWP
        public object ConvertBack(object value, Type targetType, object parameter, string language)
#else
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
#endif
        {
            throw new NotImplementedException();
        }

        private string GetShortDayName(DateTime dateTime, string dateFormat)
        {
            var dateTimeNow = DateTime.Now;
            if (dateTime.DayOfYear == dateTimeNow.DayOfYear && dateTime.Year == dateTimeNow.Year)
            {
                return $"Today";
            }
            else if (dateTime.DayOfYear == dateTimeNow.DayOfYear + 1 && dateTime.Year == dateTimeNow.Year)
            {
                return $"Tomorrow";
            }
            else if (dateTime < dateTimeNow)
            {
                return dateTime.ToString(dateFormat, CultureInfo.CurrentUICulture);
            }
            else
            {
                return dateTime.DayOfWeek.ToString();
            }
        }
    }
}