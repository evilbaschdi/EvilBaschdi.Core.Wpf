using System.ComponentModel;
using System.Runtime.CompilerServices;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel;

/// <summary>
///     ViewModel of ApplicationStyle.
/// </summary>
public class ApplicationStyleViewModel : INotifyPropertyChanged
{
    private readonly IApplicationStyle _applicationStyle;
    private bool _settingsFlyoutIsOpen;
    private ICommandViewModel _toggleFlyout;

    /// <summary>
    ///     Constructor
    /// </summary>
    // ReSharper disable once MemberCanBeProtected.Global
    public ApplicationStyleViewModel([NotNull] IApplicationStyle applicationStyle)
    {
        _applicationStyle = applicationStyle ?? throw new ArgumentNullException(nameof(applicationStyle));
        InitializeCommandViewModels();
        ApplyApplicationStyle();
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
    ///     ApplyApplicationStyle.
    /// </summary>
    private void ApplyApplicationStyle()
    {
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