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
    using System.Threading.Tasks;
    using System.Web;

    using DataAccess.Repositories.Interfaces.Async;

    using Infrastructure.Contexts;

    using Model.DomainModels;

    /// <summary>
    /// The repository base.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    public abstract class RepositoryBaseAsync<T> : IRepositoryBaseAsync<T>
        where T : DomainModel
    {
        #region Constants

        /// <summary>
        ///     The context key.
        /// </summary>
        private const string ContextKey = "domainContext";

        #endregion

        #region Public Methods and Operators

        public abstract Task AddAsync(T item);

        public abstract Task AddRangeAsync(IList<T> items);

        public abstract Task<List<T>> GetAllAsync();

        public abstract Task<T> GetByIdAsync(int id);

        public abstract Task<int> GetCountAsync();

        public abstract Task RemoveAsync(T item);

        public abstract Task RemoveRangeAsync(IList<T> items);

        public abstract Task UpdateAsync(T item);

        #endregion

        #region Methods

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