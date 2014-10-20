namespace Tools.Export
{
    using System;
    using System.IO;

    public class PdfExportConfiguration
    {
        private readonly PdfExportConfigurationSection configuration;

        public PdfExportConfiguration()
        {
            this.configuration = (PdfExportConfigurationSection)System.Configuration.ConfigurationManager.GetSection("pdfExportConfiguration");
        }

        public virtual string GetFontPath()
        {
            return GetAbsolutePath(this.configuration.FontPath);
        }

        public virtual string GetLogoPath()
        {
            return GetAbsolutePath(this.configuration.LogoPath);
        }

        private static string GetAbsolutePath(string path)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        }
    }
}