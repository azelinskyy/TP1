// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainContext.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The domain context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Contexts
{
    using System.Data.Entity;

    using Model.DomainModels;

    /// <summary>
    ///     The domain context.
    /// </summary>
    public class DomainContext : DbContext
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainContext"/> class.
        /// </summary>
        public DomainContext()
            : base("DefaultConnectionProducts")
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the addresses.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        ///     Gets or sets the cities.
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        ///     Gets or sets the companies.
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        ///     Gets or sets the projects.
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        #endregion
    }
}