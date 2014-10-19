// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryBase.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The repository base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    using DataAccess.Repositories.Interfaces.Sync;

    using Infrastructure.Contexts;

    using Model.DomainModels;

    /// <summary>
    /// The repository base.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : DomainModel
    {
        #region Constants

        /// <summary>
        ///     The context key.
        /// </summary>
        private const string ContextKey = "domainContext";

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public abstract void Add(T item);

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public abstract void AddRange(IList<T> items);

        /// <summary>
        ///     The get all.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerable" />.
        /// </returns>
        public abstract List<T> GetAll();

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public abstract T GetById(int id);

        /// <summary>
        /// The get count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public abstract int GetCount();

        /// <summary>
        /// The remove single.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public abstract void Remove(T item);

        /// <summary>
        /// The remove range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public abstract void RemoveRange(IList<T> items);

        /// <summary>
        /// The update item.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public abstract void Update(T item);

        #endregion

        #region Methods

        /// <summary>
        ///     The get db context.
        /// </summary>
        /// <returns>
        ///     The <see cref="DomainContext" />.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        protected virtual DomainContext GetDbContext()
        {
            HttpContext httpContext = HttpContext.Current;
            if (httpContext != null)
            {
                if (httpContext.Items[ContextKey] == null)
                {
                    httpContext.Items.Add(ContextKey, new DomainContext());
                }

                return httpContext.Items[ContextKey] as DomainContext;
            }

            throw new Exception("No HttpContext available");
        }

        #endregion
    }
}