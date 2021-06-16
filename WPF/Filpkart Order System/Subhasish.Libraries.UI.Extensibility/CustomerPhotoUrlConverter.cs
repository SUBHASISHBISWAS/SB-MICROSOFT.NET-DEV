using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Subhasish.Libraries.UI.Extensibility
{
    public class CustomerPhotoUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageUri = default(Uri);
            if (value != default(object))
            {
                var photosFolder = ConfigurationManager.AppSettings["PhotosFolder"];

                imageUri = new Uri(string.Format(@"{0}/{1}.jpg",
                    photosFolder, value.ToString()));
            }

            return imageUri;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
