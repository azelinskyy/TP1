// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportService.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The service responsible for creating pdf reports.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tools.Export
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    using Model.DomainModels;

    using Tools.Notification;

    /// <summary>
    ///     The pfd-export service.
    /// </summary>
    public class ExportService
    {
        #region Public Methods and Operators

        /// <summary>
        /// Exports list of projects into a stream.
        /// </summary>
        /// <param name="projects">
        /// The enumeration of projects.
        /// </param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        /// <param name="output">
        /// The output stream to export.
        /// </param>
        /// <param name="culture">The culture.</param>
        public void ExportProjects(IEnumerable<Project> projects, DateTime dateFrom, DateTime dateTo, Stream output, CultureInfo culture)
        {
            if (!projects.Any())
            {
                throw new ArgumentException("The collection of projects should not be empty.");
            }

            new ProjectPDFHelper(culture).ExportProjects(projects, dateFrom, dateTo, output);
        }

        /// <summary>
        /// Exports list of projects and send their  as attachment by email.
        /// </summary>
        /// <param name="projects">
        /// The enumeration of projects.
        /// </param>
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        /// <param name="email">The email of recipient.</param>
        /// <param name="culture">The culture.</param>
        public void ExportProjects(IEnumerable<Project> projects, DateTime dateFrom, DateTime dateTo, string email, CultureInfo culture)
        {
            var pdfStream = new MemoryStream();

            this.ExportProjects(projects, dateFrom, dateTo, pdfStream, culture);

            var attachment = new MemoryStream(pdfStream.ToArray());
            attachment.Seek(0, SeekOrigin.Begin);

            new EmailService().Send(email, attachment);
        }

        #endregion
    }
}