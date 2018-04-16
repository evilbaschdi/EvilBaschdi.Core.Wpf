using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command
{
    /// <inheritdoc cref="ICommandViewModel" />
    /// <inheritdoc cref="INotifyPropertyChanged" />
    public sealed class DefaultCommand : ICommandViewModel, INotifyPropertyChanged
    {
        private Visibility _visibility;
        private ICommand _command;
        private string _imagePath;
        private string _text;

        /// <inheritdoc />

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        /// <inheritdoc />
        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        /// <inheritdoc />
        public ICommand Command
        {
            get => _command;
            set
            {
                _command = value;
                OnPropertyChanged("Command");
            }
        }

        /// <inheritdoc />
        public Visibility Visibility
        {
            get => _visibility;
            set
            {
                _visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}