using System.Collections;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls.Primitives;
using EvilBaschdi.Core.Internal;
using EvilBaschdi.CoreExtended;
using EvilBaschdi.CoreExtended.Browsers;
using MahApps.Metro.Controls;
using TestUi.ViewModel;

namespace TestUi
{
    /// <inheritdoc cref="MetroWindow" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly IDialogService _dialogService;

        // ReSharper disable once NotAccessedField.Local
        private readonly IFileListFromPath _filePath;
        private readonly MainWindowViewModel _mainWindowViewModel;


        private INetworkBrowser _networkBrowser;

        public MainWindow()
        {
            InitializeComponent();
            IMultiThreading multiThreading = new MultiThreading();
            _filePath = new FileListFromPath(multiThreading);
            //LoadNetworkBrowserToArrayList();
            //MessageBox.Show(VersionHelper.GetWindowsClientVersion());

            //IAppSettingsBase appSettingsBase = new AppSettingsBase(Settings.Default);
            //IApplicationStyleSettings applicationStyleSettings = new ApplicationStyleSettings(appSettingsBase);
            //IThemeManagerHelper themeManagerHelper = new ThemeManagerHelper();
            //IEncryption encryption = new Encryption();

            //_mainWindowViewModel = new MainWindowViewModel(applicationStyleSettings, themeManagerHelper, encryption);
            //Loaded += MainWindowLoaded;

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
            if (networkBrowserValue != null && networkBrowserValue.Any())
            {
                //UpdateCombo(cboNetwork, networkBrowserValue);
            }
            else
            {
                _dialogService.ShowMessage("Problem :-/", _networkBrowser.Exception.Message);
            }
        }


        private void UpdateCombo(Selector selector, IEnumerable enumerable)
        {
            selector.Items.Clear();
            foreach (string value in enumerable)
            {
                selector.Items.Add(value);
            }

            selector.SelectedIndex = 0;
        }
    }
}