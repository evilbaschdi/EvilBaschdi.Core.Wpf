namespace EvilBaschdi.Core.Wpf.FlyOut;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public class ToggleFlyOut : IToggleFlyOut
{
    /// <inheritdoc />
    public void RunFor([CanBeNull] CurrentFlyOutsModel currentFlyOutsModel, bool stayOpen)
    {
        if (currentFlyOutsModel == null)
        {
            return;
        }

        var activeFlyOut = currentFlyOutsModel.ActiveFlyOut;
        var nonactiveFlyOuts = currentFlyOutsModel.NonActiveFlyOuts;

        foreach (var nonactiveFlyOut in nonactiveFlyOuts)
        {
            nonactiveFlyOut.IsOpen = false;
        }

        activeFlyOut.IsOpen = activeFlyOut.IsOpen && stayOpen || !activeFlyOut.IsOpen;
    }

    /// <inheritdoc />
    public void RunFor([CanBeNull] CurrentFlyOutsModel currentFlyOutsModel)
    {
        RunFor(currentFlyOutsModel, false);
    }
}