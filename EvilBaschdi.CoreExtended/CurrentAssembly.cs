using System.Reflection;
using System.Windows;

namespace EvilBaschdi.CoreExtended
{
    /// <inheritdoc />
    public class CurrentAssembly : ICurrentAssembly
    {
        /// <inheritdoc />
        public Assembly Value
        {
            get
            {
                if (Application.Current?.MainWindow == null)
                {
                    return null;
                }

                var mainWindow = Application.Current?.MainWindow;
                return mainWindow.GetType().Assembly;
            }
        }
    }
}