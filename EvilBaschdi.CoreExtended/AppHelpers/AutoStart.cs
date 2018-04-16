using System;
using System.Reflection;
using Microsoft.Win32;

namespace EvilBaschdi.CoreExtended.AppHelpers
{
    /// <inheritdoc />
    public class AutoStart : IAutoStart
    {
        private readonly string _appName;
        private readonly string _location;
        private const string SubKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="location">Assembly.GetExecutingAssembly().Location</param>
        public AutoStart(string appName, string location)
        {
            _appName = appName ?? throw new ArgumentNullException(nameof(appName));
            _location = location ?? throw new ArgumentNullException(nameof(location));
        }

        /// <inheritdoc />
        public void Enable()
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(SubKey, true);
            registryKey?.SetValue(_appName, _location);
        }

        /// <inheritdoc />
        public void Disable()
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(SubKey, true);
            registryKey?.DeleteValue(_appName, false);
        }

        /// <inheritdoc />
        public bool IsEnabled
        {
            get
            {
                var registryKey = Registry.CurrentUser.OpenSubKey(SubKey, true);
                var value = registryKey?.GetValue(_appName);
                return value != null;
            }
        }
    }
}