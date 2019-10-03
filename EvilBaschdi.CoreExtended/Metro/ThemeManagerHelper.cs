using System;
using System.Windows;
using System.Windows.Media;
using EvilBaschdi.CoreExtended.Extensions;
using JetBrains.Annotations;
using MahApps.Metro;
using Microsoft.Win32;

namespace EvilBaschdi.CoreExtended.Metro
{
    /// <inheritdoc />
    public class ThemeManagerHelper : IThemeManagerHelper
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new app style by color and name.
        /// </summary>
        /// <param name="color">Color to create app style for.</param>
        /// <param name="accentName">Name of the new app style.</param>
        public void CreateThemeFor(Color color, [NotNull] string accentName)
        {
            if (accentName == null)
            {
                throw new ArgumentNullException(nameof(accentName));
            }

            var accentColor1 = Color.FromArgb(255, color.R, color.G, color.B);
            var accentColor2 = Color.FromArgb(153, color.R, color.G, color.B);
            var accentColor3 = Color.FromArgb(102, color.R, color.G, color.B);
            var accentColor4 = Color.FromArgb(51, color.R, color.G, color.B);

            var accentColorBrush1 = new SolidColorBrush(accentColor1);
            var accentColorBrush2 = new SolidColorBrush(accentColor2);
            var accentColorBrush3 = new SolidColorBrush(accentColor3);
            var accentColorBrush4 = new SolidColorBrush(accentColor4);

            var highlightColor = Color.FromArgb(255, color.R.Subtract(30), color.G.Subtract(30), color.B.Subtract(30));
            var highlightColorBrush = new SolidColorBrush(highlightColor);
            var idealForegroundColor = IdealTextColor(color);
            var idealForegroundColorBrush = new SolidColorBrush(idealForegroundColor);


            foreach (var baseColor in ThemeManager.BaseColors)
            {
                // create a runtime accent resource dictionary
                var resourceDictionary = new ResourceDictionary
                                         {
                                             //Metadata
                                             { "Theme.Name", $"{baseColor}.{accentName}" },
                                             { "Theme.DisplayName", $"{accentName} ({baseColor})" },
                                             { "Theme.BaseColorScheme", baseColor },
                                             { "Theme.ColorScheme", accentName },
                                             { "Theme.ShowcaseBrush", accentColorBrush1 },
                                             //Theme Base Colors 
                                             { "MahApps.Colors.Highlight", highlightColor },
                                             { "MahApps.Colors.AccentBase", accentColor1 },
                                             { "MahApps.Colors.Accent", accentColor1 },
                                             { "MahApps.Colors.Accent2", accentColor2 },
                                             { "MahApps.Colors.Accent3", accentColor3 },
                                             { "MahApps.Colors.Accent4", accentColor4 },
                                             // Universal Control Brushes
                                             { "MahApps.Brushes.AccentBase", accentColorBrush1 },
                                             { "MahApps.Brushes.Highlight", highlightColorBrush },
                                             { "MahApps.Brushes.Accent", accentColorBrush1 },
                                             { "MahApps.Brushes.Accent2", accentColorBrush2 },
                                             { "MahApps.Brushes.Accent3", accentColorBrush3 },
                                             { "MahApps.Brushes.Accent4", accentColorBrush4 },
                                             { "MahApps.Brushes.WindowTitle", accentColorBrush1 },
                                             {
                                                 "ProgressBrush", new LinearGradientBrush(
                                                     new GradientStopCollection(new[]
                                                                                {
                                                                                    new GradientStop(highlightColor, 0),
                                                                                    new GradientStop(accentColor3, 1)
                                                                                }), new Point(1.002, 0.5), new Point(0.001, 0.5))
                                             },
                                             { "MahApps.Brushes.CheckmarkFill", accentColorBrush1 },
                                             { "MahApps.Brushes.RightArrowFill", accentColorBrush1 },
                                             { "MahApps.Colors.IdealForeground", idealForegroundColor },
                                             { "MahApps.Brushes.IdealForeground", idealForegroundColorBrush },
                                             { "MahApps.Brushes.IdealForegroundDisabled", idealForegroundColorBrush },
                                             { "MahApps.Brushes.AccentSelectedColor", idealForegroundColorBrush },
                                             // DataGrid brushes
                                             { "MahApps.Brushes.DataGrid.Highlight", accentColorBrush1 },
                                             { "MahApps.Brushes.DataGrid.HighlightText", idealForegroundColorBrush },
                                             { "MahApps.Brushes.DataGrid.MouseOverHighlight", accentColorBrush3 },
                                             { "MahApps.Brushes.DataGrid.FocusBorder", accentColorBrush1 },
                                             { "MahApps.Brushes.DataGrid.InactiveSelectionHighlight", accentColorBrush2 },
                                             { "MahApps.Brushes.DataGrid.InactiveSelectionHighlightText", idealForegroundColorBrush },
                                             // ToggleSwitchButton Colors
                                             { "MahApps.Colors.ToggleSwitchButton.OnSwitchBrush.Win10", accentColorBrush1 },
                                             { "MahApps.Colors.ToggleSwitchButton.OnSwitchMouseOverBrush.Win10", accentColorBrush2 },
                                             { "MahApps.Colors.ToggleSwitchButton.ThumbIndicatorCheckedBrush.Win10", idealForegroundColorBrush }
                                         };


                var newTheme = new Theme(resourceDictionary);
                ThemeManager.AddTheme(newTheme.Resources);
            }
        }

        /// <inheritdoc />
        /// <summary>
        ///     Gets Color of current (applied) system applicationStyleSettings, generates an app style and adds it to available
        ///     accents.
        /// </summary>
        public void RegisterSystemColorTheme()
        {
            CreateThemeFor(AccentColor(), "Accent from windows");

            ThemeManager.IsAutomaticWindowsAppModeSettingSyncEnabled = true;
            ThemeManager.SyncThemeWithWindowsAppModeSetting();
        }

        /// <inheritdoc />
        public void SetSystemColorTheme([NotNull] Window window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            ThemeManager.ChangeTheme(window, "Light.Accent from windows");
        }

        private static Color AccentColor()
        {
            var accentColor = "#FFCCCCCC".ToColor();
            var dwm = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\DWM");
            var themeManager = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ThemeManager");
            if (dwm == null || themeManager == null)
            {
                return accentColor;
            }

            var colorizationColor = dwm.GetValue("ColorizationColor") != null ? ((int) dwm.GetValue("ColorizationColor")).ToString("X") : string.Empty;
            var themeActive = themeManager.GetValue("ThemeActive") != null && themeManager.GetValue("ThemeActive").ToString().Equals("1");

            if (themeActive && !string.IsNullOrWhiteSpace(colorizationColor))
            {
                accentColor = colorizationColor.ToColor();
            }

            return accentColor;
        }

        /// <summary>
        ///     Determining Ideal Text Color Based on Specified Background Color
        ///     http://www.codeproject.com/KB/GDI-plus/IdealTextColor.aspx
        /// </summary>
        /// <param name="color">The bg.</param>
        /// <returns></returns>
        private static Color IdealTextColor(Color color)
        {
            const int nThreshold = 105;
            var bgDelta = Convert.ToInt32((color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114));
            var foreColor = 255 - bgDelta < nThreshold
                ? Colors.Black
                : Colors.White;
            return foreColor;
        }
    }
}