// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportProjects.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The export projects tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTests.Tools
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using Model.DomainModels;

    using NUnit.Framework;

    using global::Tools.Export;

    /// <summary>
    /// The export projects tests.
    /// </summary>
    [TestFixture]
    public class ExportProjects
    {
        #region Fields

        /// <summary>
        /// The project stub.
        /// </summary>
        private readonly Project project = new Project
                                               {
                                                   City = new City { Name = "Basel" },
                                                   ZipCode = "4051",
                                                   Title =
                                                       "Ausbau des Hauptsitzes der Bank für Internationalen Zahlungsausgleich",
                                                   Description =
                                                       "Auf dem Saurer-Areal in Steinach soll ein rund sechzig Meter hohes Hochhaus mit 19 Geschossen errichtet werden. Im Neubau finden Gewerbe (Erdgeschoss), Büros (die nächsten drei Geschosse) und 89 Wohnungen (Obergeschosse 4 bis 18) Platz. Ausserdem sind zwei Tiefgaragengeschosse vorgesehen. Seit dem Abschluss des Projektwettbewerbs vor 10 Monaten hat sich das siegreiche Büro Gmür & Geschwentener Architekten AG mit der Überarbeitung des Projektes beschäftigt.",
                                                   Address =
                                                       new Address { AddressString = "Saurer-Areal WerkZwei" },
                                                   Architect =
                                                       new Company
                                                           {
                                                               Name =
                                                                   "Gmür & Geschwentner Architekten AG, Zürich"
                                                           },
                                                   Owner = new Company { Name = "SPS Immobilien AG, Olten" },
                                                   Price = 240000000,
                                                   Space =
                                                       "Gebäudefläche: 38 m Länge, 22 m Breite, die Gesamthöhe 64 m",
                                                   StartDate =
                                                       new DomainDate { Description = "erste Jahreshälfte 2015" },
                                                   FinishDate = new DomainDate { Description = "frühestens 2020" }
                                               };

        private CultureInfo culture;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Exports projects to pdf and check file size after that.
        /// </summary>
        [Test]
        public void ExportProjectsToPDF()
        {
            string fileName = "test.pdf";

            var projects = new List<Project>();
            for (var i = 0; i < 20; i++)
            {
                projects.Add(this.project);
            }

            var to = DateTime.Now;
            var from = to.AddDays(-7);

            var configuration = new ExportConfiguration { Culture = "en-US", Email = "gregory.hasyn@gmail.com", From = from, To = to, Model = ReportModels.Columns };

            var service = new ExportService();
            var output = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            service.ExportProjects(projects, configuration, output);

            var fileInfo = new FileInfo(fileName);
            Assert.True(fileInfo.Length > 0);
            //// fileInfo.Delete();
        }

        /// <summary>
        /// Exports empty collection to pdf should throw exception.
        /// </summary>
        [Test]
        public void ExportEmptyToPDF()
        {
            string fileName = "empty.pdf";

            var projects = new List<Project>();

            var to = DateTime.Now;
            var from = to.AddDays(-7);

            var configuration = new ExportConfiguration { Culture = "en-US", Email = "gregory.hasyn@gmail.com", From = from, To = to, Model = ReportModels.Columns };

            var service = new ExportService();
            var output = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            Assert.Throws<ArgumentException>(() => service.ExportProjects(projects, configuration, output));
        }

        /// <summary>
        /// Exports projects to pdf and check file size after that.
        /// </summary>
        [Test]
        public void ExportProjectsToPDFAndSendEmail()
        {
            var projects = new List<Project>();
            for (var i = 0; i < 20; i++)
            {
                projects.Add(this.project);
            }

            var to = DateTime.Now;
            var from = to.AddDays(-7);

            var configuration = new ExportConfiguration { Culture = "en-US", Email = "gregory.hasyn@gmail.com", From = from, To = to, Model = ReportModels.Columns };

            var service = new ExportService();
            service.ExportProjects(projects, configuration);
        }

        #endregion
    }
}