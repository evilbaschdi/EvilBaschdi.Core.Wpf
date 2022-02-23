using EvilBaschdi.CoreExtended.Mvvm.ViewModel;

namespace EvilBaschdi.CoreExtended.Controls.About;

/// <summary>
/// </summary>
// ReSharper disable once UnusedType.Global
public class AboutViewModel : ApplicationStyleViewModel, IAboutModel
{
    private readonly IAboutContent _aboutContent;

    /// <summary>
    /// </summary>
    /// <param name="aboutContent"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public AboutViewModel(IAboutContent aboutContent)
    {
        _aboutContent = aboutContent ?? throw new ArgumentNullException(nameof(aboutContent));
    }

    /// <summary>
    /// </summary>
    // ReSharper disable UnusedMember.Global
    public string ApplicationTitle => _aboutContent.Value.ApplicationTitle;

    /// <summary>
    /// </summary>
    public string Company => $"Company / Authors: {_aboutContent.Value.Company}";

    /// <summary>
    /// </summary>
    public string Copyright => $"{_aboutContent.Value.Copyright}";

    /// <summary>
    /// </summary>
    public string Description => _aboutContent.Value.Description;

    /// <summary>
    /// </summary>
    public string LogoSourcePath => _aboutContent.Value.LogoSourcePath;

    /// <summary>
    /// </summary>
    public string Runtime => $"CLR: {_aboutContent.Value.Runtime}";

    /// <summary>
    /// </summary>
    public string Version => $"Version: {_aboutContent.Value.Version}";
    // ReSharper restore UnusedMember.Global
}