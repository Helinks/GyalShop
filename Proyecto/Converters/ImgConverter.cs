using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Proyecto.Converters
{
    public class ImgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            string ruta = value.ToString();

            if (string.IsNullOrWhiteSpace(ruta))
                return null;

            try
            {
                string rutaAbsoluta = ruta;

                if (!Path.IsPathRooted(rutaAbsoluta))
                {
                    rutaAbsoluta = Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        ruta.Replace("/", Path.DirectorySeparatorChar.ToString())
                    );
                }

                if (!File.Exists(rutaAbsoluta))
                    return null;

                BitmapImage bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.UriSource = new Uri(rutaAbsoluta, UriKind.Absolute);
                bitmap.EndInit();

                return bitmap;
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}