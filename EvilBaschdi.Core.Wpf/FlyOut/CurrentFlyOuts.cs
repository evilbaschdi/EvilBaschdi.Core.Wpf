using MahApps.Metro.Controls;

namespace EvilBaschdi.Core.Wpf.FlyOut;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public class CurrentFlyOuts : ICurrentFlyOuts
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="flyOuts"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public CurrentFlyOutsModel ValueFor([CanBeNull] FlyoutsControl flyOuts, int index)
    {
        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        // ReSharper disable once UseNullPropagation
        if (flyOuts == null)
        {
            return null;
        }

        var activeFlyOut = (Flyout)flyOuts.Items[index];
        if (activeFlyOut == null)
        {
            return null;
        }

        var nonactiveFlyOuts = flyOuts.Items.Cast<Flyout>()
            .Where(nonactiveFlyOut =>
                nonactiveFlyOut.IsOpen && nonactiveFlyOut.Name != activeFlyOut.Name);

        return new()
        {
            ActiveFlyOut = activeFlyOut,
            NonActiveFlyOuts = nonactiveFlyOuts,
        };
    }
}