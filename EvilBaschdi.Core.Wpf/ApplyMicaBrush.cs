using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using EvilBaschdi.About.Wpf.Enums;
using EvilBaschdi.Core.Wpf.Extensions;

namespace EvilBaschdi.Core.Wpf;

// ReSharper disable once UnusedType.Global
/// <inheritdoc />
public class ApplyMicaBrush : IApplyMicaBrush
{
    /// <summary>
    ///     Sets Windows Color an ApplyMicaBrush effect
    /// </summary>
    /// <param name="hwndSource"></param>
    /// <param name="window"></param>
    // ReSharper disable once MemberCanBePrivate.Global
    public void RunFor([NotNull] HwndSource hwndSource, [NotNull] Window window)
    {
        ArgumentNullException.ThrowIfNull(hwndSource);
        ArgumentNullException.ThrowIfNull(window);

        var darkThemeEnabled = Imports.ShouldSystemUseDarkMode();
        var build = Environment.OSVersion.Version.Build;

        var trueValue = 0x01;
        var falseValue = 0x00;

        var mode = darkThemeEnabled ? trueValue : falseValue;

        // Set dark mode before applying the material, otherwise you'll get an ugly flash when displaying the window.

        _ = Imports.DwmSetWindowAttribute(hwndSource.Handle, DwmWindowAttribute.DWMWA_USE_IMMERSIVE_DARK_MODE, ref mode, Marshal.SizeOf(typeof(int)));

        //before Windows 11 22H2
        if (build < 22523)
        {
            _ = Imports.DwmSetWindowAttribute(hwndSource.Handle, DwmWindowAttribute.DWMWA_MICA_EFFECT, ref trueValue, Marshal.SizeOf(typeof(int)));
        }
        else
        {
            var pvAttribute = (int)DwmWindowAttribute.DWMSBT_MAINWINDOW;
            _ = Imports.DwmSetWindowAttribute(hwndSource.Handle, DwmWindowAttribute.DWMWA_SYSTEMBACKDROP_TYPE, ref pvAttribute, Marshal.SizeOf(typeof(int)));
        }

        window.Background = Brushes.Transparent;
        window.FontFamily = new FontFamily("Segeo UI");
        window.Foreground = darkThemeEnabled ? Brushes.White : Brushes.Black;
    }
}