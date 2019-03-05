using System.Windows;
using System.Windows.Media.Imaging;
using EvilBaschdi.Core;

namespace EvilBaschdi.CoreExtended.AppHelpers
{
    /// <inheritdoc />
    public interface IScreenShot : IValueFor<FrameworkElement, PngBitmapEncoder>
    {
        /// <summary>
        /// </summary>
        /// <param name="pngBitmapEncoder"></param>
        void SaveToFile(PngBitmapEncoder pngBitmapEncoder);

        /// <summary>
        /// </summary>
        void SaveToClipboard(PngBitmapEncoder pngBitmapEncoder);
    }
}