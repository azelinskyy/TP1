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
        /// <param name="configuration">
        /// The configuration for export.
        /// </param>
        public void ExportProjects(IEnumerable<Project> projects, ExportConfiguration configuration, Stream output)
        {
            if (!projects.Any())
            {
                throw new ArgumentException("The collection of projects should not be empty.");
            }

            var pdfHelper = new ProjectPDFHelper(new CultureInfo(configuration.Culture));
            if (configuration.Model == ReportModels.Columns)
            {
                pdfHelper.ExportProjects(projects, configuration, output);
            }
            else
            {
                pdfHelper.ExportProjectsAsTable(projects, configuration, output);
            }
        }

        /// <summary>
        /// Exports list of projects and send their  as attachment by email.
        /// </summary>
        /// <param name="projects">
        /// The enumeration of projects.
        /// </param>
        /// <param name="configuration">
        /// The configuration for export.
        /// </param>
        public void ExportProjects(IEnumerable<Project> projects, ExportConfiguration configuration)
        {
            var pdfStream = new MemoryStream();

            this.ExportProjects(projects, configuration, pdfStream);

            var attachment = new MemoryStream(pdfStream.ToArray());
            attachment.Seek(0, SeekOrigin.Begin);

            new EmailService().Send(configuration.Emails, attachment);
        }

        #endregion
    }
}