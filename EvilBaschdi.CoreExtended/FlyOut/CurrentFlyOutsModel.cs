﻿using MahApps.Metro.Controls;

namespace EvilBaschdi.CoreExtended.FlyOut;

/// <summary>
/// </summary>
public class CurrentFlyOutsModel
{
    /// <summary>
    /// </summary>
    public Flyout ActiveFlyOut { get; init; }

    /// <summary>
    /// </summary>
    public List<Flyout> NonActiveFlyOuts { get; init; }
}