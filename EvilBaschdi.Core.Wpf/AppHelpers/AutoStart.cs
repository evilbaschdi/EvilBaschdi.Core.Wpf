using static Microsoft.Win32.Registry;

namespace EvilBaschdi.Core.Wpf.AppHelpers;

/// <inheritdoc />
/// <summary>
///     Constructor
/// </summary>
/// <param name="appName"></param>
/// <param name="location">Assembly.GetExecutingAssembly().Location</param>
// ReSharper disable once UnusedType.Global
public class AutoStart(string appName, string location) : IAutoStart
{
    private const string SubKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
    private readonly string _appName = appName ?? throw new ArgumentNullException(nameof(appName));
    private readonly string _location = location ?? throw new ArgumentNullException(nameof(location));

    /// <inheritdoc />
    public void Enable()
    {
        var registryKey = CurrentUser.OpenSubKey(SubKey, true);
        registryKey?.SetValue(_appName, _location);
    }

    /// <inheritdoc />
    public void Disable()
    {
        var registryKey = CurrentUser.OpenSubKey(SubKey, true);
        registryKey?.DeleteValue(_appName, false);
    }

    /// <inheritdoc />
    public bool IsEnabled
    {
        get
        {
            var registryKey = CurrentUser.OpenSubKey(SubKey, true);
            var value = registryKey?.GetValue(_appName);
            return value != null;
        }
    }
}