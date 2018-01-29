using System;
using System.Xml.Serialization;

namespace EvilBaschdi.TestUi.NuGet
{
    [Serializable]
    [XmlRoot("packages")]
    public class PackageCollection
    {
        [XmlElement("package")]
        public Package[] Packages { get; set; }
    }
}