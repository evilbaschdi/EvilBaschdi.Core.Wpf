using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace EvilBaschdi.CoreExtended
{
    /// <inheritdoc />
    /// <summary>
    ///     Class that handle metro style on Wpf.
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class ApplicationStyle : IApplicationStyle
    {
        /// <inheritdoc />
        /// <summary>
        ///     Load.
        /// </summary>
        /// <param name="center"></param>
        /// <param name="resizeWithBorder400"></param>
        public void Load(bool center = false, bool resizeWithBorder400 = false)
        {
            foreach (Window currentWindow in Application.Current.Windows)
            {
                if (currentWindow is MetroWindow metroWindow)
                {
                    metroWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
                }
            }

            if (Application.Current.MainWindow == null)
            {
                return;
            }

            if (center)
            {
                Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            // ReSharper disable once InvertIf
            if (resizeWithBorder400)
            {
                Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth - 400;
                Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight - 400;
            }
        }
    }
}