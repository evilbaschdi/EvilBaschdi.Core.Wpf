using System;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using EvilBaschdi.Core.Extensions;
using EvilBaschdi.CoreExtended.Extensions;
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
        public void CreateAppStyleFor(Color color, string accentName)
        {
            if (string.IsNullOrWhiteSpace(accentName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(accentName));
            }

            var accentColor1 = Color.FromArgb(255, color.R, color.G, color.B);
            var accentColor2 = Color.FromArgb(153, color.R, color.G, color.B);
            var accentColor3 = Color.FromArgb(102, color.R, color.G, color.B);
            var accentColor4 = Color.FromArgb(51, color.R, color.G, color.B);
            var highlightColor = Color.FromArgb(255, color.R.Subtract(30), color.G.Subtract(30), color.B.Subtract(30));
            var idealForegroundColor = (int) Math.Sqrt(color.R * color.R * .241 + color.G * color.G * .691 + color.B * color.B * .068) < 130 ? Colors.White : Colors.Black;

            // create a runtime accent resource dictionary
            var resourceDictionary = new ResourceDictionary
                                     {
                                         { "AccentColor", accentColor1 },
                                         { "AccentColor2", accentColor2 },
                                         { "AccentColor3", accentColor3 },
                                         { "AccentColor4", accentColor4 },
                                         { "HighlightColor", highlightColor },
                                         { "HighlightBrush", new SolidColorBrush(highlightColor) },
                                         { "AccentColorBrush", new SolidColorBrush(accentColor1) },
                                         { "AccentColorBrush2", new SolidColorBrush(accentColor2) },
                                         { "AccentColorBrush3", new SolidColorBrush(accentColor3) },
                                         { "AccentColorBrush4", new SolidColorBrush(accentColor4) },
                                         { "WindowTitleColorBrush", new SolidColorBrush(accentColor1) },
                                         {
                                             "ProgressBrush", new LinearGradientBrush(
                                                 new GradientStopCollection(new[]
                                                                            {
                                                                                new GradientStop(highlightColor, 0),
                                                                                new GradientStop(accentColor3, 1)
                                                                            }), new Point(1.002, 0.5), new Point(0.001, 0.5))
                                         },
                                         { "CheckmarkFill", new SolidColorBrush(accentColor1) },
                                         { "RightArrowFill", new SolidColorBrush(accentColor1) },
                                         { "IdealForegroundColor", idealForegroundColor },
                                         { "IdealForegroundColorBrush", new SolidColorBrush(idealForegroundColor) },
                                         { "IdealForegroundDisabledBrush", new SolidColorBrush(idealForegroundColor) },
                                         { "AccentSelectedColorBrush", new SolidColorBrush(idealForegroundColor) },
                                         { "MetroDataGrid.HighlightBrush", new SolidColorBrush(accentColor1) },
                                         { "MetroDataGrid.HighlightTextBrush", new SolidColorBrush(idealForegroundColor) },
                                         { "MetroDataGrid.MouseOverHighlightBrush", new SolidColorBrush(accentColor3) },
                                         { "MetroDataGrid.FocusBorderBrush", new SolidColorBrush(accentColor1) },
                                         { "MetroDataGrid.InactiveSelectionHighlightBrush", new SolidColorBrush(accentColor2) },
                                         { "MetroDataGrid.InactiveSelectionHighlightTextBrush", new SolidColorBrush(idealForegroundColor) }
                                     };


            // applying theme to MahApps
            var resDictName = $"ApplicationAccent_{accentName}.xaml";

            var fileName = Path.Combine(Path.GetTempPath(), resDictName);

            using (var writer = XmlWriter.Create(fileName, new XmlWriterSettings
                                                           {
                                                               Indent = true
                                                           }))
            {
                XamlWriter.Save(resourceDictionary, writer);
                writer.Close();
            }

            resourceDictionary = new ResourceDictionary
                                 {
                                     Source = new Uri(fileName, UriKind.Absolute)
                                 };


            //var newAccent = new Accent
            //                {
            //                    Name = accentName,
            //                    Resources = resourceDictionary
            //                };

            //ThemeManager.AddAccent(newAccent.Name, newAccent.Resources.Source);
        }


        /// <inheritdoc />
        /// <summary>
        ///     Gets Color of current (applied) system applicationStyleSettings, generates an app style and adds it to available
        ///     accents.
        /// </summary>
        public void RegisterSystemColorTheme()
        {
            var dwm = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\DWM");
            var thememanager = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ThemeManager");
            if (dwm == null || thememanager == null)
            {
                return;
            }

            var colorizationColor = dwm.GetValue("ColorizationColor") != null ? ((int) dwm.GetValue("ColorizationColor")).ToString("X") : string.Empty;
            var colorPrevalence = dwm.GetValue("ColorPrevalence") != null && dwm.GetValue("ColorPrevalence").ToString().Equals("1");
            var themeActive = thememanager.GetValue("ThemeActive") != null && thememanager.GetValue("ThemeActive").ToString().Equals("1");

            var accentColor = SystemColors.ActiveCaptionColor;

            if (themeActive && !string.IsNullOrWhiteSpace(colorizationColor))
            {
                accentColor = colorizationColor.ToColor();
            }

            if (VersionHelper.IsWindows10 && !colorPrevalence)
            {
                accentColor = "#FFCCCCCC".ToColor();
            }

            CreateAppStyleFor(accentColor, "Accent from windows");
        }

        /// <inheritdoc />
        public bool? AppUsesLightTheme
        {
            get
            {
                var personalize = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize");
                return personalize == null
                    ? (bool?) null
                    : !(personalize.GetValue("AppsUseLightTheme") != null && personalize.GetValue("AppsUseLightTheme").ToString().Equals("0"));
            }
        }
    }
}