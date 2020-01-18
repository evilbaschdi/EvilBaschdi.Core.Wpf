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
        /// <param name="path"></param>
        void SaveToFile(PngBitmapEncoder pngBitmapEncoder, string path);

        /// <summary>
        /// </summary>
        void SaveToClipboard(PngBitmapEncoder pngBitmapEncoder);
    }
}