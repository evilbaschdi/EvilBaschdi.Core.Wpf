namespace EvilBaschdi.CoreExtended.Application
{
    /// <summary>
    ///     Manage AutoStart
    /// </summary>
    public interface IAutoStart
    {
        /// <summary>
        ///     Enable AutoStart
        /// </summary>
        void Enable();

        /// <summary>
        ///     Is AutoStart enabled
        /// </summary>
        bool IsEnabled { get; }

        /// <summary>
        ///     Disable AutoStart
        /// </summary>
        void Disable();
    }
}