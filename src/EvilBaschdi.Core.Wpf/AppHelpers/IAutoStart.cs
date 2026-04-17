// ReSharper disable UnusedMember.Global

namespace EvilBaschdi.Core.Wpf.AppHelpers;

/// <summary>
///     Manage AutoStart
/// </summary>
public interface IAutoStart
{
    /// <summary>
    ///     Is AutoStart enabled
    /// </summary>
    bool IsEnabled { get; }

    /// <summary>
    ///     Enable AutoStart
    /// </summary>
    void Enable();

    /// <summary>
    ///     Disable AutoStart
    /// </summary>
    void Disable();
}