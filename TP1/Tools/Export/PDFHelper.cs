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
    internal class PDFHelper
    {
        #region Static Fields

        /// <summary>
        ///     The bold fond const to internal use.
        /// </summary>
        private static readonly Font Bold = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD);

        /// <summary>
        ///     The normal fond const to internal use.
        /// </summary>
        private static readonly Font Normal = new Font(Font.FontFamily.HELVETICA, 10, Font.NORMAL);

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
        internal static Paragraph CreateProject(Project project)
        {
            var item = new Paragraph();
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
        /// Exports projects into output stream.
        /// </summary>
        /// <param name="projects">
        /// The enumeration of projects.
        /// </param>
        /// <param name="output">
        /// The output stream.
        /// </param>
        internal void ExportProjects(IEnumerable<Project> projects, Stream output)
        {
            var document = new Document();
            var writer = PdfWriter.GetInstance(document, output);
            writer.PageEvent = new ProjectsPageEventHelper();
            var art = new Rectangle(50, 50, 545, 792);
            writer.SetBoxSize("art", art);

            document.Open();

            foreach (Project project in projects)
            {
                document.Add(CreateProject(project));
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