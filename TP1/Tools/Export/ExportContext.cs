﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportContext.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The export model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Tools.Export
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     The export model.
    /// </summary>
    public class ExportContext
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ExportContext" /> class.
        /// </summary>
        public ExportContext()
        {
            this.From = DateTime.Now;
            this.To = this.From;
            this.Emails = string.Empty;
            this.Culture = "en-US";
            this.Model = ReportModels.Columns;
            this.UnselectedIds = new List<int>();
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

        public List<int> UnselectedIds { get; set; }

        #endregion
    }
}