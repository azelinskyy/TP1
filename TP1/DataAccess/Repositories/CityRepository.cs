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
    using System.Linq;

    using Model.DomainModels;

    /// <summary>
    ///     The city repository.
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
            if (item.Id != 0)
            {
                throw new ArgumentOutOfRangeException("Id");
            }

            this.GetDbContext().Cities.Add(item);
            this.GetDbContext().SaveChanges();
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
        ///     The get all.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerable" />.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override IEnumerable<City> GetAll()
        {
            return this.GetDbContext().Cities;
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
            return this.GetDbContext().Cities.Single(c => c.Id == id);
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
        public override void RemoveRange(IList<City> items)
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