using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using JetBrains.Annotations;

namespace EvilBaschdi.CoreExtended.AppHelpers;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public class ScreenShot : IScreenShot
{
    /// <inheritdoc />
    public PngBitmapEncoder ValueFor([NotNull] FrameworkElement frameworkElement)
    {
        if (frameworkElement == null)
        {
            throw new ArgumentNullException(nameof(frameworkElement));
        }

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
        if (pngBitmapEncoder == null)
        {
            throw new ArgumentNullException(nameof(pngBitmapEncoder));
        }

        if (path == null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (pngBitmapEncoder == null)
        {
            throw new ArgumentNullException(nameof(pngBitmapEncoder));
        }

        var fs = new FileStream(path, FileMode.Create);
        pngBitmapEncoder.Save(fs);
        fs.Close();
    }

    /// <inheritdoc />
    public void SaveToClipboard(PngBitmapEncoder pngBitmapEncoder)
    {
        if (pngBitmapEncoder == null)
        {
            throw new ArgumentNullException(nameof(pngBitmapEncoder));
        }

        Clipboard.SetImage(pngBitmapEncoder.Frames[0]);
    }
}