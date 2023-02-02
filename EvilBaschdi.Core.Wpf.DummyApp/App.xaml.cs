using System.Windows;
using ControlzEx.Theming;

namespace EvilBaschdi.Core.Wpf.DummyApp;

/// <inheritdoc />
/// <summary>
///     Interaction logic for App.xaml
/// </summary>
// ReSharper disable once RedundantExtendsListEntry
public partial class App : Application
{
    /// <inheritdoc />
    protected override void OnStartup(StartupEventArgs e)
    {
        if (e == null)
        {
            throw new ArgumentNullException(nameof(e));
        }

        ThemeManager.Current.SyncTheme(ThemeSyncMode.SyncAll);
    }
}