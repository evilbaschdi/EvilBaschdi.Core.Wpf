namespace EvilBaschdi.CoreExtended.Metro
{
    /// <summary>
    ///     Interface for classes that handle metro style on wpf.
    /// </summary>
    public interface IApplicationStyle
    {
        /// <summary>
        ///     Load.
        /// </summary>
        /// <param name="center"></param>
        /// <param name="resizeWithBorder400"></param>
        void Load(bool center = false, bool resizeWithBorder400 = false);
    }
}