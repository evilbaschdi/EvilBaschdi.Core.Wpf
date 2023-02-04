// ReSharper disable All

namespace EvilBaschdi.About.Wpf.Enums;

/// <summary>
/// </summary>
[Flags]
public enum DwmWindowAttribute : uint
{
    /// <summary>
    ///     Round Corners
    /// </summary>
    DWMWA_WINDOW_CORNER_PREFERENCE = 33,

    /// <summary>
    /// </summary>
    DWMWA_USE_IMMERSIVE_DARK_MODE = 20,

    /// <summary>
    /// </summary>
    DWMWA_MICA_EFFECT = 1029,

    /// <summary>
    /// </summary>
    DWMWA_SYSTEMBACKDROP_TYPE = 38,

    /// <summary>
    /// </summary>
    DWMSBT_AUTO = 0,

    /// <summary>
    ///     None
    /// </summary>
    DWMSBT_DISABLE = 1,

    /// <summary>
    ///     ApplyMicaBrush
    /// </summary>
    DWMSBT_MAINWINDOW = 2,

    /// <summary>
    ///     Acrylic
    /// </summary>
    DWMSBT_TRANSIENTWINDOW = 3,

    /// <summary>
    ///     Tabbed
    /// </summary>
    DWMSBT_TABBEDWINDOW = 4
}