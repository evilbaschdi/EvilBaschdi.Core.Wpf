using MahApps.Metro.Controls;

namespace EvilBaschdi.CoreExtended.FlyOut;

/// <inheritdoc />
public class CurrentFlyOuts : ICurrentFlyOuts
{
    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="flyOuts"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public CurrentFlyOutsModel ValueFor(FlyoutsControl flyOuts, int index)
    {
        var activeFlyOut = (Flyout)flyOuts.Items[index];
        if (activeFlyOut == null)
        {
            return null;
        }

        var nonactiveFlyOuts = flyOuts.Items.Cast<Flyout>()
                                      .Where(nonactiveFlyOut =>
                                                 nonactiveFlyOut.IsOpen && nonactiveFlyOut.Name != activeFlyOut.Name).ToList();

        return new CurrentFlyOutsModel
               {
                   ActiveFlyOut = activeFlyOut,
                   NonActiveFlyOuts = nonactiveFlyOuts,
               };
    }
}