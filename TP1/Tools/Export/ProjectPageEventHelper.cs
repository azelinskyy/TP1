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
    ///     The page event helper to decorate projects header and footer.
    /// </summary>
    public class ProjectPageEventHelper : PdfPageEventHelper
    {
        #region Static Fields

        /// <summary>
        ///     The footer font.
        /// </summary>
        private static readonly Font Footer = new Font(Font.FontFamily.HELVETICA, 11, Font.NORMAL);

        /// <summary>
        ///     The header font.
        /// </summary>
        private static readonly Font Header = new Font(Font.FontFamily.HELVETICA, 12, Font.BOLD);

        #endregion

        #region Fields

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Overrides base event handler for end of page event.
        /// </summary>
        /// <param name="writer">
        ///     The writer.
        /// </param>
        /// <param name="document">
        ///     The document.
        /// </param>
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            this.DrawHeader(writer, document);
            this.DrawFooter(writer, document);
        }

        #endregion

        #region Methods

        private void DrawFooter(PdfWriter writer, Document document)
        {
            var footerTable = new PdfPTable(2);
            footerTable.SetWidths(new[] { 9, 1 });
            footerTable.TotalWidth = document.Right - document.Left;

            var cell = this.GetNoBorderCell(new Phrase("Alle Projekte und zusätzliche detaillierte Informationen finden Sie unter www.bindexis.ch", Footer), Element.ALIGN_LEFT);
            footerTable.AddCell(cell);
            
            cell = this.GetNoBorderCell(new Phrase(document.PageNumber.ToString(CultureInfo.InvariantCulture), Footer), Element.ALIGN_RIGHT);
            footerTable.AddCell(cell);

            footerTable.CompleteRow();
            footerTable.WriteSelectedRows(0, -1, document.Left, document.BottomMargin / 2, writer.DirectContent);
        }

        private void DrawHeader(PdfWriter writer, Document document)
        {
            var headerTable = new PdfPTable(2);
            headerTable.SetWidths(new[] { 1, 2 });
            headerTable.TotalWidth = document.Right - document.Left;

            var image = Image.GetInstance("logo.gif");
            image.ScalePercent(75);

            var cell = this.GetNoBorderCell(image);
            cell.Padding = 5;
            headerTable.AddCell(cell);

            cell = this.GetNoBorderCell(new Phrase("Bauvorhaben KW 35, 18. - 24. August 2014", Header), Element.ALIGN_RIGHT);
            headerTable.AddCell(cell);

            headerTable.CompleteRow();
            headerTable.WriteSelectedRows(0, -1, document.Left, document.Top + (document.TopMargin / 2), writer.DirectContent);
        }

        private PdfPCell GetNoBorderCell(Phrase phrase, int horizontalAlignment)
        {
            return new PdfPCell(phrase)
            {
                BackgroundColor = BaseColor.LIGHT_GRAY,
                HorizontalAlignment = horizontalAlignment,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                Border = Rectangle.NO_BORDER
            };
        }

        private PdfPCell GetNoBorderCell(Image image)
        {
            return new PdfPCell(image)
            {
                BackgroundColor = BaseColor.LIGHT_GRAY,
                Border = Rectangle.NO_BORDER
            };
        }

        #endregion
    }
}