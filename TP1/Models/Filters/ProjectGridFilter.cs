// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectGridFilter.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The project grid filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.Filters
{
    using System;

    /// <summary>
    ///     The project grid filter.
    /// </summary>
    public class ProjectGridFilter : GridFilter
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectGridFilter"/> class.
        /// </summary>
        public ProjectGridFilter()
        {
            this.From = DateTime.Now.AddDays(-7);
            this.To = DateTime.Now;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the from date.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        ///     Gets or sets the to date.
        /// </summary>
        public DateTime To { get; set; }

        #endregion
    }
}