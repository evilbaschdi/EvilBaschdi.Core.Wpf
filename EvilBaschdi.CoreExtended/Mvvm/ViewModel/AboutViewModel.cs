using System;

namespace EvilBaschdi.CoreExtended.Mvvm.ViewModel
{
    /// <summary>
    /// </summary>
    public class AboutViewModel : ApplicationStyleViewModel
    {
        private readonly IAboutWindowContent _aboutWindowContent;

        /// <summary>
        /// </summary>
        /// <param name="aboutWindowContent"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AboutViewModel(IAboutWindowContent aboutWindowContent)

        {
            _aboutWindowContent = aboutWindowContent ?? throw new ArgumentNullException(nameof(aboutWindowContent));
        }

        /// <summary>
        /// </summary>
        public string ApplicationTitle => _aboutWindowContent.Value.ApplicationTitle;

        /// <summary>
        /// </summary>
        public string Company => $"Company / Authors: {_aboutWindowContent.Value.Company}";

        /// <summary>
        /// </summary>
        public string Copyright => $"{_aboutWindowContent.Value.Copyright}";

        /// <summary>
        /// </summary>
        public string Description => _aboutWindowContent.Value.Description;

        /// <summary>
        /// </summary>
        public string LogoSourcePath => _aboutWindowContent.Value.LogoSourcePath;

        /// <summary>
        /// </summary>
        public string Version => $"Version: {_aboutWindowContent.Value.Version}";
    }
}