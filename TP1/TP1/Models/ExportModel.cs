// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportModel.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The export model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TP1.Models
{
    using System;

    /// <summary>
    /// The export model.
    /// </summary>
    public class ExportModel
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportModel"/> class.
        /// </summary>
        public ExportModel()
        {
            this.From = DateTime.Now;
            this.To = this.From;
            this.Email = string.Empty;
            this.Language = "en-US";
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the from.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the to.
        /// </summary>
        public DateTime To { get; set; }

        #endregion
    }
}