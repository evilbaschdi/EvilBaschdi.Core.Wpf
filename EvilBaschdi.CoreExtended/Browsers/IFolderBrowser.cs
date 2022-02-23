namespace EvilBaschdi.CoreExtended.Browsers;

/// <summary>
///     Interface for FolderBrowser.
/// </summary>
public interface IFolderBrowser
{
    /// <summary>
    ///     Get or Set selected path.
    /// </summary>
    // ReSharper disable UnusedMemberInSuper.Global
    string SelectedPath { get; set; }
    // ReSharper restore UnusedMemberInSuper.Global

    /// <summary>
    ///     Shows FolderBrowser.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    void ShowDialog();
}