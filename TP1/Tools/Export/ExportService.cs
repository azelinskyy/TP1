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
    using System.Collections.Generic;
    using System.IO;

    using Model.DomainModels;

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
        /// <param name="output">
        /// The output stream to export.
        /// </param>
        public void ExportProjects(IEnumerable<Project> projects, Stream output)
        {
            new PDFHelper().ExportProjects(projects, output);
        }

        #endregion
    }
}