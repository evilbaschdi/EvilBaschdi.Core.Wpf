using System;
using System.Configuration;

namespace EvilBaschdi.CoreExtended.AppHelpers
{
    /// <inheritdoc />
    // ReSharper disable once UnusedType.Global
    public class AppSettingFromConfigurationManager : IAppSettingFromConfigurationManager
    {
        /// <inheritdoc />
        /// <summary>
        ///     Reads key value from app.config.
        /// </summary>
        public string ValueFor(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return ConfigurationManager.AppSettings[key];
        }
    }
}