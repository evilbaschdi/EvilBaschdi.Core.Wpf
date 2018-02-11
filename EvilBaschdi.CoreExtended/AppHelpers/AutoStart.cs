using System;
using System.Reflection;
using Microsoft.Win32;

namespace EvilBaschdi.CoreExtended.AppHelpers
{
    /// <inheritdoc />
    public class AutoStart : IAutoStart
    {
        private readonly string _appName;
        private const string SubKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="appName"></param>
        public AutoStart(string appName)
        {
            _appName = appName ?? throw new ArgumentNullException(nameof(appName));
        }

        /// <inheritdoc />
        public void Enable()
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(SubKey, true);
            var location = Assembly.GetExecutingAssembly().Location;
            registryKey?.SetValue(_appName, location);
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