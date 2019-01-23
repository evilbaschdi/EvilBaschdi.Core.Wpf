﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EvilBaschdi.Core.Extensions;
using MahApps.Metro;
using MahApps.Metro.Controls;
using Microsoft.Win32;

namespace EvilBaschdi.CoreExtended.Metro
{
    /// <inheritdoc />
    /// <summary>
    ///     Class that handle metro style on Wpf.
    /// </summary>
    public class ApplicationStyle : IApplicationStyle
    {
        private readonly IApplicationStyleSettings _applicationStyleSettings;
        private readonly MetroWindow _mainWindow;
        private readonly IThemeManagerHelper _themeManagerHelper;

        ///// <summary>
        /////     Accent of Application ApplicationStyle.
        ///// </summary>
        //private Accent _styleAccent = ThemeManager.DetectAppStyle(Application.Current).Item2;

        ///// <summary>
        /////     Theme of Application ApplicationStyle.
        ///// </summary>
        //private AppTheme _styleTheme = ThemeManager.DetectAppStyle(Application.Current).Item1;

        /// <summary>
        ///     Handle metro style by ToggleSwitch.
        /// </summary>
        /// ///
        /// <param name="mainWindow" />
        /// <param name="applicationStyleSettings" />
        /// <param name="themeManagerHelper"></param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="mainWindow" /> is <see langword="null" />.
        ///     <paramref name="applicationStyleSettings" /> is <see langword="null" />.
        ///     <paramref name="themeManagerHelper" /> is <see langword="null" />.
        /// </exception>
        public ApplicationStyle(MetroWindow mainWindow, IApplicationStyleSettings applicationStyleSettings, IThemeManagerHelper themeManagerHelper)
        {
            _mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            _applicationStyleSettings = applicationStyleSettings ?? throw new ArgumentNullException(nameof(applicationStyleSettings));
            _themeManagerHelper = themeManagerHelper ?? throw new ArgumentNullException(nameof(themeManagerHelper));
            Accent = new ComboBox();
            Accent = Accent;
            Theme = new ToggleSwitch();
            Theme = Theme;
        }

        /// <summary>
        ///     Handle metro style by ToggleSwitch.
        /// </summary>
        /// ///
        /// <param name="mainWindow" />
        /// <param name="accent" />
        /// <param name="themeSwitch" />
        /// <param name="applicationStyleSettings" />
        /// <param name="themeManagerHelper"></param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="mainWindow" /> is <see langword="null" />.
        ///     <paramref name="accent" /> is <see langword="null" />.
        ///     <paramref name="themeSwitch" /> is <see langword="null" />.
        ///     <paramref name="applicationStyleSettings" /> is <see langword="null" />.
        ///     <paramref name="themeManagerHelper" /> is <see langword="null" />.
        /// </exception>
        public ApplicationStyle(MetroWindow mainWindow, ComboBox accent, ToggleSwitch themeSwitch, IApplicationStyleSettings applicationStyleSettings,
                                IThemeManagerHelper themeManagerHelper)
        {
            _mainWindow = mainWindow ?? throw new ArgumentNullException(nameof(mainWindow));
            Accent = accent ?? throw new ArgumentNullException(nameof(accent));
            Theme = themeSwitch ?? throw new ArgumentNullException(nameof(themeSwitch));
            _applicationStyleSettings = applicationStyleSettings ?? throw new ArgumentNullException(nameof(applicationStyleSettings));
            _themeManagerHelper = themeManagerHelper ?? throw new ArgumentNullException(nameof(themeManagerHelper));
        }

        /// <inheritdoc />
        /// <summary>
        ///     Load.
        /// </summary>
        /// <param name="center"></param>
        /// <param name="resizeWithBorder400"></param>
        public void Load(bool center = false, bool resizeWithBorder400 = false)
        {
            if (center)
            {
                _mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            if (resizeWithBorder400)
            {
                _mainWindow.Width = SystemParameters.PrimaryScreenWidth - 400;
                _mainWindow.Height = SystemParameters.PrimaryScreenHeight - 400;
            }

            _themeManagerHelper.RegisterSystemColorTheme();

            //if (!string.IsNullOrWhiteSpace(_applicationStyleSettings.Accent))
            //{
            //    _styleAccent = ThemeManager.GetAccent(_applicationStyleSettings.Accent);
            //}

            //if (!string.IsNullOrWhiteSpace(_applicationStyleSettings.Theme))
            //{
            //    _styleTheme = ThemeManager.GetAppTheme(_applicationStyleSettings.Theme);
            //}

            //Accent.SelectedValue = _styleAccent.Name;

            //if (Theme != null)
            //{
            //    switch (_styleTheme.Name)
            //    {
            //        case "BaseDark":
            //            Theme.IsChecked = true;
            //            break;
            //        case "BaseLight":
            //            Theme.IsChecked = false;
            //            break;
            //    }
            //}

            EnableDisableThemeControl();
            LoadSystemAppColor();
            SetStyle();

            foreach (var accent in ThemeManager.Themes.OrderBy(a => a.Name))
            {
                Accent.Items.Add(accent.Name);
            }
        }


        /// <inheritdoc />
        /// <summary>
        ///     Accent of application style.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SetAccent(object sender, SelectionChangedEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            var accent = Accent.SelectedValue.ToString();
            //_styleAccent = ThemeManager.GetAccent(accent);

            EnableDisableThemeControl();
            LoadSystemAppColor();

            SetStyle();
        }

        /// <inheritdoc />
        /// <summary>
        ///     Theme of application style.
        /// </summary>
        /// <param name="sender"></param>
        public void SetTheme(object sender)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            // get the theme from the current application
            //var style = ThemeManager.DetectAppStyle(Application.Current);

            var radiobutton = sender as RadioButton;
            var toggleSwitch = sender as ToggleSwitch;

            //BaseDark, BaseLight
            //var themeName = style.Item1.Name;

            if (radiobutton != null)
                //{
                //    //BaseDark, BaseLight
                //    themeName = $"Base{radiobutton.Name}";
                //}
                //else if (toggleSwitch != null)
                //{
                //    //BaseDark, BaseLight
                //    themeName = toggleSwitch.IsChecked.HasValue && toggleSwitch.IsChecked.Value ? "BaseDark" : "BaseLight";
                //}

                //_styleTheme = ThemeManager.GetAppTheme(themeName);

            {
                SetStyle();
            }
        }

        /// <inheritdoc />
        /// <summary>
        ///     Theme of application style.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="routedEventArgs"></param>
        public void SetTheme(object sender, RoutedEventArgs routedEventArgs)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (routedEventArgs == null)
            {
                throw new ArgumentNullException(nameof(routedEventArgs));
            }

            SetTheme(sender);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Save ApplicationStyle.
        /// </summary>
        public void SaveStyle()
        {
            //_applicationStyleSettings.Accent = _styleAccent.Name;
            //_applicationStyleSettings.Theme = _styleTheme.Name;
        }

        /// <inheritdoc />
        /// <summary>
        ///     ComboBox for choosing an accent.
        /// </summary>
        public ComboBox Accent { get; set; }

        /// <inheritdoc />
        /// <summary>
        ///     ToggleSwitch for choosing a theme.
        /// </summary>
        public ToggleSwitch Theme { get; set; }

        /// <summary>
        ///     Sets ApplicationStyle.
        /// </summary>
        private void SetStyle()
        {
            //ThemeManager.ChangeAppStyle(Application.Current, _styleAccent, _styleTheme);
        }

        private void EnableDisableThemeControl()
        {
            var accent = Accent.SelectedValue.ToString();
            var isWindows10AndSystemStyle = VersionHelper.IsWindows10 && accent == "Accent from windows";
            if (Theme != null)
            {
                Theme.IsEnabled = !isWindows10AndSystemStyle;
            }
        }

        private void LoadSystemAppColor()
        {
            var accent = Accent.SelectedValue.ToString();
            var isWindows10AndSystemStyle = VersionHelper.IsWindows10 && accent == "Accent from windows";
            if (!isWindows10AndSystemStyle)
            {
                return;
            }

            var personalize = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize");
            if (personalize == null)
            {
                return;
            }

            var appsTheme = personalize.GetValue("AppsUseLightTheme") != null && personalize.GetValue("AppsUseLightTheme").ToString().Equals("0")
                ? "BaseDark"
                : "BaseLight";
            if (Theme == null)
            {
                return;
            }

            switch (appsTheme)
            {
                case "BaseDark":
                    Theme.IsChecked = true;
                    break;

                case "BaseLight":
                    Theme.IsChecked = false;
                    break;
                default:
                    Theme.IsChecked = false;
                    break;
            }

            // _styleTheme = ThemeManager.GetAppTheme(appsTheme);
        }
    }
}