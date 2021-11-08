using System;
using System.Windows;
using JetBrains.Annotations;
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
        private readonly bool _center;
        private readonly bool _resizeWithBorder400;
        private readonly IRoundCorners _roundCorners;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="roundCorners"></param>
        /// <param name="center"></param>
        /// <param name="resizeWithBorder400"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApplicationStyle([NotNull] IRoundCorners roundCorners, bool center = false, bool resizeWithBorder400 = false)
        {
            _roundCorners = roundCorners ?? throw new ArgumentNullException(nameof(roundCorners));
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

            foreach (Window currentWindow in Application.Current.Windows)
            {
                if (currentWindow is not MetroWindow metroWindow)
                {
                    continue;
                }

                metroWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
                _roundCorners.RunFor(metroWindow);
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
}