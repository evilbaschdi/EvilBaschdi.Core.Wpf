// ReSharper disable All

namespace EvilBaschdi.CoreExtended.Extensions
{
    /// <summary>
    ///     Provides DWM_WINDOW_CORNER_PREFERENCE and DWMWINDOWATTRIBUTE
    /// </summary>
    public static class WindowExtensions
    {
        // The DWM_WINDOW_CORNER_PREFERENCE enum for DwmSetWindowAttribute's third parameter, which tells the function
        // what value of the enum to set.

        /// <summary>
        /// </summary>
        public enum DWM_WINDOW_CORNER_PREFERENCE
        {
            /// <summary>
            /// </summary>
            DWMWCP_DEFAULT = 0,

            /// <summary>
            /// </summary>
            DWMWCP_DONOTROUND = 1,

            /// <summary>
            /// </summary>
            DWMWCP_ROUND = 2,

            /// <summary>
            /// </summary>
            DWMWCP_ROUNDSMALL = 3
        }

        // The enum flag for DwmSetWindowAttribute's second parameter, which tells the function what attribute to set.

        /// <summary>
        /// </summary>
        public enum DWMWINDOWATTRIBUTE
        {
            /// <summary>
            /// </summary>
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }
    }
}