using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EvilBaschdi.CoreExtended.AppHelpers
{
    /// <inheritdoc />
    public class ScreenShot : IScreenShot
    {
        /// <inheritdoc />
        public PngBitmapEncoder ValueFor(FrameworkElement frameworkElement)
        {
            var bmp = new RenderTargetBitmap((int) frameworkElement.ActualWidth, (int) frameworkElement.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(frameworkElement);


            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));

            return encoder;
        }


        /// <inheritdoc />
        public void SaveToFile(PngBitmapEncoder pngBitmapEncoder)
        {
            if (pngBitmapEncoder == null)
            {
                throw new ArgumentNullException(nameof(pngBitmapEncoder));
            }

            var fs = new FileStream(@"C:\Temp\Screenshot.png", FileMode.Create);
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
}