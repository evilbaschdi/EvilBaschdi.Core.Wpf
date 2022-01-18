using System;
using System.Windows;
using JetBrains.Annotations;
using MicaWPF.Controls;

namespace EvilBaschdi.CoreExtended.Controls.About
{
    /// <summary>
    ///     Interaction logic for AboutWindow.xaml
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public partial class AboutWindow : MicaWindow
    {
        [NotNull] private readonly IAboutModel _aboutModel;

        /// <inheritdoc />
        public AboutWindow([NotNull] IAboutModel aboutModel)
        {
            _aboutModel = aboutModel ?? throw new ArgumentNullException(nameof(aboutModel));
            InitializeComponent();

            Loaded += AboutWindowLoaded;
        }

        private void AboutWindowLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = _aboutModel;
        }
    }
}