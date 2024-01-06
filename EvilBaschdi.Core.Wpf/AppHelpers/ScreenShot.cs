using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EvilBaschdi.Core.Wpf.AppHelpers;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public class ScreenShot : IScreenShot
{
    /// <inheritdoc />
    public PngBitmapEncoder ValueFor([NotNull] FrameworkElement frameworkElement)
    {
        ArgumentNullException.ThrowIfNull(frameworkElement);

        var bmp = new RenderTargetBitmap((int)frameworkElement.ActualWidth, (int)frameworkElement.ActualHeight,
            96, 96, PixelFormats.Pbgra32);
        bmp.Render(frameworkElement);

        var encoder = new PngBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(bmp));

        return encoder;
    }

    /// <inheritdoc />
    public void SaveToFile([NotNull] PngBitmapEncoder pngBitmapEncoder,
                           [NotNull] string path = @"C:\Temp\Screenshot.png")
    {
        ArgumentNullException.ThrowIfNull(pngBitmapEncoder);
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(pngBitmapEncoder);

        var fs = new FileStream(path, FileMode.Create);
        pngBitmapEncoder.Save(fs);
        fs.Close();
    }

    /// <inheritdoc />
    public void SaveToClipboard([NotNull] PngBitmapEncoder pngBitmapEncoder)
    {
        ArgumentNullException.ThrowIfNull(pngBitmapEncoder);

        Clipboard.SetImage(pngBitmapEncoder.Frames[0]);
    }
}