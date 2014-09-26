namespace TP1.DTOs
{
    using System;

    public class ReportDto
    {
        public string Title { get; set; }

        public int ZipCode { get; set; }

        public DateTime DateStart { get; set; }

        public CompanyDto Company { get; set; }
    }
}