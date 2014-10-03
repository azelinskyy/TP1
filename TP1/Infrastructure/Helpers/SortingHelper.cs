// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SortingHelper.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The sorting helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Infrastructure.Helpers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    ///     The sorting helper.
    /// </summary>
    public static class SortingHelper
    {
        // extentions
        #region Public Methods and Operators

        /// <summary>
        /// The order by.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedQueryable"/>.
        /// </returns>
        public static IOrderedQueryable<TModel> OrderBy<TModel>(this IQueryable<TModel> query, string propertyName)
        {
            Type entityType = typeof(TModel);
            PropertyInfo p = entityType.GetProperty(propertyName);
            MethodInfo m = typeof(SortingHelper).GetMethod("OrderByProperty")
                .MakeGenericMethod(entityType, p.PropertyType);
            return (IOrderedQueryable<TModel>)m.Invoke(null, new object[] { query, p });
        }

        /// <summary>
        /// The order by descending.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedQueryable"/>.
        /// </returns>
        public static IOrderedQueryable<TModel> OrderByDescending<TModel>(
            this IQueryable<TModel> query, 
            string propertyName)
        {
            Type entityType = typeof(TModel);
            PropertyInfo p = entityType.GetProperty(propertyName);
            MethodInfo m = typeof(SortingHelper).GetMethod("OrderByPropertyDescending")
                .MakeGenericMethod(entityType, p.PropertyType);
            return (IOrderedQueryable<TModel>)m.Invoke(null, new object[] { query, p });
        }

        /// <summary>
        /// The order by property.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <typeparam name="TRet">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedQueryable"/>.
        /// </returns>
        public static IOrderedQueryable<TModel> OrderByProperty<TModel, TRet>(IQueryable<TModel> query, PropertyInfo p)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TModel));
            Expression se = Expression.Convert(Expression.Property(pe, p), p.PropertyType);
            return query.OrderBy(Expression.Lambda<Func<TModel, TRet>>(se, pe));
        }

        /// <summary>
        /// The order by property descending.
        /// </summary>
        /// <param name="q">
        /// The q.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <typeparam name="TRet">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedQueryable"/>.
        /// </returns>
        public static IOrderedQueryable<TModel> OrderByPropertyDescending<TModel, TRet>(
            IQueryable<TModel> q, 
            PropertyInfo p)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TModel));
            Expression se = Expression.Convert(Expression.Property(pe, p), p.PropertyType);
            return q.OrderByDescending(Expression.Lambda<Func<TModel, TRet>>(se, pe));
        }

        /// <summary>
        /// The then by.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedQueryable"/>.
        /// </returns>
        public static IOrderedQueryable<TModel> ThenBy<TModel>(
            this IOrderedQueryable<TModel> query, 
            string propertyName)
        {
            Type entityType = typeof(TModel);
            PropertyInfo p = entityType.GetProperty(propertyName);
            MethodInfo m = typeof(SortingHelper).GetMethod("ThenByProperty")
                .MakeGenericMethod(entityType, p.PropertyType);
            return (IOrderedQueryable<TModel>)m.Invoke(null, new object[] { query, p });
        }

        /// <summary>
        /// The then by descending.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedQueryable"/>.
        /// </returns>
        public static IOrderedQueryable<TModel> ThenByDescending<TModel>(
            this IOrderedQueryable<TModel> query, 
            string propertyName)
        {
            Type entityType = typeof(TModel);
            PropertyInfo p = entityType.GetProperty(propertyName);
            MethodInfo m = typeof(SortingHelper).GetMethod("ThenByPropertyDescending")
                .MakeGenericMethod(entityType, p.PropertyType);
            return (IOrderedQueryable<TModel>)m.Invoke(null, new object[] { query, p });
        }

        /// <summary>
        /// The then by property.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <typeparam name="TRet">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<TModel> ThenByProperty<TModel, TRet>(IOrderedQueryable<TModel> query, PropertyInfo p)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TModel));
            Expression se = Expression.Convert(Expression.Property(pe, p), p.PropertyType);
            return query.ThenBy(Expression.Lambda<Func<TModel, TRet>>(se, pe));
        }

        /// <summary>
        /// The then by property descending.
        /// </summary>
        /// <param name="q">
        /// The q.
        /// </param>
        /// <param name="p">
        /// The p.
        /// </param>
        /// <typeparam name="TModel">
        /// </typeparam>
        /// <typeparam name="TRet">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<TModel> ThenByPropertyDescending<TModel, TRet>(
            IOrderedQueryable<TModel> q, 
            PropertyInfo p)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TModel));
            Expression se = Expression.Convert(Expression.Property(pe, p), p.PropertyType);
            return q.ThenByDescending(Expression.Lambda<Func<TModel, TRet>>(se, pe));
        }

        #endregion
    }
}