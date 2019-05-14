using System;
using System.Collections.Generic;
using System.DirectoryServices;

namespace EvilBaschdi.CoreExtended.Browsers
{
    /// <inheritdoc />
    /// <summary>
    ///     Class for NetworkBrowser.
    /// </summary>
    public sealed class NetworkBrowser : INetworkBrowser
    {
        /// <inheritdoc />
        /// <summary>
        ///     Contains an ArrayList of computers found in the network.
        /// </summary>
        public List<string> Value
        {
            get
            {
                var networkComputers = new List<string>();


                try
                {
                    DirectoryEntry root = new DirectoryEntry("WinNT:");

                    foreach (DirectoryEntry computers in root.Children)
                    {
                        foreach (DirectoryEntry computer in computers.Children)
                        {
                            if (computer.SchemaClassName == "Computer")
                            {
                                networkComputers.Add(computer.Name.ToLower());
                            }
                        }
                    }

                    return networkComputers;
                }
                catch (Exception e)
                {
                    Exception = e;
                    return null;
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        ///     Contains an Exception if Value has thrown some.
        /// </summary>
        public Exception Exception { get; private set; }
    }
}