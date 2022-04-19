using System.Collections.Specialized;
using System.Configuration;
using JetBrains.Annotations;

namespace EvilBaschdi.CoreExtended.AppHelpers;

/// <inheritdoc />
/// <summary>
///     Classes to get values from or set values in AppSettingsBase
/// </summary>
// ReSharper disable once UnusedType.Global
public class AppSettingsBase : IAppSettingsBase
{
    private readonly ApplicationSettingsBase _settingsBase;

    /// <summary>
    /// </summary>
    /// <param name="settingsBase"></param>
    public AppSettingsBase(ApplicationSettingsBase settingsBase)
    {
        _settingsBase = settingsBase ?? throw new ArgumentNullException(nameof(settingsBase));
        Upgrade();
    }

    /// <inheritdoc />
    /// <summary>
    ///     Get value of type T
    /// </summary>
    /// <param name="setting"></param>
    /// <param name="fallback"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    // ReSharper disable once RedundantTypeSpecificationInDefaultExpression
    public T Get<T>(string setting, T fallback = default)
    {
        if (setting == null)
        {
            throw new ArgumentNullException(nameof(setting));
        }

        if (fallback == null)
        {
            throw new ArgumentNullException(nameof(fallback));
        }

        if (_settingsBase == null)
        {
            return fallback;
        }

        if (_settingsBase?.Properties != null && !_settingsBase.Properties.OfType<SettingsProperty>().ToList().Any(x => x.Name.Equals(setting)))
        {
            return fallback;
        }

        var value = (T)_settingsBase?[setting] ?? fallback;

        return IsValueEmpty(value) ? fallback : value;
    }

    /// <inheritdoc />
    /// <summary>
    ///     Set value of type T
    /// </summary>
    /// <param name="setting"></param>
    /// <param name="value"></param>
    public void Set(string setting, [NotNull] object value)
    {
        if (setting == null)
        {
            throw new ArgumentNullException(nameof(setting));
        }

        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        _settingsBase[setting] = value ?? throw new ArgumentNullException(nameof(value));
        _settingsBase.Save();
    }

    private void Upgrade()
    {
        if (!Get("UpgradeRequired", true))
        {
            return;
        }

        _settingsBase.Upgrade();
        Set("UpgradeRequired", false);
        _settingsBase.Save();
    }

    private static bool IsValueEmpty<T>(T value)
    {
        if (value == null)
        {
            return true;
        }

        switch (value)
        {
            case string s when string.IsNullOrWhiteSpace(s):
                return true;
            case StringCollection collection:
            {
                if (collection.Count == 0)
                {
                    return true;
                }

                break;
            }

            default:
            {
                if (value.Equals(default))
                {
                    return true;
                }

                break;
            }
        }

        return false;
    }
}