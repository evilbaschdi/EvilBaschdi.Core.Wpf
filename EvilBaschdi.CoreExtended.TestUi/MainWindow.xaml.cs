using System.Reflection;
using System.Windows;
using EvilBaschdi.Core.Security;
using EvilBaschdi.CoreExtended.Extensions;
using EvilBaschdi.CoreExtended.TestUi.ViewModel;
using MahApps.Metro.Controls;

namespace EvilBaschdi.CoreExtended.TestUi
{
    /// <inheritdoc cref="MetroWindow" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly MainWindowViewModel _mainWindowViewModel;

        /// <summary>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //rounded corners
            //IntPtr hWnd = new WindowInteropHelper(GetWindow(this)).EnsureHandle();
            //var attribute = WindowExtensions.DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
            //var preference = WindowExtensions.DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
            //DwmSetWindowAttribute(hWnd, attribute, ref preference, sizeof(uint));


            IRoundCorners roundCorners = new RoundCorners();
            roundCorners.RunFor(this);
            //rounded corners

            //MessageBox.Show(VersionHelper.GetWindowsClientVersion());
            IEncryption encryption = new Encryption();

            _mainWindowViewModel = new(encryption);
            Loaded += MainWindowLoaded;

            var filePath = Assembly.GetEntryAssembly()?.Location;
            if (filePath != null)
            {
                TestTaskbarIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(filePath);
            }

            //var contextMenu = new ContextMenu();

            //foreach (string accentItem in applicationStyleViewModelCodeBehind.StyleAccents)
            //{
            //    var menuItem = new MenuItem
            //    {
            //        Header = accentItem
            //    };

            //    contextMenu.Items.Add(menuItem);
            //}

            //TestTaskbarIcon.ContextMenu = contextMenu;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = _mainWindowViewModel;
        }
    }

    //public partial class MainWindow
    //{
    //    // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
    //    [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    //    private static extern long DwmSetWindowAttribute(IntPtr hwnd,
    //                                                     WindowExtensions.DWMWINDOWATTRIBUTE attribute,
    //                                                     ref WindowExtensions.DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
    //                                                     uint cbAttribute);
    //}
}