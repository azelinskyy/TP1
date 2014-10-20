namespace Tools.Notification
{
    public class EmailConfiguration
    {
        private readonly EmailConfigurationSection configuration;

        public EmailConfiguration()
        {
            this.configuration = (EmailConfigurationSection)System.Configuration.ConfigurationManager.GetSection("emailConfiguration");
        }

        public virtual string AttachmentFileName()
        {
            return this.configuration.AttachmentFileName;
        }
    }
}