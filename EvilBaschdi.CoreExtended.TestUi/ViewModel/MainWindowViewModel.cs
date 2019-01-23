using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using EvilBaschdi.Core.Security;
using EvilBaschdi.CoreExtended.Extensions;
using EvilBaschdi.CoreExtended.Metro;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel;
using EvilBaschdi.CoreExtended.Mvvm.ViewModel.Command;

namespace TestUi.ViewModel
{
    /// <inheritdoc cref="INotifyPropertyChanged" />
    /// <summary>
    ///     MainWindowViewModel of TestUi.
    /// </summary>
    public class MainWindowViewModel : ApplicationStyleViewModel
    {
        private readonly IApplicationStyleSettings _applicationStyleSettings;
        private readonly IEncryption _encryption;
        private readonly IThemeManagerHelper _themeManagerHelper;
        private string _customColorText;
        private string _encryptedText;
        private Brush _inputBackground;
        private string _inputText;
        private Brush _outputBackground;
        private string _outputText;


        protected internal MainWindowViewModel(IApplicationStyleSettings applicationStyleSettings,
                                               IThemeManagerHelper themeManagerHelper, IEncryption encryption)
            : base(applicationStyleSettings, themeManagerHelper)
        {
            _applicationStyleSettings = applicationStyleSettings ?? throw new ArgumentNullException(nameof(applicationStyleSettings));
            _themeManagerHelper = themeManagerHelper ?? throw new ArgumentNullException(nameof(themeManagerHelper));
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
        }

        public ICommandViewModel CompareClick { get; set; }

        public string CustomColorText
        {
            get => _customColorText;
            set
            {
                _customColorText = value;
                ExecuteCustomColorOnLostFocus();
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
                    _themeManagerHelper.CreateAppStyleFor(_customColorText.ToColor(), _customColorText);

                    //var styleAccent = ThemeManager.GetAccent(_customColorText);
                    //var styleTheme = ThemeManager.GetAppTheme(_applicationStyleSettings.Theme);
                    //ThemeManager.ChangeAppStyle(Application.Current, styleAccent, styleTheme);
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
            var brush = _inputText.Equals(_outputText) ? Brushes.DarkGreen : Brushes.DarkRed;

            InputBackground = brush;
            OutputBackground = brush;
        }
    }
}