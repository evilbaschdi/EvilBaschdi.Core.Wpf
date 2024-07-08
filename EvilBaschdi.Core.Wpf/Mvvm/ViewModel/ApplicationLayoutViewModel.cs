// ReSharper disable UnusedMember.Global

using System.ComponentModel;
using System.Runtime.CompilerServices;
using EvilBaschdi.Core.Wpf.Mvvm.ViewModel.Command;

namespace EvilBaschdi.Core.Wpf.Mvvm.ViewModel;

/// <summary>
///     ViewModel with ApplicationLayout.
/// </summary>
public class ApplicationLayoutViewModel : INotifyPropertyChanged
{
    private readonly IApplicationLayout _applicationLayout;
    private readonly IApplicationStyle _applicationStyle;
    private readonly bool _center;
    private readonly bool _resizeWithBorder400;
    private bool _settingsFlyoutIsOpen;
    private ICommandViewModel _toggleFlyout;

    /// <summary>
    ///     Constructor
    /// </summary>
    // ReSharper disable once MemberCanBeProtected.Global
    public ApplicationLayoutViewModel([NotNull] IApplicationLayout applicationLayout,
                                      [NotNull] IApplicationStyle applicationStyle,
                                      bool center,
                                      bool resizeWithBorder400)
    {
        _applicationLayout = applicationLayout ?? throw new ArgumentNullException(nameof(applicationLayout));
        _applicationStyle = applicationStyle ?? throw new ArgumentNullException(nameof(applicationStyle));
        _center = center;
        _resizeWithBorder400 = resizeWithBorder400;
        InitializeCommandViewModels();
        ApplyApplicationStyleAndLayout();
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
    ///     ApplyApplicationStyle.
    /// </summary>
    private void ApplyApplicationStyleAndLayout()
    {
        _applicationLayout.RunFor((_center, _resizeWithBorder400));
        _applicationStyle.Run();
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
        PropertyChanged?.Invoke(this, new(propertyName));
    }
}