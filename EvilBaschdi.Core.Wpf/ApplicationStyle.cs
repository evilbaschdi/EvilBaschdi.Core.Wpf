using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace EvilBaschdi.Core.Wpf;

/// <inheritdoc />
public class ApplicationStyle : IApplicationStyle
{
    /// <inheritdoc />
    public void Run()
    {
        if (Application.Current == null)
        {
            return;
        }

        foreach (Window currentWindow in Application.Current.Windows)
        {
            if (currentWindow is not MetroWindow metroWindow ||
                metroWindow.MetroDialogOptions == null)
            {
                continue;
            }

            metroWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
        }
    }
}