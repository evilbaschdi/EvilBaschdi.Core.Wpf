using System.Windows.Media;

namespace EvilBaschdi.CoreExtended.Extensions
{
    /// <summary>
    ///     HelperClass to extend Color functionality.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        ///     Converts hex to Color.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static Color ToColor(this string hex)
        {
            var value = hex.PadLeft(8, 'F').PadLeft(9, '#');
            var convertFromString = ColorConverter.ConvertFromString(value);
            if (convertFromString != null)
            {
                return (Color) convertFromString;
            }

            return Colors.Black;
        }
    }
}