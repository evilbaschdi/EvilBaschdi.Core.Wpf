using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;
using EvilBaschdi.CoreExtended.Properties;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel
{
    /// <summary>
    ///     ViewModel of ApplicationStyle.
    /// </summary>
    // ReSharper disable MemberCanBePrivate.Global
    public class ApplicationStyleViewModel : INotifyPropertyChanged
    {
        private readonly ApplicationStyleViewModelCodeBehind _applicationStyle;

        /// <summary>
        ///     Constructor
        /// </summary>
        protected ApplicationStyleViewModel([NotNull] ApplicationStyleViewModelCodeBehind applicationStyleViewModelCodeBehind)
        {
            _applicationStyle = applicationStyleViewModelCodeBehind ?? throw new ArgumentNullException(nameof(applicationStyleViewModelCodeBehind));
            InitializeCommandViewModels();
        }

        /// <summary>
        /// </summary>
        public void InitializeCommandViewModels()
        {
            ToggleFlyout = new DefaultCommand
                           {
                               Command = new RelayCommand(rc => ExecuteToggleFlyout())
                           };

            SetAppUsesDarkTheme = new DefaultCommand
                                  {
                                      Command = new RelayCommand(rc => _applicationStyle.SetTheme(AppUsesDarkTheme))
                                  };


            SetAccent = new DefaultCommand
                        {
                            Command = new RelayCommand(rc => _applicationStyle.SetAccent(StyleAccent))
                        };

            SaveStyleSettings = new DefaultCommand
                                {
                                    Command = new RelayCommand(rc => _applicationStyle.SaveStyle())
                                };
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _settingsFlyoutIsOpen;

        /// <summary>
        ///     Toggle Flyout.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public ICommandViewModel ToggleFlyout { get; set; }

        /// <summary>
        ///     Set app uses dark theme.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public ICommandViewModel SetAppUsesDarkTheme { get; set; }


        /// <summary>
        ///     Set accent;
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public ICommandViewModel SetAccent { get; set; }

        /// <summary>
        ///     CommandViewModel to save the accent and theme of the application.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public ICommandViewModel SaveStyleSettings { get; set; }

        /// <summary>
        ///     Sets state of settings flyout.
        /// </summary>
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
        ///     Contains a list of style accents.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public List<string> StyleAccents
        {
            get => _applicationStyle.StyleAccents;
            set => _applicationStyle.StyleAccents = value;
        }

        /// <summary>
        ///     Is true if radio button for dark theme is checked.
        /// </summary>
        public bool AppUsesDarkTheme
        {
            get => _applicationStyle.AppUsesDarkTheme;
            // ReSharper disable once UnusedMember.Global
            set => _applicationStyle.AppUsesDarkTheme = value;
        }

        /// <summary>
        ///     Style accent.
        /// </summary>
        public string StyleAccent
        {
            get => _applicationStyle.StyleAccent;
            // ReSharper disable once UnusedMember.Global
            set => _applicationStyle.StyleAccent = value;
        }

        /// <summary>
        /// </summary>
        public void ExecuteToggleFlyout()
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
    // ReSharper restore MemberCanBePrivate.Global
}