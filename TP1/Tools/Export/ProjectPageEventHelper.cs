// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectPageEventHelper.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The page event helper to decorate projects header and footer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tools.Export
{
    using System;
    using System.Globalization;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using Resources;

    /// <summary>
    ///     The page event helper to decorate projects header and footer.
    /// </summary>
    public class ProjectPageEventHelper : PdfPageEventHelper
    {
        #region Static Fields

        //// private static readonly BaseFont BaseCyrFont = BaseFont.CreateFont(@"C:\Windows\fonts\Helvetica.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED); 

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

        /// <summary>
        /// The culture.
        /// </summary>
        private readonly CultureInfo culture;

        /// <summary>
        /// The date from.
        /// </summary>
        private readonly DateTime dateFrom;

        /// <summary>
        /// The date to.
        /// </summary>
        private readonly DateTime dateTo;

        /// <summary>
        /// The resource service.
        /// </summary>
        private readonly ResourceService resourceService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectPageEventHelper"/> class.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        public ProjectPageEventHelper(DateTime dateFrom, DateTime dateTo, CultureInfo culture)
        {
            this.dateFrom = dateFrom;
            this.dateTo = dateTo;
            this.culture = culture;
            this.resourceService = new ResourceService(culture);
        }

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
            this.DrawHeader(writer, document);
            this.DrawFooter(writer, document);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The draw footer.
        /// </summary>
        /// <param name="writer">
        /// The writer.
        /// </param>
        /// <param name="document">
        /// The document.
        /// </param>
        private void DrawFooter(PdfWriter writer, Document document)
        {
            var footerTable = new PdfPTable(2);
            footerTable.SetWidths(new[] { 9, 1 });
            footerTable.TotalWidth = document.Right - document.Left;

            PdfPCell cell = this.GetNoBorderCell(
                new Phrase(this.resourceService["FullInfoOnSite"], Footer), 
                Element.ALIGN_LEFT);
            footerTable.AddCell(cell);

            cell = this.GetNoBorderCell(
                new Phrase(document.PageNumber.ToString(CultureInfo.InvariantCulture), Footer), 
                Element.ALIGN_RIGHT);
            footerTable.AddCell(cell);

            footerTable.CompleteRow();
            footerTable.WriteSelectedRows(0, -1, document.Left, document.BottomMargin / 2, writer.DirectContent);
        }

        /// <summary>
        /// The draw header.
        /// </summary>
        /// <param name="writer">
        /// The writer.
        /// </param>
        /// <param name="document">
        /// The document.
        /// </param>
        private void DrawHeader(PdfWriter writer, Document document)
        {
            var headerTable = new PdfPTable(2);
            headerTable.SetWidths(new[] { 1, 2 });
            headerTable.TotalWidth = document.Right - document.Left;

            Image image = Image.GetInstance("logo.gif");
            image.ScalePercent(75);

            PdfPCell cell = this.GetNoBorderCell(image);
            cell.Padding = 5;
            headerTable.AddCell(cell);

            cell =
                this.GetNoBorderCell(
                    new Phrase(this.resourceService["BuildingProject"] + this.FormatHeaderDate(), Header), 
                    Element.ALIGN_RIGHT);
            headerTable.AddCell(cell);

            headerTable.CompleteRow();
            headerTable.WriteSelectedRows(
                0, 
                -1, 
                document.Left, 
                document.Top + ((document.TopMargin + image.ScaledHeight) / 2), 
                writer.DirectContent);
        }

        /// <summary>
        /// The format header date.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string FormatHeaderDate()
        {
            return new DateFormatter().Format(this.dateFrom, this.dateTo, this.culture);
        }

        /// <summary>
        /// The get no border cell.
        /// </summary>
        /// <param name="phrase">
        /// The phrase.
        /// </param>
        /// <param name="horizontalAlignment">
        /// The horizontal alignment.
        /// </param>
        /// <returns>
        /// The <see cref="PdfPCell"/>.
        /// </returns>
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

        /// <summary>
        /// The get no border cell.
        /// </summary>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="PdfPCell"/>.
        /// </returns>
        private PdfPCell GetNoBorderCell(Image image)
        {
            return new PdfPCell(image) { BackgroundColor = BaseColor.LIGHT_GRAY, Border = Rectangle.NO_BORDER };
        }

        #endregion
    }
}