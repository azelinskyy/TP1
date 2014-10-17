using System.Configuration;

namespace Tools.Notification
{
    public class EmailConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("attachmentFileName", DefaultValue = "attachment.pdf", IsRequired = false)]
        public string AttachmentFileName
        {
            get
            {
                return (string)this["attachmentFileName"];
            }
            set
            {
                this["attachmentFileName"] = value;
            }
        }
    }
}
