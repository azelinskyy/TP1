// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectsPageEventHelper.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The page event helper to decorate projects header and footer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tools.Export
{
    using System.Globalization;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    /// <summary>
    /// The page event helper to decorate projects header and footer.
    /// </summary>
    public class ProjectsPageEventHelper : PdfPageEventHelper
    {
        #region Static Fields

        /// <summary>
        /// The footer font.
        /// </summary>
        private static readonly Font Footer = new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL);

        /// <summary>
        /// The header font.
        /// </summary>
        private static readonly Font Header = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);

        #endregion

        #region Fields

        /// <summary>
        /// The current page number.
        /// </summary>
        private int pageNumber;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Overrides base event handler for end of page event.
        /// </summary>
        /// <param name="writer">
        /// The writer.
        /// </param>
        /// <param name="document">
        /// The document.
        /// </param>
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            Rectangle rect = writer.GetBoxSize("art");
            ColumnText.ShowTextAligned(
                writer.DirectContent,
                Element.ALIGN_RIGHT,
                new Phrase("Bauvorhaben KW 35, 18. - 24. August 2014", Header),
                rect.Right,
                rect.Top,
                0);
            ColumnText.ShowTextAligned(
                writer.DirectContent,
                Element.ALIGN_CENTER,
                new Phrase(
                    "Alle Projekte und zusätzliche detaillierte Informationen finden Sie unter www.bindexis.ch",
                    Footer),
                (rect.Right + rect.Left) / 2,
                rect.Bottom - 18,
                0);
            ColumnText.ShowTextAligned(
                writer.DirectContent,
                Element.ALIGN_LEFT,
                new Phrase(this.pageNumber.ToString(CultureInfo.InvariantCulture), Footer),
                rect.Right - 20,
                rect.Bottom - 18,
                0);
        }

        /// <summary>
        /// Overrides base event handler for start of page event.
        /// </summary>
        /// <param name="writer">
        /// The writer.
        /// </param>
        /// <param name="document">
        /// The document.
        /// </param>
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            this.pageNumber++;
        }

        #endregion
    }
}