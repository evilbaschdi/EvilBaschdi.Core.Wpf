using System.Windows;
using System.Windows.Controls;
using MahApps.Metro;
using MahApps.Metro.Controls;

namespace EvilBaschdi.TestUi.New
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        IThemeManagerHelper _themeManagerHelper;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            _themeManagerHelper = new ThemeManagerHelper();
            _themeManagerHelper.RegisterSystemColorTheme();

            //ThemeManager.IsAutomaticWindowsAppModeSettingSyncEnabled = true;
            //ThemeManager.SyncThemeWithWindowsAppModeSetting();

            foreach (var theme in ThemeManager.Themes)
            {
                //ColorScheme = Accent (Crimson)
                //BaseColorScheme = Theme of current ColorScheme (Dark, Light)
                //Name = Theme.Accent / BaseColorScheme.ColorScheme (Dark.Crimson)
                ThemesComboBox.Items.Add(theme.Name);
            }
        }


        private void ThemesComboBoxOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show(ThemesComboBox.SelectedValue.ToString());
            ThemeManager.ChangeTheme(this, ThemesComboBox.SelectedValue.ToString());
            var appUsesLightTheme = _themeManagerHelper.AppUsesLightTheme;
            var lightDark = appUsesLightTheme.HasValue && appUsesLightTheme.Value ? "Light" : "Dark";
            ThemeManager.ChangeThemeBaseColor(this, lightDark);
        }
    }
}