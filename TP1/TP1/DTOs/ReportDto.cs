using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1.DTOs
{
    public class ReportDto
    {
        public string Title { get; set; }

        public int ZipCode { get; set; }

        public DateTime DateStart { get; set; }

        public CompanyDto Company { get; set; }
    }
}