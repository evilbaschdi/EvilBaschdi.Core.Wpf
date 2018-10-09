using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EvilBaschdi.Core.Extensions;
using EvilBaschdi.CoreExtended.Metro;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;
using EvilBaschdi.CoreExtended.Properties;
using MahApps.Metro;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel
{
    /// <summary>
    ///     ViewModel of ApplicationStyle.
    /// </summary>
    public class ApplicationStyleViewModel : INotifyPropertyChanged
    {
        private readonly IApplicationStyleSettings _applicationStyleSettings;
        private readonly IThemeManagerHelper _themeManagerHelper;
        private bool _appDoesNotUseSystemStyle;
        private bool _appUsesDarkTheme;
        private bool _isWindows10;

        private bool _settingsFlyoutIsOpen;

        //private Accent _styleAccent = ThemeManager.DetectAppStyle(Application.Current).Item2;
        private string _styleAccentName;

        private List<string> _styleAccents;
        // private AppTheme _styleTheme = ThemeManager.DetectAppStyle(Application.Current).Item1;


        /// <summary>
        ///     Constructor
        /// </summary>
        protected ApplicationStyleViewModel(IApplicationStyleSettings applicationStyleSettings, IThemeManagerHelper themeManagerHelper)
        {
            _applicationStyleSettings = applicationStyleSettings ?? throw new ArgumentNullException(nameof(applicationStyleSettings));
            _themeManagerHelper = themeManagerHelper ?? throw new ArgumentNullException(nameof(themeManagerHelper));
            InitializeCommandViewModels();
            Load();
        }

        /// <summary>
        ///     Is true if the app uses the style / accent from the current windows settings
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public bool AppDoesNotUseSystemStyle
        {
            // ReSharper disable once UnusedMember.Global
            get => _appDoesNotUseSystemStyle;
            set
            {
                _appDoesNotUseSystemStyle = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Is true if radio button for dark theme is checked.
        /// </summary>

        // ReSharper disable once MemberCanBePrivate.Global
        public bool AppUsesDarkTheme
        {
            // ReSharper disable once UnusedMember.Global
            get => _appUsesDarkTheme;
            set
            {
                _appUsesDarkTheme = value;
                SetStyle();
                OnPropertyChanged();
            }
        }


        /// <summary>
        ///     CommandViewModel to save the accent and theme of the application.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public ICommandViewModel SaveStyleSettings
        {
            // ReSharper disable once UnusedAutoPropertyAccessor.Global
            get;
            set;
        }


        /// <summary>
        ///     Sets state of settings flyout.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public bool SettingsFlyoutIsOpen
        {
            get => _settingsFlyoutIsOpen;
            set
            {
                _settingsFlyoutIsOpen = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Style accent.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public string StyleAccent
        {
            get => _styleAccentName;
            set
            {
                _styleAccentName = value;
                SetStyle();
                OnPropertyChanged();
            }
        }


        /// <summary>
        ///     Contains a list of style accents.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public List<string> StyleAccents
        {
            get => _styleAccents;
            set
            {
                _styleAccents = value;
                SetStyle();
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Toggle Flyout.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public ICommandViewModel ToggleFlyout
        {
            // ReSharper disable once UnusedAutoPropertyAccessor.Global
            get;
            set;
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        private void InitializeCommandViewModels()
        {
            ToggleFlyout = new DefaultCommand
                           {
                               Command = new RelayCommand(rc => ExecuteToggleFlyout())
                           };

            SaveStyleSettings = new DefaultCommand
                                {
                                    Command = new RelayCommand(rc => SaveStyle())
                                };
        }


        /// <summary>
        ///     Load
        /// </summary>
        private void Load()
        {
            _themeManagerHelper.RegisterSystemColorTheme();
            _isWindows10 = VersionHelper.IsWindows10;

            //if (!string.IsNullOrWhiteSpace(_applicationStyleSettings.Accent))
            //{
            //    _styleAccent = ThemeManager.GetAccent(_applicationStyleSettings.Accent);
            //}

            //if (!string.IsNullOrWhiteSpace(_applicationStyleSettings.Theme))
            //{
            //    _styleTheme = ThemeManager.GetAppTheme(_applicationStyleSettings.Theme);
            //}

            //_styleAccentName = _styleAccent.Name;
            //_appUsesDarkTheme = _styleTheme.Name == "BaseDark";
            SetStyle();
            _styleAccents = ThemeManager.Themes.Select(accent => accent.Name).OrderBy(a => a).ToList();
        }

        /// <summary>
        /// </summary>
        private void SetStyle()
        {
            //_styleAccent = ThemeManager.GetAccent(_styleAccentName);
            //_styleTheme = _styleAccentName != "Accent from windows" ? ThemeManager.GetAppTheme(_appUsesDarkTheme ? "BaseDark" : "BaseLight") : GetStyleThemeFromSystemSettings();
            //OnPropertyChanged(nameof(AppUsesDarkTheme));
            //ThemeManager.ChangeAppStyle(Application.Current, _styleAccent, _styleTheme);
            EnableDisableThemeControl();
        }

        private void EnableDisableThemeControl()
        {
            _appDoesNotUseSystemStyle = !(_isWindows10 && _styleAccentName == "Accent from windows");
            OnPropertyChanged(nameof(AppDoesNotUseSystemStyle));
        }

        //private AppTheme GetStyleThemeFromSystemSettings()
        //{
        //    var isWindows10AndSystemStyle = _isWindows10 && _styleAccentName == "Accent from windows";
        //    if (!isWindows10AndSystemStyle)
        //    {
        //        return _styleTheme;
        //    }

        //    if (!_themeManagerHelper.AppUsesLightTheme.HasValue)
        //    {
        //        return _styleTheme;
        //    }

        //    _appUsesDarkTheme = !_themeManagerHelper.AppUsesLightTheme.Value;
        //    return ThemeManager.GetAppTheme(_appUsesDarkTheme ? "BaseDark" : "BaseLight");
        //}

        /// <summary>
        ///     Save ApplicationStyle.
        /// </summary>
        private void SaveStyle()
        {
            //_applicationStyleSettings.Accent = _styleAccent.Name;
            //_applicationStyleSettings.Theme = _styleTheme.Name;
        }

        /// <summary>
        /// </summary>
        private void ExecuteToggleFlyout()
        {
            SettingsFlyoutIsOpen = !SettingsFlyoutIsOpen;
        }

        /// <summary>
        ///     INotifyPropertyChanged - method to synchronize UI and Property.
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        // ReSharper disable once VirtualMemberNeverOverridden.Global
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}