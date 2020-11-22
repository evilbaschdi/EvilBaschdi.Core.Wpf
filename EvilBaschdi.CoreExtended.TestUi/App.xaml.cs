using System.Windows;
using ControlzEx.Theming;

namespace EvilBaschdi.CoreExtended.TestUi
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            ThemeManager.Current.SyncTheme(ThemeSyncMode.SyncAll);

            base.OnStartup(e);
        }
    }
}