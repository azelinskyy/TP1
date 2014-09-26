// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PDFHelper.cs" company="Team Alpha Solutions">
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

    /// <summary>
    ///     Helper to perform export into pdf-file (stream).
    /// </summary>
    internal class ProjectPDFHelper
    {
        #region Static Fields

        /// <summary>
        ///     The bold fond const to internal use.
        /// </summary>
        private static readonly Font Bold = new Font(Font.FontFamily.HELVETICA, 8, Font.BOLD);

        /// <summary>
        ///     The normal fond const to internal use.
        /// </summary>
        private static readonly Font Normal = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL);

        #endregion

        #region Methods

        /// <summary>
        ///     Create the project paragraph.
        /// </summary>
        /// <param name="project">
        ///     The project.
        /// </param>
        /// <returns>
        ///     The <see cref="Paragraph" />.
        /// </returns>
        internal static Paragraph CreateProject(Project project)
        {
            var item = new Paragraph();
            item.Leading = 12;
            item.Add(CreateProjectHeader(project));
            item.Add(Chunk.NEWLINE);
            item.Add(new Phrase(project.Title, Bold));
            item.Add(Chunk.NEWLINE);
            item.Add(new Phrase(project.Description, Normal));
            item.Add(Chunk.NEWLINE);
            AddIfPresent(
                project.Address, 
                a => !string.IsNullOrEmpty(a.AddressString), 
                a => CreatePhrase("Addresse", a.AddressString), 
                item);
            AddIfPresent(project.Architect, a => !string.IsNullOrEmpty(a.Name), a => CreatePhrase("A", a.Name), item);
            AddIfPresent(project.Owner, o => !string.IsNullOrEmpty(o.Name), o => CreatePhrase("B", o.Name), item);
            AddIfPresent(
                project.Price, 
                p => p > 0, 
                p => CreatePhrase("Bausumme", p.ToString(CultureInfo.InvariantCulture)), 
                item);
            AddIfPresent(project.Space, s => !string.IsNullOrEmpty(s), s => CreatePhrase("Fläche/Volumen", s), item);
            AddIfPresent(
                project.StartDate, 
                sd => !string.IsNullOrEmpty(sd.Description), 
                sd => CreatePhrase("Baugesuch geplant für", sd.Description), 
                item);
            AddIfPresent(
                project.FinishDate, 
                fd => !string.IsNullOrEmpty(fd.Description), 
                fd => CreatePhrase("Bezug/Nutzung geplant für", fd.Description), 
                item);
            item.Add(Chunk.NEWLINE);
            return item;
        }

        /// <summary>
        ///     Exports projects into output stream.
        /// </summary>
        /// <param name="projects">
        ///     The enumeration of projects.
        /// </param>
        /// <param name="output">
        ///     The output stream.
        /// </param>
        internal void ExportProjects(IEnumerable<Project> projects, Stream output)
        {
            var document = new Document();
            var writer = PdfWriter.GetInstance(document, output);
            writer.PageEvent = new ProjectPageEventHelper();

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
                var y = columnText.YLine;
                var paragraph = CreateProject(project);
                columnText.AddElement(paragraph);
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
                columnText.AddElement(paragraph);
                columnText.Go(false);
            }

            document.Close();
        }

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

        private static Phrase CreatePhrase(string header, string text)
        {
            return new Phrase { new Chunk(header + ": ", Bold), new Chunk(text, Normal) };
        }

        private static Phrase CreateProjectHeader(Project project)
        {
            return new Phrase(string.Format("{0} {1}", project.ZipCode, project.City), Bold);
        }

        #endregion
    }
}