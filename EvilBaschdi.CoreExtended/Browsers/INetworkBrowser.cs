using System;
using System.Collections;
using System.Collections.Generic;
using EvilBaschdi.Core;

namespace EvilBaschdi.CoreExtended.Browsers
{
    /// <inheritdoc />
    /// <summary>
    ///     Interface for NetworkBrowser.
    /// </summary>
    public interface INetworkBrowser : IValue<List<string>>
    {
        /// <summary>
        ///     Contains an Exception if Value has thrown some.
        /// </summary>
        Exception Exception { get; }

        /// <summary>
        ///     Contains an ArrayList of computers found in the network.
        /// </summary>
        [Obsolete("replaced with 'Value'")]
        ArrayList GetNetworkComputers { get; }
    }
}