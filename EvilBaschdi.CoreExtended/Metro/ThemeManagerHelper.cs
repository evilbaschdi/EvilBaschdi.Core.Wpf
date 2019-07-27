using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;
using EvilBaschdi.Core.Extensions;
using EvilBaschdi.CoreExtended.Extensions;
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
        public void CreateAppStyleFor(Color color, string accentName)
        {
            if (accentName == null)
            {
                throw new ArgumentNullException(nameof(accentName));
            }

            var accentColor1 = Color.FromArgb(255, color.R, color.G, color.B);
            var accentColor2 = Color.FromArgb(153, color.R, color.G, color.B);
            var accentColor3 = Color.FromArgb(102, color.R, color.G, color.B);
            var accentColor4 = Color.FromArgb(51, color.R, color.G, color.B);

            var highlightColor = Color.FromArgb(255, color.R.Subtract(30), color.G.Subtract(30), color.B.Subtract(30));
            var idealForegroundColor = IdealTextColor(color);

            foreach (var lightDark in new List<string> { "Light", "Dark" })
            {
                // create a runtime accent resource dictionary
                var resourceDictionary = new ResourceDictionary
                                         {
                                             //Metadata
                                             { "Theme.Name", $"{lightDark}.{accentName}" },
                                             { "Theme.DisplayName", $"{accentName} ({lightDark})" },
                                             { "Theme.BaseColorScheme", lightDark },
                                             { "Theme.ColorScheme", accentName },
                                             { "Theme.ShowcaseBrush", new SolidColorBrush(accentColor1) },
                                             //Theme Base Colors 
                                             { "MahApps.Colors.Highlight", highlightColor },
                                             { "MahApps.Colors.AccentBase", accentColor1 },
                                             { "MahApps.Colors.Accent", accentColor1 },
                                             { "MahApps.Colors.Accent2", accentColor2 },
                                             { "MahApps.Colors.Accent3", accentColor3 },
                                             { "MahApps.Colors.Accent4", accentColor4 },
                                             // Universal Control Brushes
                                             { "MahApps.Brushes.AccentBase", new SolidColorBrush(accentColor1) },
                                             { "MahApps.Brushes.Highlight", new SolidColorBrush(highlightColor) },
                                             { "MahApps.Brushes.Accent", new SolidColorBrush(accentColor1) },
                                             { "MahApps.Brushes.Accent2", new SolidColorBrush(accentColor2) },
                                             { "MahApps.Brushes.Accent3", new SolidColorBrush(accentColor3) },
                                             { "MahApps.Brushes.Accent4", new SolidColorBrush(accentColor4) },
                                             { "MahApps.Brushes.WindowTitle", new SolidColorBrush(accentColor1) },
                                             {
                                                 "ProgressBrush", new LinearGradientBrush(
                                                     new GradientStopCollection(new[]
                                                                                {
                                                                                    new GradientStop(highlightColor, 0),
                                                                                    new GradientStop(accentColor3, 1)
                                                                                }), new Point(1.002, 0.5), new Point(0.001, 0.5))
                                             },
                                             { "MahApps.Brushes.CheckmarkFill", new SolidColorBrush(accentColor1) },
                                             { "MahApps.Brushes.RightArrowFill", new SolidColorBrush(accentColor1) },
                                             { "MahApps.Colors.IdealForeground", idealForegroundColor },
                                             { "MahApps.Brushes.IdealForeground", new SolidColorBrush(idealForegroundColor) },
                                             { "MahApps.Brushes.IdealForegroundDisabled", new SolidColorBrush(idealForegroundColor) },
                                             { "MahApps.Brushes.AccentSelectedColor", new SolidColorBrush(idealForegroundColor) },
                                             // DataGrid brushes
                                             { "MahApps.Brushes.DataGrid.Highlight", new SolidColorBrush(accentColor1) },
                                             { "MahApps.Brushes.DataGrid.HighlightText", new SolidColorBrush(idealForegroundColor) },
                                             { "MahApps.Brushes.DataGrid.MouseOverHighlight", new SolidColorBrush(accentColor3) },
                                             { "MahApps.Brushes.DataGrid.FocusBorder", new SolidColorBrush(accentColor1) },
                                             { "MahApps.Brushes.DataGrid.InactiveSelectionHighlight", new SolidColorBrush(accentColor2) },
                                             { "MahApps.Brushes.DataGrid.InactiveSelectionHighlightText", new SolidColorBrush(idealForegroundColor) },

                                             { "MahApps.Colors.ToggleSwitchButton.OnSwitchBrush.Win10", new SolidColorBrush(accentColor1) },
                                             { "MahApps.Colors.ToggleSwitchButton.OnSwitchMouseOverBrush.Win10", new SolidColorBrush(accentColor2) },
                                             { "MahApps.Colors.ToggleSwitchButton.ThumbIndicatorCheckedBrush.Win10", new SolidColorBrush(idealForegroundColor) }
                                         };


                //accentName = accentName ?? $"RuntimeTheme_{lightDark}_{color.ToString().Replace("#", string.Empty)}";
                //var accentBaseColor = color;
                //var baseColorScheme = lightDark;

                //var generatorParameters = GetGeneratorParameters();
                //var themeTemplateContent = GetThemeTemplateContent();

                //var variant = generatorParameters.BaseColorSchemes.First(x => x.Name == baseColorScheme);
                //var colorScheme = new ColorScheme();
                //colorScheme.Name = accentBaseColor.ToString().Replace("#", string.Empty);
                //var values = colorScheme.Values;
                //values.Add("MahApps.Colors.AccentBase", accentBaseColor.ToString());
                //values.Add("MahApps.Colors.Accent", Color.FromArgb(204, accentBaseColor.R, accentBaseColor.G, accentBaseColor.B).ToString());
                //values.Add("MahApps.Colors.Accent2", Color.FromArgb(153, accentBaseColor.R, accentBaseColor.G, accentBaseColor.B).ToString());
                //values.Add("MahApps.Colors.Accent3", Color.FromArgb(102, accentBaseColor.R, accentBaseColor.G, accentBaseColor.B).ToString());
                //values.Add("MahApps.Colors.Accent4", Color.FromArgb(51, accentBaseColor.R, accentBaseColor.G, accentBaseColor.B).ToString());

                //values.Add("MahApps.Colors.Highlight", accentBaseColor.ToString());
                //values.Add("MahApps.Colors.IdealForeground", IdealTextColor(accentBaseColor).ToString());

                //var xamlContent = new ColorSchemeGenerator().GenerateColorSchemeFileContent(generatorParameters, variant, colorScheme, themeTemplateContent,
                //    $"{lightDark}.{accentName}", $"{accentName} ({lightDark})");

                //var resourceDictionary = (ResourceDictionary) XamlReader.Parse(xamlContent);
                //var newTheme = new Theme(resourceDictionary);
                //ThemeManager.AddTheme(newTheme.Resources);

                // applying theme to MahApps
                var resDictName = $"{lightDark}.{accentName}.xaml";

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
                ThemeManager.AddTheme(resourceDictionary);
            }
        }


        /// <inheritdoc />
        /// <summary>
        ///     Gets Color of current (applied) system applicationStyleSettings, generates an app style and adds it to available
        ///     accents.
        /// </summary>
        public void RegisterSystemColorTheme()
        {
            var dwm = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\DWM");
            var themeManager = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\ThemeManager");
            if (dwm == null || themeManager == null)
            {
                return;
            }

            var colorizationColor = dwm.GetValue("ColorizationColor") != null ? ((int) dwm.GetValue("ColorizationColor")).ToString("X") : string.Empty;
            var colorPrevalence = dwm.GetValue("ColorPrevalence") != null && dwm.GetValue("ColorPrevalence").ToString().Equals("1");
            var themeActive = themeManager.GetValue("ThemeActive") != null && themeManager.GetValue("ThemeActive").ToString().Equals("1");

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

            ThemeManager.IsAutomaticWindowsAppModeSettingSyncEnabled = true;
            ThemeManager.SyncThemeWithWindowsAppModeSetting();
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

        /// <inheritdoc />
        public void SetSystemColorTheme(Window window)

        {
            //foreach (var theme in ThemeManager.Themes)
            //{
            //    var name = theme.DisplayName + " | " + theme.Name;
            //    MessageBox.Show(name);
            //}

            ThemeManager.ChangeTheme(window, "Light.Accent from windows");
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

        //private static string GetThemeTemplateContent()
        //{
        //    using (var stream = typeof(ThemeManager).Assembly.GetManifestResourceStream("MahApps.Metro.Styles.Themes.Theme.Template.xaml"))
        //    {
        //        using (var reader = new StreamReader(stream))
        //        {
        //            return reader.ReadToEnd();
        //        }
        //    }
        //}

        //private static GeneratorParameters GetGeneratorParameters()
        //{
        //    return JsonConvert.DeserializeObject<GeneratorParameters>(GetGeneratorParametersJson());
        //}

        //private static string GetGeneratorParametersJson()
        //{
        //    using (var stream = typeof(ThemeManager).Assembly.GetManifestResourceStream("MahApps.Metro.Styles.Themes.GeneratorParameters.json"))
        //    {
        //        using (var reader = new StreamReader(stream))
        //        {
        //            return reader.ReadToEnd();
        //        }
        //    }
        //}
    }
}