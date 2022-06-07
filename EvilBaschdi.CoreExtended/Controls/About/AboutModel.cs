namespace EvilBaschdi.CoreExtended.Controls.About;

/// <summary>
/// </summary>
public class AboutModel : IAboutModel
{
    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string ApplicationTitle { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Company { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Copyright { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Description { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string LogoSourcePath { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Runtime { get; set; }

    /// <summary>
    /// </summary>
    // ReSharper disable once PropertyCanBeMadeInitOnly.Global
    public string Version { get; set; }
}