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
    public class ProjectDto
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

        #endregion
    }
}