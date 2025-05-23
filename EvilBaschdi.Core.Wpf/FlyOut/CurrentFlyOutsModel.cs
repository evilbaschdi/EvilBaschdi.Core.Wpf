﻿using MahApps.Metro.Controls;

namespace EvilBaschdi.Core.Wpf.FlyOut;

/// <summary>
/// </summary>
public class CurrentFlyOutsModel
{
    /// <summary>
    /// </summary>
    public Flyout ActiveFlyOut { get; init; }

    /// <summary>
    /// </summary>
    public IEnumerable<Flyout> NonActiveFlyOuts { get; init; }
}