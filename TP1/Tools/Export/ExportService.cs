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
    using System.Threading.Tasks;

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
        /// <param name="context">
        /// The context for export.
        /// </param>
        /// <param name="output">
        /// The output of export.
        /// </param>
        public void ExportProjects(IEnumerable<Project> projects, ExportContext context, Stream output)
        {
            if (!projects.Any())
            {
                throw new ArgumentException("The collection of projects should not be empty.");
            }

            var pdfHelper = new ProjectPDFHelper(new CultureInfo(context.Culture));
            if (context.Model == ReportModels.Columns)
            {
                pdfHelper.ExportProjects(projects, context, output);
            }
            else
            {
                pdfHelper.ExportProjectsAsTable(projects, context, output);
            }
        }

        /// <summary>
        /// Exports list of projects and send their  as attachment by email.
        /// </summary>
        /// <param name="projects">
        /// The enumeration of projects.
        /// </param>
        /// <param name="context">
        /// The context for export.
        /// </param>
        public async Task ExportProjects(IEnumerable<Project> projects, ExportContext context)
        {
            var pdfStream = new MemoryStream();

            this.ExportProjects(projects, context, pdfStream);

            var attachment = new MemoryStream(pdfStream.ToArray());
            attachment.Seek(0, SeekOrigin.Begin);

            await new EmailService().Send(context.Emails, attachment);
        }

        /// <summary>
        /// Exports list of projects and send their  as attachment by email.
        /// </summary>
        /// <param name="projects">
        /// The enumeration of projects.
        /// </param>
        /// <param name="context">
        /// The context for export.
        /// </param>
        public Stream ExportProjectsToStream(IEnumerable<Project> projects, ExportContext context)
        {
            var pdfStream = new MemoryStream();

            this.ExportProjects(projects, context, pdfStream);

            var output = new MemoryStream(pdfStream.ToArray());
            output.Seek(0, SeekOrigin.Begin);

            return output;
        }

        #endregion
    }
}