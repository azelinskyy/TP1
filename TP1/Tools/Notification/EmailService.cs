// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailService.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The email service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tools.Notification
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Threading.Tasks;

    /// <summary>
    /// The email service.
    /// </summary>
    public class EmailService
    {
        #region Public Methods and Operators

        /// <summary>
        /// Send email with proper attachment.
        /// </summary>
        /// <param name="emails">
        /// The email address.
        /// </param>
        /// <param name="output">
        /// The output stream with file.
        /// </param>
        public async Task Send(string emails, Stream output)
        {
            var mailsTo = ParseEmails(emails);
            if (!mailsTo.Any())
            {
                return;
            }

            var configurator = new EmailConfiguration();

            var client = new SmtpClient();

            var mail = new MailMessage();
            mailsTo.ForEach(mailTo => mail.To.Add(mailTo));

            var attachment = new Attachment(output, MediaTypeNames.Application.Pdf);
            attachment.ContentDisposition.FileName = configurator.AttachmentFileName();
            mail.Attachments.Add(attachment);

            await client.SendMailAsync(mail);
        }

        private static List<string> ParseEmails(string emails)
        {
            return emails.Split(',', ';').ToList();
        }

        #endregion
    }
}