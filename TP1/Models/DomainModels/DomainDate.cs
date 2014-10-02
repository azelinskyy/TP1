// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainDate.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The domain date.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.DomainModels
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    ///     The domain date.
    /// </summary>
    [ComplexType]
    public class DomainDate
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the date time.
        /// </summary>
        public DateTime?    DateTime { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}