namespace EvilBaschdi.CoreExtended.Metro
{
    /// <summary>
    ///     ApplicationSettings wrapper Interface.
    /// </summary>
    public interface IApplicationStyleSettings
    {
        /// <summary>
        ///     MahApps ThemeManager Accent.
        /// </summary>
        string Accent { get; set; }

        /// <summary>
        ///     MahApps ThemeManager Theme.
        /// </summary>
        string Theme { get; set; }
    }
}