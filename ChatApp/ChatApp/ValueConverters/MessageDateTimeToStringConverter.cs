using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ChatApp.ValueConverters
{
    /// <summary>
    /// Converst message datetime to string.
    /// </summary>
    public class MessageDateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dateTime = value as DateTime?;
            if (dateTime == null) return null;

            //logic for datetime
            return ((DateTime)dateTime).DayOfWeek.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
