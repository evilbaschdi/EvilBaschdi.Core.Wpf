using System.Reflection;
using System.Windows;

namespace EvilBaschdi.Core.Wpf;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
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
            return mainWindow?.GetType().Assembly;
        }
    }
}