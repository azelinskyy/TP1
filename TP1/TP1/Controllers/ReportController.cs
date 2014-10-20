// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportController.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The report controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using DataAccess.Repositories;
    using DataAccess.Repositories.Interfaces.Async;

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
        private IProjectRepositoryAsync projectRepositoryAsync;

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
        public IProjectRepositoryAsync ProjectRepositoryAsync
        {
            get
            {
                return this.projectRepositoryAsync = this.projectRepositoryAsync ?? new ProjectRepositoryAsync();
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
        public async Task Export(ExportContext export)
        {
            IList<Project> projects =
                await this.ProjectRepositoryAsync.GetProjectsFilteredByDateRangeExcludingIdsAsync(
                    new ProjectGridFilter { From = export.From, To = export.To, UnselectedIds = export.UnselectedIds });
            await new ExportService(Server.MapPath("~/bin")).ExportProjects(projects, export);
        }

        /// <summary>
        /// The get accaptable projects range.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        public async Task<IEnumerable<Project>> GetAcceptableProjectsRange(ProjectGridFilter filter)
        {
            return await this.ProjectRepositoryAsync.GetProjectsFilteredByDateRangeExcludingIdsAsync(filter);
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
        public async Task<string> GetReport(ProjectGridFilter filter)
        {
            string jsonData = JsonConvert.SerializeObject(await this.SortReport(filter));
            return
                JsonConvert.SerializeObject(
                    new
                        {
                            totalRows = await this.ProjectRepositoryAsync.GetProjectsFilteredByDateRangeCountAsync(filter),
                            result = jsonData
                        });
        }

        /// <summary>
        /// Gets file with report to user download.
        /// </summary>
        /// <param name="export">The parameters for report.</param>
        /// <returns>The file.</returns>
        public async Task<ActionResult> SaveAs(ExportContext export)
        {
            IList<Project> projects =
                await this.ProjectRepositoryAsync.GetProjectsFilteredByDateRangeExcludingIdsAsync(
                    new ProjectGridFilter { From = export.From, To = export.To, UnselectedIds = export.UnselectedIds });
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
        private async Task<IList<ProjectDto>> SortReport(ProjectGridFilter filter)
        {
            IEnumerable<Project> filteredList = await this.ProjectRepositoryAsync.GetProjectsFilteredByProjectGridAsync(filter);
            return filteredList.Select(this.ProjectConvertFactory.FromModel).ToList();
        }

        #endregion
    }
}