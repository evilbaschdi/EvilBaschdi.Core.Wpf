namespace EvilBaschdi.CoreExtended.AppHelpers;

/// <summary>
///     Interface for classes to get values from or set values in AppSettingsBase
/// </summary>
public interface IAppSettingsBase

{
    /// <summary>
    ///     Get value of type T
    /// </summary>
    /// <param name="setting"></param>
    /// <param name="fallback"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    // ReSharper disable once RedundantTypeSpecificationInDefaultExpression
    // ReSharper disable once UnusedMemberInSuper.Global
    T Get<T>(string setting, T fallback = default);

    /// <summary>
    ///     Set value of type T
    /// </summary>
    /// <param name="setting"></param>
    /// <param name="value"></param>
    // ReSharper disable once UnusedMemberInSuper.Global
    void Set(string setting, object value);
}