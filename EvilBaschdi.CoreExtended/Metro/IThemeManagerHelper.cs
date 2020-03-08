using System.Windows;
using System.Windows.Media;

namespace EvilBaschdi.CoreExtended.Metro
{
    /// <summary>
    ///     ThemeManagerHelper
    /// </summary>
    public interface IThemeManagerHelper
    {
        /// <summary>
        ///     Creates a new app style by color and name.
        /// </summary>
        /// <param name="accentBaseColor">Color to create app style for.</param>
        /// <param name="accentName">Name of the new app style.</param>
        void CreateThemeFor(Color accentBaseColor, string accentName);

        /// <summary>
        ///     Gets Color of current (applied) system applicationStyleSettings, generates an app style and adds it to available
        ///     accents.
        /// </summary>
        void RegisterSystemColorTheme();

        /// <summary>
        ///     Set System color theme
        /// </summary>
        /// <param name="window"></param>
        void SetSystemColorTheme(Window window);
    }
}