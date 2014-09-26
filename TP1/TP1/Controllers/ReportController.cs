namespace TP1.Controllers
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using TP1.DTOs;

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

        private IList<ReportDto> SortReport(IList<ReportDto> data, int pageIndex, int pageSize, string sortField, SortOrder order)
        {
            IList<ReportDto> result;

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

        private List<ReportDto> BuildReports()
        {
            var companyA = new CompanyDto { Name = "company A", Address = "Location A" };
            var companyB = new CompanyDto { Name = "company B", Address = "Location B" };
            var reports = new List<ReportDto>
                              {
                                  new ReportDto { Title = "AA", ZipCode = 10, Company = companyA },
                                  new ReportDto { Title = "AB", ZipCode = 11, Company = companyA },
                                  new ReportDto { Title = "AC", ZipCode = 12, Company = companyA },
                                  new ReportDto { Title = "AD", ZipCode = 13, Company = companyA },
                                  new ReportDto { Title = "AE", ZipCode = 14, Company = companyA },
                                  new ReportDto { Title = "AF", ZipCode = 15, Company = companyA },
                                  new ReportDto { Title = "AG", ZipCode = 16, Company = companyA },
                                  new ReportDto { Title = "AH", ZipCode = 17, Company = companyA },
                                  new ReportDto { Title = "AI", ZipCode = 18, Company = companyA },
                                  new ReportDto { Title = "AJ", ZipCode = 19, Company = companyA },
                                  new ReportDto { Title = "AK", ZipCode = 20, Company = companyA },
                                  new ReportDto { Title = "AL", ZipCode = 21, Company = companyA },
                                  new ReportDto { Title = "AM", ZipCode = 22, Company = companyA },
                                  new ReportDto { Title = "AN", ZipCode = 23, Company = companyA },
                                  new ReportDto { Title = "AO", ZipCode = 24, Company = companyA },
                                  new ReportDto { Title = "AP", ZipCode = 25, Company = companyA },
                                  new ReportDto { Title = "BA", ZipCode = 10, Company = companyB },
                                  new ReportDto { Title = "BB", ZipCode = 11, Company = companyB },
                                  new ReportDto { Title = "BC", ZipCode = 12, Company = companyB },
                                  new ReportDto { Title = "BD", ZipCode = 13, Company = companyB },
                                  new ReportDto { Title = "BE", ZipCode = 14, Company = companyB },
                                  new ReportDto { Title = "BF", ZipCode = 15, Company = companyB },
                                  new ReportDto { Title = "BG", ZipCode = 16, Company = companyB },
                                  new ReportDto { Title = "BH", ZipCode = 17, Company = companyB },
                                  new ReportDto { Title = "BI", ZipCode = 18, Company = companyB },
                                  new ReportDto { Title = "BJ", ZipCode = 19, Company = companyB },
                                  new ReportDto { Title = "BK", ZipCode = 20, Company = companyB },
                                  new ReportDto { Title = "BL", ZipCode = 21, Company = companyB },
                                  new ReportDto { Title = "BM", ZipCode = 22, Company = companyB },
                                  new ReportDto { Title = "BN", ZipCode = 23, Company = companyB },
                                  new ReportDto { Title = "BO", ZipCode = 24, Company = companyB },
                                  new ReportDto { Title = "BP", ZipCode = 25, Company = companyB }
                              };

            return reports;
        }
    }
}
