// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportConfiguration.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The export model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tools.Export
{
    using System;
    using System.Globalization;

    /// <summary>
    ///     The export model.
    /// </summary>
    public class ExportConfiguration
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExportConfiguration" /> class.
        /// </summary>
        public ExportConfiguration()
        {
            this.From = DateTime.Now;
            this.To = this.From;
            this.Emails = string.Empty;
            this.Culture = "en-US";
            this.Model = ReportModels.Columns;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the language.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string Emails { get; set; }

        /// <summary>
        ///     Gets or sets the from.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        ///     Gets or sets the to.
        /// </summary>
        public ReportModels Model { get; set; }

        /// <summary>
        ///     Gets or sets the to.
        /// </summary>
        public DateTime To { get; set; }

        #endregion
    }
}