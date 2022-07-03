using JetBrains.Annotations;
using MahApps.Metro.Controls;

namespace EvilBaschdi.CoreExtended;

/// <inheritdoc />
public class ToggleFlyOut : IToggleFlyOut
{
    /// <inheritdoc />
    public void RunFor([CanBeNull] FlyoutsControl flyOuts, int index, bool stayOpen = false)
    {
        // ReSharper disable once UseNullPropagation
        if (flyOuts == null)
        {
            return;
        }

        var activeFlyOut = (Flyout)flyOuts.Items[index];
        if (activeFlyOut == null)
        {
            return;
        }

        foreach (
            var nonactiveFlyOut in
            flyOuts.Items.Cast<Flyout>()
                   .Where(nonactiveFlyOut => nonactiveFlyOut.IsOpen && nonactiveFlyOut.Name != activeFlyOut.Name))
        {
            nonactiveFlyOut.IsOpen = false;
        }

        activeFlyOut.IsOpen = activeFlyOut.IsOpen && stayOpen || !activeFlyOut.IsOpen;
    }
}