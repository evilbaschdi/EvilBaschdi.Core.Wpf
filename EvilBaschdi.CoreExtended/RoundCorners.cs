﻿using System.Runtime.InteropServices;
using System.Windows.Interop;
using EvilBaschdi.CoreExtended.Extensions;
using JetBrains.Annotations;
using MahApps.Metro.Controls;

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
        const WindowExtensions.DWMWINDOWATTRIBUTE attribute = WindowExtensions.DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE;
        var preference = WindowExtensions.DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUND;
        DwmSetWindowAttribute(hWnd, attribute, ref preference, sizeof(uint));
        //rounded corners
    }

    // Import dwmapi.dll and define DwmSetWindowAttribute in C# corresponding to the native function.
    [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    // ReSharper disable once IdentifierTypo
    private static extern long DwmSetWindowAttribute(IntPtr hwnd,
                                                     WindowExtensions.DWMWINDOWATTRIBUTE attribute,
                                                     ref WindowExtensions.DWM_WINDOW_CORNER_PREFERENCE pvAttribute,
                                                     uint cbAttribute);
}