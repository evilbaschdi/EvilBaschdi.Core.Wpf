using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using JetBrains.Annotations;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;

/// <inheritdoc cref="ICommandViewModel" />
/// <inheritdoc cref="INotifyPropertyChanged" />
public sealed class DefaultCommand : ICommandViewModel, INotifyPropertyChanged
{
    private ICommand _command;
    private string _imagePath;
    private string _text;
    private Visibility _visibility;

    /// <inheritdoc />

    public string Text
    {
        get => _text;
        set
        {
            if (value != null)
            {
                _text = value;
            }

            OnPropertyChanged(nameof(Text));
        }
    }

    /// <inheritdoc />
    public string ImagePath
    {
        get => _imagePath;
        set
        {
            if (value != null)
            {
                _imagePath = value;
            }

            OnPropertyChanged(nameof(ImagePath));
        }
    }

    /// <inheritdoc />
    public ICommand Command
    {
        get => _command;
        set
        {
            if (value != null)
            {
                _command = value;
            }

            OnPropertyChanged(nameof(Command));
        }
    }

    /// <inheritdoc />
    public Visibility Visibility
    {
        get => _visibility;
        set
        {
            _visibility = value;
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
    private void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}