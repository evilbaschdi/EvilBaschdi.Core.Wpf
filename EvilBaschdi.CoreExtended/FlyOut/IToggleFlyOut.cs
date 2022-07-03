using JetBrains.Annotations;
using MahApps.Metro.Controls;

namespace EvilBaschdi.CoreExtended.FlyOut;

/// <summary>
/// </summary>
public interface IToggleFlyOut
{
    /// <summary>
    /// </summary>
    /// <param name="flyOuts"></param>
    /// <param name="index"></param>
    /// <param name="stayOpen"></param>
    void RunFor([CanBeNull] FlyoutsControl flyOuts, int index, bool stayOpen = false);
}