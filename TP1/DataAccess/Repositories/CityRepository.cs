// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CityRepository.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The city repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;

    using Model.DomainModels;

    /// <summary>
    /// The city repository.
    /// </summary>
    public class CityRepository : RepositoryBase<City>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Add(City item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void AddRange(IEnumerable<City> items)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override IEnumerable<City> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="City"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override City GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Remove(City item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The remove range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void RemoveRange(IEnumerable<City> items)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Update(City item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}