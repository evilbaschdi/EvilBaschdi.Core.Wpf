using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using EvilBaschdi.CoreExtended.Extensions;
using JetBrains.Annotations;
using MahApps.Metro;
using Microsoft.Win32;
using Newtonsoft.Json;
using XamlColorSchemeGenerator;
using ColorScheme = XamlColorSchemeGenerator.ColorScheme;

namespace EvilBaschdi.CoreExtended.Metro
{
    /// <inheritdoc />
    public class ThemeManagerHelper : IThemeManagerHelper
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new app style by color and name.
        /// </summary>
        /// <param name="accentBaseColor">Color to create app style for.</param>
        /// <param name="accentName">Name of the new app style.</param>
        public void CreateThemeFor(Color accentBaseColor, [NotNull] string accentName)
        {
            if (accentName == null)
            {
                throw new ArgumentNullException(nameof(accentName));
            }

            var generatorParameters = GetGeneratorParameters();
            var themeTemplateContent = GetThemeTemplateContent();
            var baseColorSchemes = generatorParameters.BaseColorSchemes;

            foreach (var variant in baseColorSchemes)
            {
                var baseColorScheme = variant.Name;
                var themeName = $"{baseColorScheme}.{accentName}";
                var displayName = $"{accentName} ({baseColorScheme})";

                var colorScheme = new ColorScheme
                                  {
                                      Name = accentName
                                  };
                var values = colorScheme.Values;

                values.Add("MahApps.Colors.Accent", Color.FromArgb(204, accentBaseColor.R, accentBaseColor.G, accentBaseColor.B).ToString());
                values.Add("MahApps.Colors.Accent2", Color.FromArgb(153, accentBaseColor.R, accentBaseColor.G, accentBaseColor.B).ToString());
                values.Add("MahApps.Colors.Accent3", Color.FromArgb(102, accentBaseColor.R, accentBaseColor.G, accentBaseColor.B).ToString());
                values.Add("MahApps.Colors.Accent4", Color.FromArgb(51, accentBaseColor.R, accentBaseColor.G, accentBaseColor.B).ToString());
                values.Add("MahApps.Colors.AccentBase", accentBaseColor.ToString());
                values.Add("MahApps.Colors.Highlight", accentBaseColor.ToString());
                values.Add("MahApps.Colors.IdealForeground", IdealTextColor(accentBaseColor).ToString());

                var xamlContent = new ColorSchemeGenerator().GenerateColorSchemeFileContent(generatorParameters, variant, colorScheme, themeTemplateContent, themeName,
                    displayName);

                xamlContent = FixXamlReaderBug(xamlContent);

                var resourceDictionary = (ResourceDictionary) XamlReader.Parse(xamlContent);
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
            CreateThemeFor(AccentColor(), "AccentFromWindows");

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

            var baseColor = AppsUseLightTheme()
                ? "light"
                : "dark";
            //bug: CreateThemeFor currently is not able to create a theme that switches between light and dark
            ThemeManager.ChangeTheme(window, $"{baseColor}.AccentFromWindows");
        }

        private static bool AppsUseLightTheme()
        {
            try
            {
                var registryValue = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", true);
                return registryValue.IsNull()
                       || Convert.ToBoolean(registryValue);
            }
            catch (Exception exception)
            {
                Trace.WriteLine(exception);
            }

            return true;
        }

        private Color AccentColor()
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
        private Color IdealTextColor(Color color)
        {
            const int nThreshold = 105;
            var bgDelta = Convert.ToInt32((color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114));
            var foreColor = 255 - bgDelta < nThreshold
                ? Colors.Black
                : Colors.White;
            return foreColor;
        }


        private string FixXamlReaderBug(string xamlContent)
        {
            // Check if we have to fix something
            if (!xamlContent.Contains("WithAssembly=\""))
            {
                return xamlContent;
            }

            var withAssemblyMatches = Regex.Matches(xamlContent, @"\s*xmlns:(.+?)WithAssembly=("".+?"")");

            foreach (Match withAssemblyMatch in withAssemblyMatches)
            {
                var originalMatches = Regex.Matches(xamlContent, $@"\s*xmlns:({withAssemblyMatch.Groups[1].Value})=("".+?"")");
                foreach (Match originalMatch in originalMatches)
                {
                    xamlContent = xamlContent.Replace(originalMatch.Groups[2].Value, withAssemblyMatch.Groups[2].Value);
                }
            }

            return xamlContent;
        }

        private string GetThemeTemplateContent()
        {
            using var stream = typeof(ThemeManager).Assembly.GetManifestResourceStream("MahApps.Metro.Styles.Themes.Theme.Template.xaml");
            if (stream == null)
            {
                throw new Exception("MahApps.Metro.Styles.Themes.Theme.Template.xaml null");
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private GeneratorParameters GetGeneratorParameters()
        {
            return JsonConvert.DeserializeObject<GeneratorParameters>(GetGeneratorParametersJson());
        }

        private string GetGeneratorParametersJson()
        {
            using var stream = typeof(ThemeManager).Assembly.GetManifestResourceStream("MahApps.Metro.Styles.Themes.GeneratorParameters.json");
            if (stream == null)
            {
                throw new Exception("MahApps.Metro.Styles.Themes.GeneratorParameters.json null");
            }

            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}