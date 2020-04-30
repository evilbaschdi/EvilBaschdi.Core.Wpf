using System.Windows;

namespace EvilBaschdi.CoreExtended.Metro
{
    /// <inheritdoc />
    /// <summary>
    ///     Class that handle metro style on Wpf.
    /// </summary>
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
            if (Application.Current.MainWindow == null)
            {
                return;
            }

            if (center)
            {
                Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            if (!resizeWithBorder400)
            {
                return;
            }

            Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth - 400;
            Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight - 400;
        }
    }
}