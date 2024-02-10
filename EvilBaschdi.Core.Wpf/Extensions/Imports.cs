using System.Runtime.InteropServices;
using EvilBaschdi.About.Wpf.Enums;

namespace EvilBaschdi.Core.Wpf.Extensions;

/// <summary>
///     <see cref="DllImportAttribute" />
/// </summary>
public static class Imports
{
    /// <summary>
    ///     [DllImport("UXTheme.dll", SetLastError = true, EntryPoint = "#138")]
    /// </summary>
    /// <returns></returns>
    [DllImport("UXTheme.dll", SetLastError = true, EntryPoint = "#138")]
    public static extern bool ShouldSystemUseDarkMode();

    /// <summary>
    ///     [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    /// </summary>
    /// <param name="hwnd"></param>
    /// <param name="attribute"></param>
    /// <param name="pvAttribute"></param>
    /// <param name="cbAttribute"></param>
    /// <returns></returns>
    [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int DwmSetWindowAttribute(IntPtr hwnd, DwmWindowAttribute attribute, ref int pvAttribute, int cbAttribute);
}