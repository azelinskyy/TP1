// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressRepository.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The address repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Model.DomainModels;

    /// <summary>
    ///     The address repository.
    /// </summary>
    public class AddressRepository : RepositoryBase<Address>
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
        public override void Add(Address item)
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
        public override void AddRange(IList<Address> items)
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
        public override List<Address> GetAll()
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
        /// The <see cref="Address"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override Address GetById(int id)
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
            return this.GetDbContext().Addresses.Count();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public override void Remove(Address item)
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
        public override void RemoveRange(IList<Address> items)
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
        public override void Update(Address item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}