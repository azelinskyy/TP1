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
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Web.Mvc;

    using DataAccess.Repositories;

    using Model.DomainModels;
    using Model.DTOs;

    using Newtonsoft.Json;

    using Services.Factories;

    using Tools.Export;

    using TP1.Models;

    /// <summary>
    /// The report controller.
    /// </summary>
    public class ReportController : Controller
    {
        #region Fields

        /// <summary>
        /// The project convert factory.
        /// </summary>
        private ProjectConvertFactory projectConvertFactory;

        /// <summary>
        /// The project repository.
        /// </summary>
        private ProjectRepository projectRepository;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the project convert factory.
        /// </summary>
        public ProjectConvertFactory ProjectConvertFactory
        {
            get
            {
                return this.projectConvertFactory = this.projectConvertFactory ?? new ProjectConvertFactory();
            }
        }

        /// <summary>
        /// Gets the project repository.
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
        /// The delete project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void DeleteProject(int id)
        {
            Project projectToRemove = this.ProjectRepository.GetById(id);
            this.projectRepository.Remove(projectToRemove);
        }

        /// <summary>
        /// The export.
        /// </summary>
        /// <param name="export">
        /// The data with export info - email, from/to, language.
        /// </param>
        public void Export(ExportModel export)
        {
            IEnumerable<Project> projects =
                this.ProjectRepository.GetAll().Where(p => p.DateAdded >= export.From && p.DateAdded <= export.To);
            new ExportService().ExportProjects(projects, export.From, export.To, export.Email, new CultureInfo(export.Language));
        }

        /// <summary>
        /// The get all product.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult GetAllProduct()
        {
            List<ProjectDto> data = this.BuildReports();
            return this.Json(data, JsonRequestBehavior.AllowGet);

            var products = new List<Product>();

            // Add products for the Demonstration
            products.Add(new Product { Id = 1, Name = "Computer", Category = "Electronics", Price = 23.54M });
            products.Add(new Product { Id = 2, Name = "Laptop", Category = "Electronics", Price = 33.75M });
            products.Add(new Product { Id = 3, Name = "iPhone4", Category = "Phone", Price = 16.99M });
            return this.Json(products, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The get all student list.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [HttpPost]
        public string GetAllStudentList()
        {
            List<ProjectDto> data = this.BuildReports();
            return JsonConvert.SerializeObject(new { totalRows = data.Count(), result = data });
        }

        /// <summary>
        /// The get project.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDto"/>.
        /// </returns>
        public ProjectDto GetProject(int id)
        {
            return this.ProjectConvertFactory.FromModel(this.ProjectRepository.GetById(id));
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
        public string GetReport(GridFilter filter)
        {
            List<ProjectDto> data = this.BuildReports();
            string jsonData =
                JsonConvert.SerializeObject(this.SortReport(data, filter));
            return JsonConvert.SerializeObject(new { totalRows = data.Count(), result = jsonData });
        }

        /// <summary>
        /// The post project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int PostProject(ProjectDto project)
        {
            Project entity = this.ProjectConvertFactory.ToModel(project);
            this.projectRepository.Add(entity);
            return entity.Id;
        }

        /// <summary>
        /// The put project.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        public void PutProject(ProjectDto project)
        {
            Project entity = this.ProjectConvertFactory.ToModel(project);

            this.ProjectRepository.Update(entity);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The build reports.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        private List<ProjectDto> BuildReports()
        {
            var converter = new ProjectConvertFactory();

            /*
            // replace code above withthis one for initial insert of test data
            var companyA = new City { Name = "Lviv" };
            var companyB = new City { Name = "Dresden" };
            var reports = new List<Project>
                              {
                                  new Project { Title = "AA", ZipCode = 79010.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AB", ZipCode = 79011.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AC", ZipCode = 79012.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AD", ZipCode = 79013.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AE", ZipCode = 79014.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AF", ZipCode = 79015.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AG", ZipCode = 79016.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AH", ZipCode = 79017.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AI", ZipCode = 79018.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AJ", ZipCode = 79019.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AK", ZipCode = 79020.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AL", ZipCode = 79021.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AM", ZipCode = 79022.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AN", ZipCode = 79023.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AO", ZipCode = 79024.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "AP", ZipCode = 79025.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new Project { Title = "BA", ZipCode = 79010.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BB", ZipCode = 79011.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BC", ZipCode = 79012.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BD", ZipCode = 79013.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BE", ZipCode = 79014.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BF", ZipCode = 79015.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BG", ZipCode = 79016.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BH", ZipCode = 79017.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BI", ZipCode = 79018.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BJ", ZipCode = 79019.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BK", ZipCode = 79020.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BL", ZipCode = 79021.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BM", ZipCode = 79022.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BN", ZipCode = 79023.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BO", ZipCode = 79024.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new Project { Title = "BP", ZipCode = 79025.ToString(), City = companyB, DateAdded = DateTime.Now }
                              };

            var repo = new ProjectRepository();
            repo.AddRange(reports);*/
            return this.ProjectRepository.GetAll().Select(converter.FromModel).ToList();
        }

        /// <summary>
        /// The sort report.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="filter">
        /// The grid filter with order, page size and proper field to perform sorting.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        private IList<ProjectDto> SortReport(
            IEnumerable<ProjectDto> data,
            GridFilter filter)
        {
            IList<ProjectDto> result;

            if (filter.SortOrder == SortOrder.Ascending)
            {
                if (filter.SortField.ToLower() == "ZipCode")
                {
                    result = data.OrderBy(x => x.ZipCode).Skip(filter.PageSize * (filter.PageIndex - 1)).Take(filter.PageSize).ToList();
                }
                else
                {
                    result = data.OrderBy(x => x.Title).Skip(filter.PageSize * (filter.PageIndex - 1)).Take(filter.PageSize).ToList();
                }
            }
            else
            {
                if (filter.SortField.ToLower() == "ZipCode")
                {
                    result =
                        data.OrderByDescending(x => x.ZipCode).Skip(filter.PageSize * (filter.PageIndex - 1)).Take(filter.PageSize).ToList();
                }
                else
                {
                    result =
                        data.OrderByDescending(x => x.Title).Skip(filter.PageSize * (filter.PageIndex - 1)).Take(filter.PageSize).ToList();
                }
            }

            return result;
        }

        #endregion

        /// <summary>
        /// The product.
        /// </summary>
        public class Product
        {
            #region Public Properties

            /// <summary>
            /// Gets or sets the category.
            /// </summary>
            public string Category { get; set; }

            /// <summary>
            /// Gets or sets the id.
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the price.
            /// </summary>
            public decimal Price { get; set; }

            #endregion
        }
    }
}