namespace TP1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Mvc;

    using DataAccess.Repositories;

    using Model.DomainModels;
    using Model.DTOs;

    using Newtonsoft.Json;

    using Services.Factories;

    public class ReportController : Controller
    {
        private ProjectRepository projectRepository;

        private ProjectConvertFactory projectConvertFactory;

        public ProjectRepository ProjectRepository 
        {
            get
            {
                return this.projectRepository = this.projectRepository ?? new ProjectRepository();
            }
        }

        public ProjectConvertFactory ProjectConvertFactory
        {
            get
            {
                return this.projectConvertFactory = this.projectConvertFactory ?? new ProjectConvertFactory();
            }
        }

        [HttpPost]
        public string GetAllStudentList()
        {
            var data = this.BuildReports();
            return JsonConvert.SerializeObject(new { totalRows = data.Count(), result = data });
        }

        public string GetReport(int pageIndex = 1, int pageSize = 10, string sortField = "", int sortOrder = 0)
        {
            var data = this.BuildReports();
            var jsonData = JsonConvert.SerializeObject(this.SortReport(data, pageIndex, pageSize, sortField, (SortOrder)sortOrder));
            return JsonConvert.SerializeObject(new { totalRows = data.Count(), result = jsonData });
        }

        public void DeleteProject(int id)
        {
            Project projectToRemove = this.ProjectRepository.GetById(id);
            this.projectRepository.Remove(projectToRemove);
        }
        
        public ProjectDto GetProject(int id)
        {
            return this.ProjectConvertFactory.FromModel(this.ProjectRepository.GetById(id));
        }

        public int PostProject(ProjectDto project)
        {
            var entity = this.ProjectConvertFactory.ToModel(project);
            this.projectRepository.Add(entity);
            return entity.Id;
        }

        public void PutProject(int id, ProjectDto project)
        {
            var entity = this.ProjectConvertFactory.ToModel(project);
            if (entity.Id != id)
            {
                throw new ArgumentOutOfRangeException("Ids do not match");
            }

            this.ProjectRepository.Update(entity);
        }

        private IList<ProjectDto> SortReport(IEnumerable<ProjectDto> data, int pageIndex, int pageSize, string sortField, SortOrder order)
        {
            IList<ProjectDto> result;

            if (order == SortOrder.Ascending)
            {
                if (sortField.ToLower() == "ZipCode")
                {
                    result = data.OrderBy(x => x.ZipCode).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                }
                else
                {
                    result = data.OrderBy(x => x.Title).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                }
            }
            else
            {
                if (sortField.ToLower() == "ZipCode")
                {
                    result = data.OrderByDescending(x => x.ZipCode).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                }
                else
                {
                    result = data.OrderByDescending(x => x.Title).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                }
            }

            return result;
        }

        private List<ProjectDto> BuildReports()
        {
            var converter = new ProjectConvertFactory();
            return this.ProjectRepository.GetAll().Select(converter.FromModel).ToList();

            // replace code above withthis one for initial insert of test data
            /*var companyA = new City { Name = "Lviv" };
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
            repo.AddRange(reports);
            var converter = new ProjectConvertFactory();
            return reports.Select(converter.FromModel).ToList();*/
        }
    }
}
