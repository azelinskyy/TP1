// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.DomainModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    ///     The project.
    /// </summary>
    public class Project : DomainModel
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        public Project()
        {
            this.FinishDate = new DomainDate();
            this.StartDate = new DomainDate();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        ///     Gets or sets the architect.
        /// </summary>
        public virtual Company Architect { get; set; }

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        ///     Gets or sets the date added.
        /// </summary>
        public DateTime DateAdded { get; set; }

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
        public DomainDate FinishDate { get; set; }

        /// <summary>
        ///     Gets or sets the owner.
        /// </summary>
        public virtual Company Owner { get; set; }

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
        public DomainDate StartDate { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the zip code.
        /// </summary>
        [MaxLength(10)]
        public string ZipCode { get; set; }

        #endregion
    }
}