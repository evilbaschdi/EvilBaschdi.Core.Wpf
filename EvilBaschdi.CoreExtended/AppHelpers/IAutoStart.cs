// ReSharper disable UnusedMember.Global
namespace EvilBaschdi.CoreExtended.AppHelpers;

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