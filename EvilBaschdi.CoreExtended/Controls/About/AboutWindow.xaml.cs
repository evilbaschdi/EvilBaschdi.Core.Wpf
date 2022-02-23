using System.Windows;
using JetBrains.Annotations;

namespace EvilBaschdi.CoreExtended.Controls.About;

/// <summary>
///     Interaction logic for AboutWindow.xaml
/// </summary>
// ReSharper disable once UnusedType.Global
public partial class AboutWindow
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