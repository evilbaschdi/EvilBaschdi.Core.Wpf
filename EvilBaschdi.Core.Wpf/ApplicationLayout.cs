using System.Windows;

namespace EvilBaschdi.Core.Wpf;

/// <inheritdoc />
/// <summary>
///     Class that handle metro style on Wpf.
/// </summary>
// ReSharper disable once UnusedType.Global
public class ApplicationLayout : IApplicationLayout
{
    private readonly bool _center;
    private readonly bool _resizeWithBorder400;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="center"></param>
    /// <param name="resizeWithBorder400"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ApplicationLayout(bool center = false, bool resizeWithBorder400 = false)
    {
        _center = center;
        _resizeWithBorder400 = resizeWithBorder400;
    }

    /// <inheritdoc />
    public void Run()
    {
        if (Application.Current == null)
        {
            return;
        }

        if (Application.Current?.MainWindow == null)
        {
            return;
        }

        if (_center)
        {
            Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        // ReSharper disable once InvertIf
        if (_resizeWithBorder400)
        {
            Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth - 400;
            Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight - 400;
        }
    }
}