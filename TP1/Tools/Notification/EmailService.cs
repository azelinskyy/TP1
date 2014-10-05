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

            var client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("my_manhattan_2014@yahoo.com", "+{_P)O9i8u7y");
            client.Host = "smtp.mail.yahoo.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            var mail = new MailMessage();
            mail.From = new MailAddress("my_manhattan_2014@yahoo.com");
            mailsTo.ForEach(mailTo => mail.To.Add(mailTo));

            var attachment = new Attachment(output, MediaTypeNames.Application.Pdf);
            attachment.ContentDisposition.FileName = "attachment.pdf";
            mail.Attachments.Add(attachment);

            client.Send(mail);
        }

        #endregion
    }
}