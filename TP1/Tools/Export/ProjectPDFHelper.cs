// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectPDFHelper.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   Helper to perform export into pdf-file (stream).
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tools.Export
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using Model.DomainModels;

    using Resources;

    /// <summary>
    ///     Helper to perform export into pdf-file (stream).
    /// </summary>
    internal class ProjectPDFHelper
    {
        #region Constants

        /// <summary>
        ///     Leading for paragraph or phrase.
        /// </summary>
        private const int Leading = 10;

        #endregion

        #region Static Fields

        //// private static readonly BaseFont BaseCyrFont = BaseFont.CreateFont(@"C:\Windows\fonts\Helvetica.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED); 

        /// <summary>
        ///     The bold fond const to internal use.
        /// </summary>
        private static readonly Font Bold = new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD);

        /// <summary>
        ///     The normal fond const to internal use.
        /// </summary>
        private static readonly Font Normal = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL);

        #endregion

        #region Fields

        /// <summary>
        /// The culture.
        /// </summary>
        private readonly CultureInfo culture;

        /// <summary>
        /// The resource service.
        /// </summary>
        private readonly ResourceService resourceService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPDFHelper"/> class.
        /// </summary>
        /// <param name="culture">
        /// The culture.
        /// </param>
        public ProjectPDFHelper(CultureInfo culture)
        {
            this.culture = culture;
            this.resourceService = new ResourceService(culture);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create the project paragraph.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="Paragraph"/>.
        /// </returns>
        internal Paragraph CreateProjectParagraph(Project project)
        {
            var item = new Paragraph();
            item.Leading = Leading;
            item.Add(CreateProjectHeader(project));
            item.Add(Chunk.NEWLINE);
            item.Add(new Phrase(project.Title, Bold));
            item.Add(Chunk.NEWLINE);
            item.Add(new Phrase(project.Description, Normal));
            item.Add(Chunk.NEWLINE);
            AddIfPresent(
                project.Address, 
                a => !string.IsNullOrEmpty(a.AddressString), 
                a => CreatePhrase(this.resourceService["Address"], a.AddressString), 
                item);
            AddIfPresent(project.Architect, a => !string.IsNullOrEmpty(a.Name), a => CreatePhrase(this.resourceService["A_acrchitect"], a.Name), item);
            AddIfPresent(project.Owner, o => !string.IsNullOrEmpty(o.Name), o => CreatePhrase(this.resourceService["B_builder"], o.Name), item);
            AddIfPresent(
                project.Price, 
                p => p > 0, 
                p => CreatePhrase(this.resourceService["ConstructionCost"], p.ToString(CultureInfo.InvariantCulture)), 
                item);
            AddIfPresent(project.Space, s => !string.IsNullOrEmpty(s), s => CreatePhrase(this.resourceService["AreaVolume"], s), item);
            AddIfPresent(
                project.StartDate, 
                sd => !string.IsNullOrEmpty(sd.Description), 
                sd => CreatePhrase(this.resourceService["PlanningApplication"], sd.Description), 
                item);
            AddIfPresent(
                project.FinishDate, 
                fd => !string.IsNullOrEmpty(fd.Description), 
                fd => CreatePhrase(this.resourceService["SubscribeTermsPlanned"], fd.Description), 
                item);
            item.Add(Chunk.NEWLINE);
            return item;
        }

        /// <summary>
        /// Create the project paragraph.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="Paragraph"/>.
        /// </returns>
        internal IEnumerable<IElement> CreateProjectPhrases(Project project)
        {
            var result = new List<IElement>();
            result.Add(CreateProjectHeader(project));
            result.Add(new Phrase(project.Title, Bold) { Leading = Leading });
            result.Add(new Phrase(project.Description, Normal) { Leading = Leading });
            AddIfPresent(
                project.Address, 
                a => !string.IsNullOrEmpty(a.AddressString), 
                a => CreatePhrase(this.resourceService["Address"], a.AddressString), 
                result);
            AddIfPresent(project.Architect, a => !string.IsNullOrEmpty(a.Name), a => CreatePhrase(this.resourceService["A_acrchitect"], a.Name), result);
            AddIfPresent(project.Owner, o => !string.IsNullOrEmpty(o.Name), o => CreatePhrase(this.resourceService["B_builder"], o.Name), result);
            AddIfPresent(
                project.Price, 
                p => p > 0, 
                p => CreatePhrase(this.resourceService["ConstructionCost"], p.ToString(CultureInfo.InvariantCulture)), 
                result);
            AddIfPresent(project.Space, s => !string.IsNullOrEmpty(s), s => CreatePhrase(this.resourceService["AreaVolume"], s), result);
            AddIfPresent(
                project.StartDate, 
                sd => !string.IsNullOrEmpty(sd.Description), 
                sd => CreatePhrase(this.resourceService["PlanningApplication"], sd.Description), 
                result);
            AddIfPresent(
                project.FinishDate, 
                fd => !string.IsNullOrEmpty(fd.Description), 
                fd => CreatePhrase(this.resourceService["SubscribeTermsPlanned"], fd.Description), 
                result);
            result.Add(Chunk.NEWLINE);
            return result;
        }

        /// <summary>
        /// Exports projects into output stream.
        /// </summary>
        /// <param name="projects">
        /// The enumeration of projects.
        /// </param>
        /// <param name="dateFrom">
        /// The start date.
        /// </param>
        /// <param name="dateTo">
        /// The end date.
        /// </param>
        /// <param name="output">
        /// The output stream.
        /// </param>
        internal void ExportProjects(IEnumerable<Project> projects, DateTime dateFrom, DateTime dateTo, Stream output)
        {
            var document = new Document();
            var writer = PdfWriter.GetInstance(document, output);
            writer.PageEvent = new ProjectPageEventHelper(dateFrom, dateTo, this.culture);

            document.SetMargins(
                document.LeftMargin, 
                document.RightMargin, 
                document.TopMargin * 2, 
                document.BottomMargin * 2);

            document.Open();

            var column = 0;
            var space = 20;
            var columnWight = (document.Right - document.Left - (2 * space)) / 3;
            float[][] columnPoints =
                {
                    new[]
                        {
                            document.Left, document.Bottom, document.Left + columnWight, document.Top
                        }, 
                    new[]
                        {
                            document.Left + columnWight + space, document.Bottom, 
                            document.Left + (2 * columnWight) + space, document.Top
                        }, 
                    new[]
                        {
                            document.Left + (2 * (columnWight + space)), document.Bottom, 
                            document.Left + (3 * columnWight) + (2 * space), document.Top
                        }
                };

            var columnText = new ColumnText(writer.DirectContent);
            columnText.SetSimpleColumn(
                columnPoints[column][0], 
                columnPoints[column][1], 
                columnPoints[column][2], 
                columnPoints[column][3]);
            foreach (var project in projects)
            {
                var elements = this.CreateProjectPhrases(project);
                foreach (var element in elements)
                {
                    var y = columnText.YLine;
                    columnText.AddElement(element);
                    var status = columnText.Go(true);
                    if (ColumnText.HasMoreText(status))
                    {
                        column = (column + 1) % 3;
                        if (column == 0)
                        {
                            document.NewPage();
                        }

                        columnText.SetSimpleColumn(
                            columnPoints[column][0], 
                            columnPoints[column][1], 
                            columnPoints[column][2], 
                            columnPoints[column][3]);
                        y = columnPoints[column][3];
                    }

                    columnText.YLine = y;
                    columnText.SetText(null);
                    columnText.AddElement(element);
                    columnText.Go(false);
                }
            }

            document.Close();
        }

        /// <summary>
        /// The add if present.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="check">
        /// The check.
        /// </param>
        /// <param name="provide">
        /// The provide.
        /// </param>
        /// <param name="paragraph">
        /// The paragraph.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        private static void AddIfPresent<T>(
            T source, 
            Func<T, bool> check, 
            Func<T, IElement> provide, 
            Paragraph paragraph)
        {
            if (!check(source))
            {
                return;
            }

            paragraph.Add(provide(source));
            paragraph.Add(Chunk.NEWLINE);
        }

        /// <summary>
        /// The add if present.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="check">
        /// The check.
        /// </param>
        /// <param name="provide">
        /// The provide.
        /// </param>
        /// <param name="output">
        /// The output.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        private static void AddIfPresent<T>(
            T source, 
            Func<T, bool> check, 
            Func<T, IElement> provide, 
            ICollection<IElement> output)
        {
            if (!check(source))
            {
                return;
            }

            output.Add(provide(source));
        }

        /// <summary>
        /// The create phrase.
        /// </summary>
        /// <param name="header">
        /// The header.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <returns>
        /// The <see cref="Phrase"/>.
        /// </returns>
        private static Phrase CreatePhrase(string header, string text)
        {
            var phrase = new Phrase { new Chunk(header + ": ", Bold), new Chunk(text, Normal) };
            phrase.Leading = Leading;
            return phrase;
        }

        /// <summary>
        /// The create project header.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <returns>
        /// The <see cref="Phrase"/>.
        /// </returns>
        private static Phrase CreateProjectHeader(Project project)
        {
            return new Phrase(string.Format("{0} {1}", project.ZipCode, project.City), Bold) { Leading = Leading };
        }

        #endregion
    }
}