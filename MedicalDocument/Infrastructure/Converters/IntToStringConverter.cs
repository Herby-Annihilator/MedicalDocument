using MedicalDocument.Infrastructure.Converters.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Infrastructure.Converters
{
    public class IntToStringConverter : Converter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int source;
            if (value is int)
                source = (int)value;
            else
                throw new ArgumentException($"Ожидалось число, но получено: {value.GetType()}");
            if (source == 0)
                return "";
            return source.ToString();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string source;
            if (value.GetType() != typeof(string))
                throw new ArgumentException($"Ожидалась строка, но получено: {value.GetType()}");
            source = (string)value;
            if (string.IsNullOrWhiteSpace(source))
                return 0;
            else
                return System.Convert.ToInt32(source);
        }
    }
}
