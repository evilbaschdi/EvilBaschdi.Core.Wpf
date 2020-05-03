using System;
using System.Linq;
using System.Reflection;

namespace EvilBaschdi.CoreExtended.Controls.About
{
    /// <inheritdoc />
    public class AboutContent : IAboutContent
    {
        private readonly Assembly _assembly;
        private readonly string _logoSourcePath;

        /// <summary>
        ///     Constructor of the class
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="logoSourcePath">AppDomain.CurrentDomain.BaseDirectory</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AboutContent(Assembly assembly, string logoSourcePath)
        {
            _assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
            _logoSourcePath = logoSourcePath ?? throw new ArgumentNullException(nameof(logoSourcePath));
        }

        /// <inheritdoc />
        public AboutModel Value
        {
            get
            {
                var title = _assembly.GetCustomAttributes<AssemblyProductAttribute>().FirstOrDefault() != null
                    ? _assembly.GetCustomAttributes<AssemblyProductAttribute>().FirstOrDefault()?.Product
                    : _assembly.GetCustomAttributes<AssemblyTitleAttribute>().FirstOrDefault()?.Title;

                var config = new AboutModel
                             {
                                 ApplicationTitle = title,
                                 Copyright = _assembly.GetCustomAttributes<AssemblyCopyrightAttribute>().FirstOrDefault()?.Copyright,
                                 Company = _assembly.GetCustomAttributes<AssemblyCompanyAttribute>().FirstOrDefault()?.Company,
                                 Description = _assembly.GetCustomAttributes<AssemblyDescriptionAttribute>().FirstOrDefault()
                                                        ?.Description,
                                 Version = _assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                                    ?.InformationalVersion,
                                 LogoSourcePath = !string.IsNullOrWhiteSpace(_logoSourcePath) ? _logoSourcePath : string.Empty
                             };

                return config;
            }
        }
    }
}