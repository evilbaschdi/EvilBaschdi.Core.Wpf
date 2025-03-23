using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace EvilBaschdi.Core.Wpf.Mvvm.ViewModel.Command;

/// <inheritdoc cref="ICommandViewModel" />
/// <inheritdoc cref="INotifyPropertyChanged" />
public sealed class DefaultCommand : ICommandViewModel, INotifyPropertyChanged
{
    /// <inheritdoc />
    public string Text
    {
        get;
        set
        {
            if (value != null)
            {
                field = value;
            }

            OnPropertyChanged(nameof(Text));
        }
    }

    /// <inheritdoc />
    public string ImagePath
    {
        get;
        set
        {
            if (value != null)
            {
                field = value;
            }

            OnPropertyChanged(nameof(ImagePath));
        }
    }

    /// <inheritdoc />
    public ICommand Command
    {
        get;
        set
        {
            if (value != null)
            {
                field = value;
            }

            OnPropertyChanged(nameof(Command));
        }
    }

    /// <inheritdoc />
    public Visibility Visibility
    {
        get;
        set
        {
            field = value;
            OnPropertyChanged(nameof(Visibility));
        }
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
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    ///     INotifyPropertyChanged - method to synchronize UI and Property.
    /// </summary>
    /// <param name="propertyName"></param>
    [NotifyPropertyChangedInvocator]
    private void OnPropertyChanged([CanBeNull] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new(propertyName));
    }
}