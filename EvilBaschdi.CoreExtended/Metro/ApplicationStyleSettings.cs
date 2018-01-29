using System;
using EvilBaschdi.CoreExtended.Application;

namespace EvilBaschdi.CoreExtended.Metro
{
    /// <inheritdoc />
    /// <summary>
    ///     ApplicationSettings wrapper Interface implementation.
    /// </summary>
    public class ApplicationStyleSettings : IApplicationStyleSettings
    {
        private readonly IApplicationSettingsBase _applicationSettingsBase;

        /// <summary>
        ///     Constructor of the class.
        /// </summary>
        /// <param name="applicationSettingsBase"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ApplicationStyleSettings(IApplicationSettingsBase applicationSettingsBase)
        {
            _applicationSettingsBase = applicationSettingsBase ?? throw new ArgumentNullException(nameof(applicationSettingsBase));
        }

        /// <inheritdoc />

        public string Accent
        {
            get => _applicationSettingsBase.Get("Accent", "");
            set => _applicationSettingsBase.Set("Accent", value);
        }

        /// <inheritdoc />
        public string Theme
        {
            get => _applicationSettingsBase.Get("Theme", "");
            set => _applicationSettingsBase.Set("Theme", value);
        }
    }
}