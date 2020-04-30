using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using ControlzEx.Theming;
using EvilBaschdi.Core.Security;
using EvilBaschdi.CoreExtended.Mvvm;
using EvilBaschdi.CoreExtended.Mvvm.View;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;

namespace EvilBaschdi.CoreExtended.TestUi.ViewModel
{
    /// <inheritdoc cref="INotifyPropertyChanged" />
    /// <summary>
    ///     MainWindowViewModel of TestUi.
    /// </summary>
    public class MainWindowViewModel : ApplicationStyleViewModel
    {
        private readonly IEncryption _encryption;
        private string _customColorText;
        private string _encryptedText;
        private Brush _inputBackground;
        private string _inputText;
        private Brush _outputBackground;
        private string _outputText;


        protected internal MainWindowViewModel(IEncryption encryption)
            : base(true)
        {
            _encryption = encryption ?? throw new ArgumentNullException(nameof(encryption));
            EncryptClick = new DefaultCommand
                           {
                               Text = "Encrypt",
                               Command = new RelayCommand(rc => BtnEncryptClick())
                           };

            DecryptClick = new DefaultCommand
                           {
                               Text = "Decrypt",
                               Command = new RelayCommand(rc => BtnDecryptClick())
                           };

            CompareClick = new DefaultCommand
                           {
                               Text = "Compare",
                               Command = new RelayCommand(rc => BtnCompareClick())
                           };
            AboutWindowClick = new DefaultCommand
                               {
                                   Text = "About",
                                   Command = new RelayCommand(rc => BtnAboutWindowClick())
                               };
            LostFocus = new DefaultCommand
                        {
                            Command = new RelayCommand(rc => ExecuteCustomColorOnLostFocus())
                        };
        }

        public ICommandViewModel AboutWindowClick { get; set; }

        public ICommandViewModel CompareClick { get; set; }

        public string CustomColorText
        {
            get => _customColorText;
            set
            {
                _customColorText = value;
                OnPropertyChanged();
            }
        }

        public ICommandViewModel DecryptClick { get; set; }

        public ICommandViewModel EncryptClick { get; set; }

        public string EncryptedText
        {
            get => _encryptedText;
            set
            {
                _encryptedText = value;
                OnPropertyChanged();
            }
        }

        public Brush InputBackground
        {
            get => _inputBackground;
            set
            {
                _inputBackground = value;
                OnPropertyChanged();
            }
        }

        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged();
            }
        }

        public ICommandViewModel LostFocus { get; set; }

        public Brush OutputBackground
        {
            get => _outputBackground;
            set
            {
                _outputBackground = value;
                OnPropertyChanged();
            }
        }

        public string OutputText
        {
            get => _outputText;
            set
            {
                _outputText = value;
                OnPropertyChanged();
            }
        }

        private void ExecuteCustomColorOnLostFocus()
        {
            if (!string.IsNullOrWhiteSpace(_customColorText))
            {
                try
                {
                    ThemeManager.Current.ChangeThemeBaseColor(Application.Current, _customColorText);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void BtnEncryptClick()
        {
            EncryptedText = _encryption.EncryptString(_inputText, "ABC");
        }

        private void BtnDecryptClick()
        {
            OutputText = _encryption.DecryptString(_encryptedText, "ABC");
        }

        private void BtnCompareClick()
        {
            var brush = EncryptedText.Equals(OutputText) ? Brushes.DarkGreen : Brushes.DarkRed;

            InputBackground = brush;
            OutputBackground = brush;
        }

        private void BtnAboutWindowClick()
        {
            var assembly = typeof(MainWindow).Assembly;

            IAboutWindowContent aboutWindowContent =
                new AboutWindowContent(assembly, $@"{AppDomain.CurrentDomain.BaseDirectory}\b.png");
            var aboutWindow = new AboutWindow
                              {
                                  DataContext = new AboutViewModel(aboutWindowContent)
                              };
            aboutWindow.ShowDialog();
        }
    }
}