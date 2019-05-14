using System;
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
    }
}