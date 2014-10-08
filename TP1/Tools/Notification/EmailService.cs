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
            var mailsTo = emails.Split(',', ';').ToList();
            if (!mailsTo.Any())
            {
                return;
            }

            var client = new SmtpClient
                             {
                                 UseDefaultCredentials = false,
                                 Credentials = new NetworkCredential("bindexis", "Welcome!"),
                                 Host = "localhost",
                                 Port = 25,
                                 DeliveryMethod = SmtpDeliveryMethod.Network,
                                 EnableSsl = false
                             };

            var mail = new MailMessage();
            mailsTo.ForEach(mailTo => mail.To.Add(mailTo));

            var attachment = new Attachment(output, MediaTypeNames.Application.Pdf);
            attachment.ContentDisposition.FileName = "attachment.pdf";
            mail.Attachments.Add(attachment);

            client.Send(mail);
        }

        #endregion
    }
}