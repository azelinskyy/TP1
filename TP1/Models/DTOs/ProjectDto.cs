// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectDto.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The project dto.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Model.DTOs
{
    using System;

    /// <summary>
    ///     The project dto.
    /// </summary>
    public class ProjectDto : DomainDto
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        public CityDto City { get; set; }

        /// <summary>
        ///     Gets or sets the date added.
        /// </summary>
        public DateTime DateAdded { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets the architect.
        /// </summary>
        public string Architect { get; set; }

        /// <summary>
        ///     Gets or sets the date modified.
        /// </summary>
        public DateTime? DateModified { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the finish date.
        /// </summary>
        public DateTime? FinishDate { get; set; }

        /// <summary>
        ///     Gets or sets the owner.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        ///     Gets or sets the price.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///     Gets or sets the space.
        /// </summary>
        public string Space { get; set; }

        /// <summary>
        ///     Gets or sets the start date.
        /// </summary>
        public DateTime? StartDate { get; set; }

        #endregion
    }
}