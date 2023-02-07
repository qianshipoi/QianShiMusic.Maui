using System.Globalization;

namespace QianShiMusicClient.Maui.Converters
{
    public class NeteaseImageResourceUrlConverter : IValueConverter
    {
        public static string FormatUrl(string url, string? parameter)
        {
            if (url.StartsWith("http://"))
            {
                url = "https" + url.Substring(4);
            }

            if (url.IndexOf("param=") == -1 && parameter is string param && !string.IsNullOrWhiteSpace(param))
            {
                url += url.IndexOf('?') == -1 ? "?" : "&" + "param=" + param;
            }

            return url;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string url)
            {
                return value;
            }

            return FormatUrl(url, parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
