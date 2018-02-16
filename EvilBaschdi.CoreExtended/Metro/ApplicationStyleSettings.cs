using System;
using EvilBaschdi.CoreExtended.AppHelpers;

namespace EvilBaschdi.CoreExtended.Metro
{
    /// <inheritdoc />
    /// <summary>
    ///     ApplicationSettings wrapper Interface implementation.
    /// </summary>
    public class ApplicationStyleSettings : IApplicationStyleSettings
    {
        private readonly IAppSettingsBase _appSettingsBase;

        /// <summary>
        ///     Constructor of the class.
        /// </summary>
        /// <param name="appSettingsBase"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApplicationStyleSettings(IAppSettingsBase appSettingsBase)
        {
            _appSettingsBase = appSettingsBase ?? throw new ArgumentNullException(nameof(appSettingsBase));
        }

        /// <inheritdoc />

        public string Accent
        {
            get => _appSettingsBase.Get("Accent", "");
            set => _appSettingsBase.Set("Accent", value);
        }

        /// <inheritdoc />
        public string Theme
        {
            get => _appSettingsBase.Get("Theme", "");
            set => _appSettingsBase.Set("Theme", value);
        }
    }
}