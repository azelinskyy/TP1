// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GridFilter.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The grid filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TP1.Models
{
    using System.Data.SqlClient;

    /// <summary>
    ///     The grid filter.
    /// </summary>
    public class GridFilter
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GridFilter"/> class.
        /// </summary>
        public GridFilter()
        {
            this.PageIndex = 1;
            this.PageSize = 10;
            this.SortField = "Id";
            this.SortOrder = SortOrder.Ascending;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the page index.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        ///     Gets or sets the page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     Gets or sets the sort field.
        /// </summary>
        public string SortField { get; set; }

        /// <summary>
        ///     Gets or sets the sort order.
        /// </summary>
        public SortOrder SortOrder { get; set; }

        #endregion
    }
}