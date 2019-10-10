using System.Windows.Media;
using MahApps.Metro.IconPacks;

namespace EvilBaschdi.CoreExtended.Converter
{
    /// <summary>
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class PackIconRPGAwesomeImageSourceConverter : PackIconImageSourceConverterBase<PackIconRPGAwesomeKind>
    {
        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="foregroundBrush"></param>
        /// <param name="penThickness"></param>
        /// <returns></returns>
        protected override ImageSource CreateImageSource(object value, Brush foregroundBrush, double penThickness)
        {
            var packIcon = new PackIconRPGAwesome
                           {
                               Kind = (PackIconRPGAwesomeKind) value
                           };

            return InnerCreateImageSource(foregroundBrush, penThickness, packIcon.Data);
        }
    }
}