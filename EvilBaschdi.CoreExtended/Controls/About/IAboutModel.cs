namespace EvilBaschdi.CoreExtended.Controls.About;

/// <summary>
/// </summary>
public interface IAboutModel
{
    /// <summary>
    /// </summary>
    public string ApplicationTitle { get; }

    /// <summary>
    /// </summary>
    public string Company { get; }

    /// <summary>
    /// </summary>
    public string Copyright { get; }

    /// <summary>
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// </summary>
    public string LogoSourcePath { get; }

    /// <summary>
    /// </summary>
    public string Runtime { get; }

    /// <summary>
    /// </summary>
    public string Version { get; }
}