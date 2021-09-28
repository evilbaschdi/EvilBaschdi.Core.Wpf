using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using EvilBaschdi.CoreExtended.Extensions;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;
using JetBrains.Annotations;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel
{
    /// <summary>
    ///     ViewModel of ApplicationStyle.
    /// </summary>
    public class ApplicationStyleViewModel : INotifyPropertyChanged
    {
        private readonly bool _center;
        private readonly bool _resizeWithBorder400;
        private readonly IRoundCorners _roundCorners;
        private bool _settingsFlyoutIsOpen;
        private ICommandViewModel _toggleFlyout;

        /// <summary>
        ///     Constructor
        /// </summary>
        // ReSharper disable once MemberCanBeProtected.Global
        public ApplicationStyleViewModel([NotNull] IRoundCorners roundCorners, bool center = false, bool resizeWithBorder400 = false)
        {
            _roundCorners = roundCorners ?? throw new ArgumentNullException(nameof(roundCorners));
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
        // ReSharper disable once UnusedAutoPropertyAccessor.Global

        public ICommandViewModel ToggleFlyout
        {
            get => _toggleFlyout;
            set => _toggleFlyout = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <inheritdoc />
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                if (value != null)
                {
                    PropertyChanged += value;
                }
            }
            remove
            {
                if (value != null)
                {
                    PropertyChanged -= value;
                }
            }
        }


        /// <summary>
        /// </summary>
        private void InitializeCommandViewModels()
        {
            ToggleFlyout = new DefaultCommand
                           {
                               Command = new RelayCommand(_ => ExecuteToggleFlyout())
                           };
        }

        /// <summary>
        ///     Load.
        /// </summary>
        private void Load()
        {
            if (Application.Current == null)
            {
                return;
            }

            foreach (Window currentWindow in Application.Current.Windows)
            {
                if (currentWindow is MetroWindow metroWindow)
                {
                    metroWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
                    _roundCorners.RunFor(metroWindow);
                }
            }

            if (Application.Current?.MainWindow == null)
            {
                return;
            }

            if (_center)
            {
                Application.Current.MainWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            }

            // ReSharper disable once InvertIf
            if (_resizeWithBorder400)
            {
                Application.Current.MainWindow.Width = SystemParameters.PrimaryScreenWidth - 400;
                Application.Current.MainWindow.Height = SystemParameters.PrimaryScreenHeight - 400;
            }
        }

        /// <summary>
        /// </summary>
        private void ExecuteToggleFlyout()
        {
            SettingsFlyoutIsOpen = !SettingsFlyoutIsOpen;
        }

        /// <inheritdoc cref="PropertyChanged" />
        private event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     INotifyPropertyChanged - method to synchronize UI and Property.
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        // ReSharper disable once MemberCanBePrivate.Global
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}