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
        /// <param name="dateFrom">The start date.</param>
        /// <param name="dateTo">The end date.</param>
        /// <param name="output">
        /// The output stream to export.
        /// </param>
        public void ExportProjects(List<Project> projects, DateTime dateFrom, DateTime dateTo, FileStream output)
        {
            new ProjectPDFHelper().ExportProjects(projects, dateFrom, dateTo, output);
        }

        #endregion
    }
}