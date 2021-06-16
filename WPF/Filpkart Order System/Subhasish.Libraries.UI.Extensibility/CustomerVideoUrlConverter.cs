using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Subhasish.Libraries.UI.Extensibility
{
    public class CustomerVideoUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var videoUri = default(Uri);

            if (value != default(object))
            {
                var VideosFolder = ConfigurationManager.AppSettings["VideosFolder"];

                videoUri = new Uri(string.Format(@"{0}/Customer Talk ({1}).mp4",
                    VideosFolder, value.ToString()));
            }

            return videoUri;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
