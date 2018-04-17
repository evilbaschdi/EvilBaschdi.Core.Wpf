using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using EvilBaschdi.CoreExtended.Metro;
using EvilBaschdi.CoreExtended.Properties;
using MahApps.Metro;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel
{
    /// <inheritdoc />
    public sealed class ApplicationStyleViewModelCodeBehind : INotifyPropertyChanged
    {
        private readonly IApplicationStyleSettings _applicationStyleSettings;
        private readonly IThemeManagerHelper _themeManagerHelper;
        private Accent _styleAccent = ThemeManager.DetectAppStyle(Application.Current).Item2;
        private AppTheme _styleTheme = ThemeManager.DetectAppStyle(Application.Current).Item1;
        private bool _appUsesDarkTheme;
        private string _styleAccentName;

        /// <summary>
        ///     Constructor
        /// </summary>
        public ApplicationStyleViewModelCodeBehind(IApplicationStyleSettings applicationStyleSettings, IThemeManagerHelper themeManagerHelper)
        {
            _applicationStyleSettings = applicationStyleSettings ?? throw new ArgumentNullException(nameof(applicationStyleSettings));
            _themeManagerHelper = themeManagerHelper ?? throw new ArgumentNullException(nameof(themeManagerHelper));
            Load();
        }

        /// <summary>
        ///     Is true if radio button for dark theme is checked.
        /// </summary>
        public bool AppUsesDarkTheme
        {
            get => _appUsesDarkTheme;
            set
            {
                _appUsesDarkTheme = value;
                OnPropertyChanged();
                SetTheme(_appUsesDarkTheme);
            }
        }

        /// <summary>
        ///     Style accent.
        /// </summary>
        public string StyleAccent
        {
            get => _styleAccentName;
            set
            {
                _styleAccentName = value;
                OnPropertyChanged();
                if (_styleAccent == null)
                {
                    return;
                }

                SetAccent(_styleAccentName);
            }
        }

        /// <summary>
        ///     Load
        /// </summary>
        private void Load()
        {
            _themeManagerHelper.RegisterSystemColorTheme();

            if (!string.IsNullOrWhiteSpace(_applicationStyleSettings.Accent))
            {
                _styleAccent = ThemeManager.GetAccent(_applicationStyleSettings.Accent);
            }

            if (!string.IsNullOrWhiteSpace(_applicationStyleSettings.Theme))
            {
                _styleTheme = ThemeManager.GetAppTheme(_applicationStyleSettings.Theme);
            }

            _styleAccentName = _styleAccent.Name;
            switch (_styleTheme.Name)
            {
                case "BaseDark":
                    AppUsesDarkTheme = true;
                    break;

                case "BaseLight":
                    AppUsesDarkTheme = false;
                    break;
            }

            SetStyle();
            StyleAccents = ThemeManager.Accents.Select(accent => accent.Name).OrderBy(a => a).ToList();
        }

        /// <summary>
        /// </summary>
        private void SetStyle()
        {
            ThemeManager.ChangeAppStyle(Application.Current, _styleAccent, _styleTheme);
        }

        /// <summary>
        /// </summary>
        /// <param name="styleAccent"></param>
        public void SetAccent(string styleAccent)
        {
            if (styleAccent == null)
            {
                throw new ArgumentNullException(nameof(styleAccent));
            }

            _styleAccent = ThemeManager.GetAccent(styleAccent);
            SetStyle();
        }

        private List<string> _styleAccents;

        /// <summary>
        ///     Contains a list of style accents.
        /// </summary>
        public List<string> StyleAccents
        {
            get => _styleAccents;
            set
            {
                _styleAccents = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Set theme of application
        /// </summary>
        /// <param name="appUsesDarkTheme"></param>
        public void SetTheme(bool? appUsesDarkTheme)
        {
            //_styleTheme = style.Item1;

            if (appUsesDarkTheme.HasValue)
            {
                _styleTheme = ThemeManager.GetAppTheme(appUsesDarkTheme.Value ? "BaseDark" : "BaseLight");
            }

            SetStyle();
        }


        /// <summary>
        ///     Save ApplicationStyle.
        /// </summary>
        public void SaveStyle()
        {
            _applicationStyleSettings.Accent = _styleAccent.Name;
            _applicationStyleSettings.Theme = _styleTheme.Name;
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     INotifyPropertyChanged - method to synchronize UI and Property.
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}