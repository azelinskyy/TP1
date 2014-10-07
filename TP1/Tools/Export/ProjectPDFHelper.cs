﻿// --------------------------------------------------------------------------------------------------------------------
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

        #region Fields

        /// <summary>
        ///     The bold fond const to internal use.
        /// </summary>
        private readonly Font bold;

        /// <summary>
        ///     The normal fond const to internal use.
        /// </summary>
        private readonly Font normal;

        /// <summary>
        /// The path of root to configure fonts.
        /// </summary>
        private readonly string rootPath;

        /// <summary>
        ///     The culture.
        /// </summary>
        private readonly CultureInfo culture;

        /// <summary>
        ///     The resource service.
        /// </summary>
        private readonly LocalizationService resourceService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPDFHelper"/> class.
        /// </summary>
        /// <param name="rootPath"></param>
        /// <param name="culture">
        ///     The culture.
        /// </param>
        public ProjectPDFHelper(string rootPath, CultureInfo culture)
        {
            this.rootPath = rootPath;
            this.culture = culture;
            this.resourceService = new LocalizationService(culture);

            var fullPath = "arialuni.ttf";
            if (!string.IsNullOrEmpty(rootPath))
            {
                fullPath = Path.Combine(rootPath, fullPath);
            }

            var unicodeBaseFont = BaseFont.CreateFont(fullPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            this.bold = new Font(unicodeBaseFont, 8, Font.BOLD);
            this.normal = new Font(unicodeBaseFont, 8, Font.NORMAL);
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
            item.Add(this.CreateProjectHeader(project));
            item.Add(Chunk.NEWLINE);
            item.Add(new Phrase(project.Title, this.bold));
            item.Add(Chunk.NEWLINE);
            item.Add(new Phrase(project.Description, this.normal));
            item.Add(Chunk.NEWLINE);
            this.AddIfPresent(
                project.Address,
                a => !string.IsNullOrEmpty(a.AddressString),
                a => this.CreatePhrase(this.resourceService["Address"], a.AddressString),
                item);
            this.AddIfPresent(
                project.Architect,
                a => !string.IsNullOrEmpty(a.Name),
                a => this.CreatePhrase(this.resourceService["A_acrchitect"], a.Name),
                item);
            this.AddIfPresent(
                project.Owner,
                o => !string.IsNullOrEmpty(o.Name),
                o => this.CreatePhrase(this.resourceService["B_builder"], o.Name),
                item);
            this.AddIfPresent(
                project.Price,
                p => p > 0,
                p => this.CreatePhrase(this.resourceService["ConstructionCost"], p.ToString(CultureInfo.InvariantCulture)),
                item);
            this.AddIfPresent(
                project.Space,
                s => !string.IsNullOrEmpty(s),
                s => this.CreatePhrase(this.resourceService["AreaVolume"], s),
                item);
            this.AddIfPresent(
                project.StartDate,
                sd => !string.IsNullOrEmpty(sd.Description),
                sd => this.CreatePhrase(this.resourceService["ConstructionStartDate"], sd.Description),
                item);
            this.AddIfPresent(
                project.FinishDate,
                fd => !string.IsNullOrEmpty(fd.Description),
                fd => this.CreatePhrase(this.resourceService["ConstructionEndDate"], fd.Description),
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
            result.Add(this.CreateProjectHeader(project));
            result.Add(new Phrase(project.Title, this.bold) { Leading = Leading });
            result.Add(new Phrase(project.Description, this.normal) { Leading = Leading });
            this.AddIfPresent(
                project.Address,
                a => !string.IsNullOrEmpty(a.AddressString),
                a => this.CreatePhrase(this.resourceService["Address"], a.AddressString),
                result);
            this.AddIfPresent(
                project.Architect,
                a => !string.IsNullOrEmpty(a.Name),
                a => this.CreatePhrase(this.resourceService["A_acrchitect"], a.Name),
                result);
            this.AddIfPresent(
                project.Owner,
                o => !string.IsNullOrEmpty(o.Name),
                o => this.CreatePhrase(this.resourceService["B_builder"], o.Name),
                result);
            this.AddIfPresent(
                project.Price,
                p => p > 0,
                p => this.CreatePhrase(this.resourceService["ConstructionCost"], p.ToString(CultureInfo.InvariantCulture)),
                result);
            this.AddIfPresent(
                project.Space,
                s => !string.IsNullOrEmpty(s),
                s => this.CreatePhrase(this.resourceService["AreaVolume"], s),
                result);
            this.AddIfPresent(
                project.StartDate,
                sd => !string.IsNullOrEmpty(sd.Description),
                sd => this.CreatePhrase(this.resourceService["ConstructionStartDate"], sd.Description),
                result);
            this.AddIfPresent(
                project.FinishDate,
                fd => !string.IsNullOrEmpty(fd.Description),
                fd => this.CreatePhrase(this.resourceService["ConstructionEndDate"], fd.Description),
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
        /// <param name="configuration">
        /// The configuration for export.
        /// </param>
        /// <param name="output">
        /// The output stream.
        /// </param>
        internal void ExportProjects(IEnumerable<Project> projects, ExportConfiguration configuration, Stream output)
        {
            var document = new Document();
            var writer = PdfWriter.GetInstance(document, output);
            writer.PageEvent = new ProjectPageEventHelper(configuration.From, configuration.To, this.culture, this.rootPath);

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
        /// Exports projects into output stream.
        /// </summary>
        /// <param name="projects">
        /// The enumeration of projects.
        /// </param>
        /// <param name="configuration">
        /// The configuration for export.
        /// </param>
        /// <param name="output">
        /// The output stream.
        /// </param>
        internal void ExportProjectsAsTable(IEnumerable<Project> projects, ExportConfiguration configuration, Stream output)
        {
            var document = new Document();
            var writer = PdfWriter.GetInstance(document, output);
            writer.PageEvent = new ProjectPageEventHelper(configuration.From, configuration.To, this.culture, this.rootPath);

            document.SetMargins(
                document.LeftMargin,
                document.RightMargin,
                document.TopMargin * 2,
                document.BottomMargin * 2);

            document.Open();

            var table = new PdfPTable(2);
            table.SetWidths(new[] { 3, 7 });
            table.TotalWidth = document.Right - document.Left;

            foreach (var project in projects)
            {
                this.CreatePhraseRow(() => this.CreateProjectHeader(project), 2, table);
                this.CreatePhraseRow(() => new Phrase(project.Title, this.bold) { Leading = Leading }, 2, table);
                this.CreatePhraseRow(() => new Phrase(project.Description, this.normal) { Leading = Leading }, 2, table);

                this.AddIfPresent(
                    project.Address != null && !string.IsNullOrEmpty(project.Address.AddressString),
                    this.resourceService["Address"],
                    project.Address.AddressString,
                    table);

                this.AddIfPresent(
                    project.Architect != null && !string.IsNullOrEmpty(project.Architect.Name),
                    this.resourceService["A_acrchitect"],
                    project.Architect.Name,
                    table);

                this.AddIfPresent(
                    project.Owner != null && !string.IsNullOrEmpty(project.Owner.Name),
                    this.resourceService["B_builder"],
                    project.Owner.Name,
                    table);

                this.AddIfPresent(
                    project.Price > 0,
                    this.resourceService["ConstructionCost"],
                    project.Price.ToString(CultureInfo.InvariantCulture),
                    table);

                this.AddIfPresent(
                    !string.IsNullOrEmpty(project.Space),
                    this.resourceService["AreaVolume"],
                    project.Space,
                    table);

                this.AddIfPresent(
                    project.StartDate != null && !string.IsNullOrEmpty(project.StartDate.Description),
                    this.resourceService["ConstructionStartDate"],
                    project.StartDate.Description,
                    table);

                this.AddIfPresent(
                    project.FinishDate != null && !string.IsNullOrEmpty(project.FinishDate.Description),
                    this.resourceService["ConstructionEndDate"],
                    project.FinishDate.Description,
                    table);

                this.AddEmptyCells(table, 2);
            }

            document.Add(table);

            document.Close();
        }

        /// <summary>
        /// Add sempty cells.
        /// </summary>
        /// <param name="output">
        /// The table.
        /// </param>
        /// <param name="colspan">
        /// The colspan.
        /// </param>
        private void AddEmptyCells(PdfPTable output, int colspan)
        {
            var cell = new PdfPCell(new Phrase(Chunk.NEWLINE)) { Border = Rectangle.NO_BORDER, Colspan = colspan };
            output.AddCell(cell);
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
        private void AddIfPresent<T>(T source, Func<T, bool> check, Func<T, IElement> provide, Paragraph paragraph)
        {
            if (source == null || !check(source))
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
        private void AddIfPresent<T>(T source, Func<T, bool> check, Func<T, IElement> provide, ICollection<IElement> output)
        {
            if (source == null || !check(source))
            {
                return;
            }

            output.Add(provide(source));
        }

        /// <summary>
        /// The add if present.
        /// </summary>
        /// <param name="check">
        /// The check.
        /// </param>
        /// <param name="firstCellProvide">
        /// The first cell provide.
        /// </param>
        /// <param name="secondCellProvide">
        /// The second cell provide.
        /// </param>
        /// <param name="output">
        /// The output.
        /// </param>
        private void AddIfPresent(bool check, string firstCellProvide, string secondCellProvide, PdfPTable output)
        {
            if (!check)
            {
                return;
            }

            output.AddCell(new PdfPCell(new Phrase(firstCellProvide, this.bold) { Leading = Leading }));
            output.AddCell(new PdfPCell(new Phrase(secondCellProvide, this.normal) { Leading = Leading }));
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
        private Phrase CreatePhrase(string header, string text)
        {
            var phrase = new Phrase { new Chunk(header + ": ", this.bold), new Chunk(text, this.normal) };
            phrase.Leading = Leading;
            return phrase;
        }

        /// <summary>
        /// The create phrase row.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="colspan">
        /// The colspan.
        /// </param>
        /// <param name="output">
        /// The output.
        /// </param>
        private void CreatePhraseRow(Func<Phrase> provider, int colspan, PdfPTable output)
        {
            var cell = new PdfPCell(provider());
            cell.Colspan = colspan;
            output.AddCell(cell);
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
        private Phrase CreateProjectHeader(Project project)
        {
            return new Phrase(string.Format("{0} {1}", project.ZipCode, project.City), this.bold) { Leading = Leading };
        }

        #endregion
    }
}