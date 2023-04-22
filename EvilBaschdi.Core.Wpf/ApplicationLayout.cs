using System.Windows;

namespace EvilBaschdi.Core.Wpf;

/// <inheritdoc />
/// <summary>
///     Class that handle metro style on Wpf.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ApplicationLayout : IApplicationLayout
{
    /// <inheritdoc />
    public void RunFor((bool Center, bool ResizeWithBorder400) value)
    {
        if (Application.Current == null)
        {
            return;
        }

        if (Application.Current?.MainWindow == null)
        {
            return;
        }

        var (center, resizeWithBorder400) = value;
        var mainWindow = Application.Current.MainWindow;

        if (mainWindow != null)
        {
            RunFor((mainWindow, center, resizeWithBorder400));
        }
    }

    /// <inheritdoc />
    public void RunFor((Window Window, bool Center, bool ResizeWithBorder400) value)
    {
        var (window, center, resizeWithBorder400) = value;
        if (center)
        {
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        // ReSharper disable once InvertIf
        if (resizeWithBorder400)
        {
            window.Width = SystemParameters.PrimaryScreenWidth - 400;
            window.Height = SystemParameters.PrimaryScreenHeight - 400;
        }
    }
}