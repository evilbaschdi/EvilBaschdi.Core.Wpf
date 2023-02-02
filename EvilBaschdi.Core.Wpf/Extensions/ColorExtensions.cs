using System.Windows.Media;

namespace EvilBaschdi.Core.Wpf.Extensions;

/// <summary>
///     HelperClass to extend Color functionality.
/// </summary>
// ReSharper disable once UnusedType.Global
public static class ColorExtensions
{
    /// <summary>
    ///     Converts hex to Color.
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    // ReSharper disable once UnusedMember.Global
    public static Color ToColor([NotNull] this string hex)
    {
        if (hex == null)
        {
            throw new ArgumentNullException(nameof(hex));
        }

        var value = hex.PadLeft(8, 'F').PadLeft(9, '#');
        var convertFromString = ColorConverter.ConvertFromString(value);
        if (convertFromString != null)
        {
            return (Color)convertFromString;
        }

        return Colors.Black;
    }
}