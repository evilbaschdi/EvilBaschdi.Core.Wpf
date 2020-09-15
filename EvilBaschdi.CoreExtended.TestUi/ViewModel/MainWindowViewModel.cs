using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using ControlzEx.Theming;
using EvilBaschdi.Core.Security;
using EvilBaschdi.CoreExtended.Controls.About;
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

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="encryption"></param>
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

        /// <summary>
        ///     {Binding AboutWindowClick}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public ICommandViewModel AboutWindowClick { get; set; }

        /// <summary>
        ///     {Binding CompareClick}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public ICommandViewModel CompareClick { get; set; }

        /// <summary>
        ///     {Binding CustomColorText}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public string CustomColorText
        {
            get => _customColorText;

            // ReSharper disable once UnusedMember.Global
            set
            {
                _customColorText = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     {Binding DecryptClick}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public ICommandViewModel DecryptClick { get; set; }

        /// <summary>
        ///     {Binding EncryptClick}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public ICommandViewModel EncryptClick { get; set; }

        /// <summary>
        ///     {Binding EncryptedText}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global

        public string EncryptedText
        {
            // ReSharper disable once UnusedMember.Global
            get => _encryptedText;
            set
            {
                _encryptedText = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     {Binding InputBackground}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public Brush InputBackground
        {
            // ReSharper disable once UnusedMember.Global
            get => _inputBackground;
            set
            {
                _inputBackground = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     {Binding InputText}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public string InputText
        {
            get => _inputText;
            // ReSharper disable once UnusedMember.Global
            set
            {
                _inputText = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     {Binding LostFocus}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        public ICommandViewModel LostFocus { get; set; }

        /// <summary>
        ///     {Binding OutputBackground}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public Brush OutputBackground
        {
            // ReSharper disable once UnusedMember.Global
            get => _outputBackground;
            set
            {
                _outputBackground = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     {Binding OutputText}
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
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
            if (string.IsNullOrWhiteSpace(CustomColorText))
            {
                return;
            }

            try
            {
                ThemeManager.Current.ChangeThemeBaseColor(Application.Current, CustomColorText);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
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
            var brush = InputText.Equals(OutputText) ? Brushes.DarkGreen : Brushes.DarkRed;

            InputBackground = brush;
            OutputBackground = brush;
        }

        private void BtnAboutWindowClick()
        {
            var assembly = typeof(MainWindow).Assembly;

            IAboutContent aboutContent =
                new AboutContent(assembly, $@"{AppDomain.CurrentDomain.BaseDirectory}\b.png");
            var aboutWindow = new AboutWindow
                              {
                                  DataContext = new AboutViewModel(aboutContent)
                              };
            aboutWindow.ShowDialog();
        }
    }
}