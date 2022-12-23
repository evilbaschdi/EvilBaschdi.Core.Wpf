using System.Reflection;
using System.Windows;
using EvilBaschdi.About.Core;
using EvilBaschdi.About.Core.Models;
using EvilBaschdi.Core;
using EvilBaschdi.Core.Security;
using EvilBaschdi.CoreExtended.TestUi.ViewModel;
using MahApps.Metro.Controls;

namespace EvilBaschdi.CoreExtended.TestUi;

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
        ICurrentAssembly currentAssembly = new CurrentAssembly();
        IAboutContent aboutContent = new AboutContent(currentAssembly);
        IAboutModel aboutModel = new AboutViewModel(aboutContent);

        _mainWindowViewModel = new(encryption, applicationStyle, aboutModel);
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