using System.Runtime.InteropServices;
using System.Windows.Interop;
using EvilBaschdi.CoreExtended.Enums;
using JetBrains.Annotations;
using MahApps.Metro.Controls;
using static EvilBaschdi.CoreExtended.Extensions.Imports;

namespace EvilBaschdi.CoreExtended;

/// <inheritdoc />
public class RoundCorners : IRoundCorners
{
    private readonly bool _enabled;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="enabled"></param>
    public RoundCorners(bool enabled = true)
    {
        _enabled = enabled;
    }

    /// <inheritdoc />
    public void RunFor([NotNull] MetroWindow metroWindow)
    {
        if (metroWindow == null)
        {
            throw new ArgumentNullException(nameof(metroWindow));
        }

        if (!_enabled)
        {
            return;
        }

        //rounded corners
        var hWnd = new WindowInteropHelper(metroWindow).EnsureHandle();
        const DwmWindowAttribute attribute = DwmWindowAttribute.DWMWA_WINDOW_CORNER_PREFERENCE;
        var preference = (int)DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
        DwmSetWindowAttribute(hWnd, attribute, ref preference, Marshal.SizeOf(typeof(int)));
    }
}