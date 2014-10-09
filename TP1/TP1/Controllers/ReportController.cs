﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportController.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The report controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;

    using DataAccess.Repositories;

    using Model.DomainModels;
    using Model.DTOs;
    using Model.Filters;

    using Newtonsoft.Json;

    using Services.Factories;

    using Tools.Export;

    /// <summary>
    ///     The report controller.
    /// </summary>
    public class ReportController : Controller
    {
        #region Fields

        /// <summary>
        ///     The project convert factory.
        /// </summary>
        private ProjectConvertFactory projectConvertFactory;

        /// <summary>
        ///     The project repository.
        /// </summary>
        private ProjectRepository projectRepository;

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the project convert factory.
        /// </summary>
        public ProjectConvertFactory ProjectConvertFactory
        {
            get
            {
                return this.projectConvertFactory = this.projectConvertFactory ?? new ProjectConvertFactory();
            }
        }

        /// <summary>
        ///     Gets the project repository.
        /// </summary>
        public ProjectRepository ProjectRepository
        {
            get
            {
                return this.projectRepository = this.projectRepository ?? new ProjectRepository();
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The export.
        /// </summary>
        /// <param name="export">
        /// The data with export info - email, from/to, language.
        /// </param>
        public void Export(ExportConfiguration export)
        {
            IList<Project> projects = this.ProjectRepository.GetProjectsFilteredByDateRange(new ProjectGridFilter { From = export.From, To = export.To });
            new ExportService(Server.MapPath("~/bin")).ExportProjects(projects, export);
        }

        /// <summary>
        /// The get accaptable projects range.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Project> GetAcceptableProjectsRange(ProjectGridFilter filter)
        {
            return this.ProjectRepository.GetProjectsFilteredByDateRange(filter);
        }

        /// <summary>
        /// The get report.
        /// </summary>
        /// <param name="filter">
        /// The grid filter.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetReport(ProjectGridFilter filter)
        {
            string jsonData = JsonConvert.SerializeObject(this.SortReport(filter));
            return
                JsonConvert.SerializeObject(
                    new
                        {
                            totalRows = this.ProjectRepository.GetProjectsFilteredByDateRangeCount(filter),
                            result = jsonData
                        });
        }

        /// <summary>
        /// Gets file with report to user download.
        /// </summary>
        /// <param name="export">The parameters for report.</param>
        /// <returns>The file.</returns>
        public ActionResult SaveAs(ExportConfiguration export)
        {
            IList<Project> projects = this.ProjectRepository.GetProjectsFilteredByDateRange(new ProjectGridFilter { From = export.From, To = export.To });
            return this.File(new ExportService(Server.MapPath("~/bin")).ExportProjectsToStream(projects, export), "application/pdf", "download.pdf");
        }

        #endregion

        #region Methods

        /// <summary>
        /// The sort report.
        /// </summary>
        /// <param name="filter">
        /// The grid filter with order, page size and proper field to perform sorting.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        private IList<ProjectDto> SortReport(ProjectGridFilter filter)
        {
            IEnumerable<Project> filteredList = this.ProjectRepository.GetProjectsFilteredByProjectGrid(filter);
            return filteredList.Select(this.ProjectConvertFactory.FromModel).ToList();
        }

        #endregion
    }
}