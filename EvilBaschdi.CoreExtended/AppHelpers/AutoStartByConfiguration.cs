using System;

namespace EvilBaschdi.CoreExtended.AppHelpers
{
    /// <inheritdoc />
    // ReSharper disable once UnusedType.Global
    public class AutoStartByConfiguration : IAutoStartByConfiguration
    {
        private readonly IAppSettingFromConfigurationManager _appSettingFromConfigurationManager;
        private readonly IAutoStart _autoStart;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        /// <param name="appSettingFromConfigurationManager"></param>
        /// <param name="autoStart"></param>
        public AutoStartByConfiguration(IAppSettingFromConfigurationManager appSettingFromConfigurationManager,
                                        IAutoStart autoStart)
        {
            _appSettingFromConfigurationManager = appSettingFromConfigurationManager ??
                                                  throw new ArgumentNullException(
                                                      nameof(appSettingFromConfigurationManager));
            _autoStart = autoStart ?? throw new ArgumentNullException(nameof(autoStart));
        }

        /// <inheritdoc />
        public void Run()
        {
            if (_appSettingFromConfigurationManager.ValueFor("autostart").Equals("true"))
            {
                _autoStart.Enable();
            }
            else
            {
                _autoStart.Disable();
            }
        }
    }
}