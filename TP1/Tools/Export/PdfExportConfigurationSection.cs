namespace Tools.Export
{
    using System.Configuration;

    public class PdfExportConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("fontPath", DefaultValue = "arialuni.ttf", IsRequired = false)]
        public string FontPath
        {
            get
            {
                return (string)this["fontPath"];
            }

            set
            {
                this["fontPath"] = value;
            }
        }

        [ConfigurationProperty("logoPath", DefaultValue = "logo.gif", IsRequired = false)]
        public string LogoPath
        {
            get
            {
                return (string)this["logoPath"];
            }

            set
            {
                this["logoPath"] = value;
            }
        }
    }
}
