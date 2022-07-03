using JetBrains.Annotations;
using MahApps.Metro.Controls;

namespace EvilBaschdi.CoreExtended.FlyOut;

/// <inheritdoc />
// ReSharper disable once UnusedType.Global
public class ToggleFlyOut : IToggleFlyOut
{
    private readonly ICurrentFlyOuts _currentFlyOuts;

    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="currentFlyOuts"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ToggleFlyOut([NotNull] ICurrentFlyOuts currentFlyOuts)
    {
        _currentFlyOuts = currentFlyOuts ?? throw new ArgumentNullException(nameof(currentFlyOuts));
    }

    /// <inheritdoc />
    public void RunFor(FlyoutsControl flyOuts, int index, bool stayOpen = false)
    {
        if (flyOuts == null)
        {
            return;
        }

        var currentFlyOuts = _currentFlyOuts.ValueFor(flyOuts, index);
        var activeFlyOut = currentFlyOuts.ActiveFlyOut;
        var nonactiveFlyOuts = currentFlyOuts.NonActiveFlyOuts;

        foreach (var nonactiveFlyOut in nonactiveFlyOuts)
        {
            nonactiveFlyOut.IsOpen = false;
        }

        activeFlyOut.IsOpen = activeFlyOut.IsOpen && stayOpen || !activeFlyOut.IsOpen;
    }
}