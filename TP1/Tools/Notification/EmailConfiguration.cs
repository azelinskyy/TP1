namespace Tools.Notification
{
    public class EmailConfiguration
    {
        private readonly EmailConfigurationSection _configuration;

        public EmailConfiguration()
        {
            this._configuration = (EmailConfigurationSection)System.Configuration.ConfigurationManager.GetSection("emailConfiguration");
        }

        public virtual string AttachmentFileName()
        {
            return this._configuration.AttachmentFileName;
        }
    }
}