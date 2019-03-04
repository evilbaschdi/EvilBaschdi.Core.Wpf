using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using EvilBaschdi.CoreExtended.Metro;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;
using JetBrains.Annotations;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel
{
    /// <summary>
    ///     ViewModel of ApplicationStyle.
    /// </summary>
    public class ApplicationStyleViewModel : INotifyPropertyChanged
    {
        private readonly bool _center;
        private readonly bool _resizeWithBorder400;
        private readonly IThemeManagerHelper _themeManagerHelper;
        private bool _settingsFlyoutIsOpen;

        /// <summary>
        ///     Constructor
        /// </summary>
        protected ApplicationStyleViewModel(IThemeManagerHelper themeManagerHelper, bool center = false, bool resizeWithBorder400 = false)
        {
            _themeManagerHelper = themeManagerHelper ?? throw new ArgumentNullException(nameof(themeManagerHelper));
            _center = center;
            _resizeWithBorder400 = resizeWithBorder400;
            InitializeCommandViewModels();
            Load();
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
        }

        /// <summary>
        ///     Load.
        /// </summary>
        private void Load()
        {
            if (Application.Current.MainWindow != null)
            {
                if (_center)
                {
                    Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                }

                if (_resizeWithBorder400)
                {
                    Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth - 400;
                    Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight - 400;
                }
            }

            foreach (Window currentWindow in Application.Current.Windows)
            {
                _themeManagerHelper.SetSystemColorTheme(currentWindow);
            }
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