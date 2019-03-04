using System;
using System.Windows;

namespace EvilBaschdi.CoreExtended.Metro
{
    /// <inheritdoc />
    /// <summary>
    ///     Class that handle metro style on Wpf.
    /// </summary>
    public class ApplicationStyle : IApplicationStyle
    {
        private readonly IThemeManagerHelper _themeManagerHelper;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="themeManagerHelper"></param>
        public ApplicationStyle(IThemeManagerHelper themeManagerHelper)
        {
            _themeManagerHelper = themeManagerHelper ?? throw new ArgumentNullException(nameof(themeManagerHelper));
        }

        /// <inheritdoc />
        /// <summary>
        ///     Load.
        /// </summary>
        /// <param name="center"></param>
        /// <param name="resizeWithBorder400"></param>
        public void Load(bool center = false, bool resizeWithBorder400 = false)
        {
            if (Application.Current.MainWindow != null)
            {
                if (center)
                {
                    Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                }

                if (resizeWithBorder400)
                {
                    Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth - 400;
                    Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight - 400;
                }
            }

            foreach (Window currentWindow in Application.Current.Windows)
            {
                _themeManagerHelper.SetSystemColorTheme(currentWindow);
            }
        }
    }
}