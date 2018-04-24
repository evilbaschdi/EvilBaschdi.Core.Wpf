namespace EvilBaschdi.CoreExtended.Browsers
{
    /// <summary>
    ///     Interface for FolderBrowser.
    /// </summary>
    public interface IFolderBrowser
    {
        /// <summary>
        ///     Get or Set selected path.
        /// </summary>
        string SelectedPath { get; set; }

        /// <summary>
        ///     Shows FolderBrowser.
        /// </summary>
        void ShowDialog();
    }
}