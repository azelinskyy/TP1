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
    /// The domain model.
    /// </summary>
    public abstract class DomainModel : IEquatable<DomainModel>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        #endregion

        public bool Equals(DomainModel other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Id == other.Id;
        }
    }
}