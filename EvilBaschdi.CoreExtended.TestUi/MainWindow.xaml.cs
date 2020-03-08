using System.Collections;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using EvilBaschdi.Core.Internal;
using EvilBaschdi.Core.Security;
using EvilBaschdi.CoreExtended.Browsers;
using EvilBaschdi.CoreExtended.Metro;
using EvilBaschdi.CoreExtended.TestUi.ViewModel;
using MahApps.Metro.Controls;

namespace EvilBaschdi.CoreExtended.TestUi
{
    /// <inheritdoc cref="MetroWindow" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly IDialogService _dialogService;

        // ReSharper disable once NotAccessedField.Local
        private readonly MainWindowViewModel _mainWindowViewModel;


        private INetworkBrowser _networkBrowser;

        public MainWindow()
        {
            InitializeComponent();
            IMultiThreading multiThreading = new MultiThreading();
            
            
            //MessageBox.Show(VersionHelper.GetWindowsClientVersion());
            IThemeManagerHelper themeManagerHelper = new ThemeManagerHelper();
            IEncryption encryption = new Encryption();

            _mainWindowViewModel = new MainWindowViewModel(encryption, themeManagerHelper);
            Loaded += MainWindowLoaded;
            _dialogService = new DialogService(this);

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

            LoadNetworkBrowserToArrayList();
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = _mainWindowViewModel;
        }

        // ReSharper disable once UnusedMember.Local
        private void LoadNetworkBrowserToArrayList()
        {
            _networkBrowser = new NetworkBrowser();

            var networkBrowserValue = _networkBrowser.Value;
            if (networkBrowserValue != null)
            {
                UpdateCombo(cboNetwork, networkBrowserValue);
            }
            else
            {
                _dialogService.ShowMessage("Problem :-/", _networkBrowser.Exception?.Message);
            }
        }


        private void UpdateCombo(Selector selector, IEnumerable enumerable)
        {
            selector.Items.Clear();
            
            foreach (var item in enumerable)
            {
                selector.Items.Add(item);
            }

            selector.SelectedIndex = 0;
        }
    }
}