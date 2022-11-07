using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using EvilBaschdi.CoreExtended.Enums;
using static EvilBaschdi.CoreExtended.Extensions.Imports;

namespace EvilBaschdi.CoreExtended.Controls.About;

/// <summary>
///     Interaction logic for AboutWindow.xaml
/// </summary>
// ReSharper disable once UnusedType.Global
public partial class AboutWindow
{
    /// <inheritdoc />
    public AboutWindow([NotNull] IAboutModel aboutModel)
    {
        if (aboutModel == null)
        {
            throw new ArgumentNullException(nameof(aboutModel));
        }

        InitializeComponent();

        Loaded += AboutWindowLoaded;
        DataContext = aboutModel;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private void WindowContentRendered(object sender, EventArgs e)
    {
        // Apply Mica brush
        UpdateStyleAttributes((HwndSource)sender);
    }

    /// <summary>
    ///     Sets Windows Color an Mica effect
    /// </summary>
    /// <param name="hwndSource"></param>
    // ReSharper disable once MemberCanBePrivate.Global
    public static void UpdateStyleAttributes(HwndSource hwndSource)
    {
        var darkThemeEnabled = ShouldSystemUseDarkMode();
        var build = Environment.OSVersion.Version.Build;

        var trueValue = 0x01;
        var falseValue = 0x00;

        var mode = darkThemeEnabled ? trueValue : falseValue;

        // Set dark mode before applying the material, otherwise you'll get an ugly flash when displaying the window.

        DwmSetWindowAttribute(hwndSource.Handle, DwmWindowAttribute.DWMWA_USE_IMMERSIVE_DARK_MODE, ref mode, Marshal.SizeOf(typeof(int)));

        //before Windows 11 22H2
        if (build < 22523)
        {
            DwmSetWindowAttribute(hwndSource.Handle, DwmWindowAttribute.DWMWA_MICA_EFFECT, ref trueValue, Marshal.SizeOf(typeof(int)));
        }
        else
        {
            var pvAttribute = (int)DwmWindowAttribute.DWMSBT_MAINWINDOW;
            DwmSetWindowAttribute(hwndSource.Handle, DwmWindowAttribute.DWMWA_SYSTEMBACKDROP_TYPE, ref pvAttribute, Marshal.SizeOf(typeof(int)));
        }
    }

    private void AboutWindowLoaded(object sender, RoutedEventArgs e)
    {
        // Get PresentationSource
        var presentationSource = PresentationSource.FromVisual((Visual)sender);

        // Subscribe to PresentationSource's ContentRendered event
        if (presentationSource != null)
        {
            presentationSource.ContentRendered += WindowContentRendered;
        }
    }
}