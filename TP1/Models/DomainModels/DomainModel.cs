// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainModel.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The domain model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Model.DomainModels
{
    using System;

    /// <summary>
    ///     The domain model.
    /// </summary>
    public abstract class DomainModel : IEquatable<DomainModel>
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets a value indicating whether persisted.
        /// </summary>
        public bool Persisted
        {
            get
            {
                return this.Id != 0;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(DomainModel other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }

        #endregion
    }
}