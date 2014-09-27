namespace TP1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Mvc;

    using Model.DTOs;

    using Newtonsoft.Json;

    public class ReportController : Controller
    {
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
            var companyA = new CityDto { Name = "Lviv" };
            var companyB = new CityDto { Name = "Dresden" };
            var reports = new List<ProjectDto>
                              {
                                  new ProjectDto { Title = "AA", ZipCode = 10.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AB", ZipCode = 11.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AC", ZipCode = 12.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AD", ZipCode = 13.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AE", ZipCode = 14.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AF", ZipCode = 15.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AG", ZipCode = 16.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AH", ZipCode = 17.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AI", ZipCode = 18.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AJ", ZipCode = 19.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AK", ZipCode = 20.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AL", ZipCode = 21.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AM", ZipCode = 22.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AN", ZipCode = 23.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AO", ZipCode = 24.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "AP", ZipCode = 25.ToString(), City = companyA, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BA", ZipCode = 10.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BB", ZipCode = 11.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BC", ZipCode = 12.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BD", ZipCode = 13.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BE", ZipCode = 14.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BF", ZipCode = 15.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BG", ZipCode = 16.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BH", ZipCode = 17.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BI", ZipCode = 18.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BJ", ZipCode = 19.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BK", ZipCode = 20.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BL", ZipCode = 21.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BM", ZipCode = 22.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BN", ZipCode = 23.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BO", ZipCode = 24.ToString(), City = companyB, DateAdded = DateTime.Now },
                                  new ProjectDto { Title = "BP", ZipCode = 25.ToString(), City = companyB, DateAdded = DateTime.Now }
                              };

            return reports;
        }
    }
}
