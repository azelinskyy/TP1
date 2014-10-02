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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The sorting helper.
    /// </summary>
    public static class SortingHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// The order by string.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedEnumerable"/>.
        /// </returns>
        public static IOrderedEnumerable<TSource> OrderByString<TSource>(
            this IEnumerable<TSource> source, 
            string propertyName)
        {
            return source.OrderBy(p => typeof(TSource).GetProperty(propertyName).GetValue(p));
        }

        /// <summary>
        /// The order by string descending.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedEnumerable"/>.
        /// </returns>
        public static IOrderedEnumerable<TSource> OrderByStringDescending<TSource>(
            this IEnumerable<TSource> source, 
            string propertyName)
        {
            return source.OrderByDescending(p => typeof(TSource).GetProperty(propertyName).GetValue(p));
        }

        /// <summary>
        /// The then by string.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedEnumerable"/>.
        /// </returns>
        public static IOrderedEnumerable<TSource> ThenByString<TSource>(
            this IOrderedEnumerable<TSource> source, 
            string propertyName)
        {
            return source.ThenBy(p => typeof(TSource).GetProperty(propertyName).GetValue(p));
        }

        /// <summary>
        /// The then by string descending.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <typeparam name="TSource">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IOrderedEnumerable"/>.
        /// </returns>
        public static IOrderedEnumerable<TSource> ThenByStringDescending<TSource>(
            this IOrderedEnumerable<TSource> source, 
            string propertyName)
        {
            return source.ThenByDescending(p => typeof(TSource).GetProperty(propertyName).GetValue(p));
        }

        #endregion
    }
}