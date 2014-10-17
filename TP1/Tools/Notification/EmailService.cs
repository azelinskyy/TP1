// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailService.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The email service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Tools.Notification
{
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;

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
        public void Send(string emails, Stream output)
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

            client.Send(mail);
        }

        private static List<string> ParseEmails(string emails)
        {
            return emails.Split(',', ';').ToList();
        }

        #endregion
    }
}