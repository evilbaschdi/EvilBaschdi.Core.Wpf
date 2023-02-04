using System.Reflection;
using System.Windows;
using EvilBaschdi.Core.Security;
using EvilBaschdi.Core.Wpf.DummyApp.ViewModel;
using MahApps.Metro.Controls;

namespace EvilBaschdi.Core.Wpf.DummyApp;

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

        IEncryption encryption = new Encryption();
        IApplicationStyle applicationStyle = new ApplicationStyle(true, true);

        _mainWindowViewModel = new(encryption, applicationStyle);
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