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
        private readonly IThemeManagerHelper _themeManagerHelper;
        private bool _settingsFlyoutIsOpen;

        /// <summary>
        ///     Constructor
        /// </summary>
        protected ApplicationStyleViewModel(IThemeManagerHelper themeManagerHelper)
        {
            _themeManagerHelper = themeManagerHelper ?? throw new ArgumentNullException(nameof(themeManagerHelper));
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
        /// </summary>
        private void Load()
        {
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