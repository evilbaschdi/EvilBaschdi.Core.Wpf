using JetBrains.Annotations;

namespace EvilBaschdi.CoreExtended.Extensions;

/// <summary>
/// </summary>
// ReSharper disable once UnusedType.Global
public static class ObjectExtensions
{
    /// <summary>
    ///     obj:null => true
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    [ContractAnnotation("obj:null => true")]
    // ReSharper disable once UnusedMember.Global
    public static bool IsNull(this object obj)
    {
        return obj is null;
    }

    /// <summary>
    ///     obj:null => false
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    [ContractAnnotation("obj:null => false")]
    // ReSharper disable once UnusedMember.Global
    public static bool IsNotNull(this object obj)
    {
        return obj is null == false;
    }
}