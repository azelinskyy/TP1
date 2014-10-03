// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepositoryBase.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The RepositoryBase interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DataAccess.Repositories
{
    using System.Collections.Generic;

    using Model.DomainModels;

    /// <summary>
    /// The RepositoryBase interface.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public interface IRepositoryBase<T>
        where T : DomainModel
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Add(T item);

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        void AddRange(IList<T> items);

        /// <summary>
        ///     The get all.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerable" />.
        /// </returns>
        List<T> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetById(int id);

        /// <summary>
        /// The get count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int GetCount();

        /// <summary>
        /// The remove single.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Remove(T item);

        /// <summary>
        /// The remove range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        void RemoveRange(IList<T> items);

        /// <summary>
        /// The update item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Update(T item);

        #endregion
    }
}