// ReSharper disable UnusedMember.Global

using System.Windows;
using System.Windows.Media.Imaging;

namespace EvilBaschdi.Core.Wpf.AppHelpers;

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