// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyRepository.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The company repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Model.DomainModels;

    /// <summary>
    ///     The company repository.
    /// </summary>
    public class CompanyRepository : RepositoryBase<Company>
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
        public override void Add(Company item)
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
        public override void AddRange(IList<Company> items)
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
        public override List<Company> GetAll()
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
        /// The <see cref="Company"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override Company GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The get count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetCount()
        {
            return this.GetDbContext().Cities.Count();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Remove(Company item)
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
        public override void RemoveRange(IList<Company> items)
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
        public override void Update(Company item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}