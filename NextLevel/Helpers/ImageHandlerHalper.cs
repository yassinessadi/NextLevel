
using System.Globalization;

namespace NextLevel.Helpers
{
	public class ImageHandlerHalper : IValueConverter
    {
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string url = (string)value;
			if (string.IsNullOrEmpty(url))
			{
				return "dotnet_bot.png";
			}
			var source = new UriImageSource()
			{
				Uri = new Uri(url),
				CacheValidity = new TimeSpan(1, 0, 0, 0),
				CachingEnabled = true,
			};
			return source; 
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}

}
