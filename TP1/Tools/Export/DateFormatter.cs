// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateFormatter.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The date formatter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Tools.Export
{
    using System;
    using System.Globalization;

    /// <summary>
    /// The date formatter.
    /// </summary>
    public class DateFormatter
    {
        #region Public Methods and Operators

        /// <summary>
        /// The format.
        /// </summary>
        /// <param name="dateFrom">
        /// The date from.
        /// </param>
        /// <param name="dateTo">
        /// The date to.
        /// </param>
        /// <param name="culture">The culture.</param>
        /// <returns>
        /// The string that represents period between input from/to dates.
        /// </returns>
        public string Format(DateTime dateFrom, DateTime dateTo, CultureInfo culture)
        {
            var sameYear = dateFrom.Year == dateTo.Year;
            var sameMonth = dateFrom.Month == dateTo.Month;
            var sameDay = dateFrom.Day == dateTo.Day;

            if (sameYear && sameMonth && sameDay)
            {
                return dateFrom.ToString("d. MMMM yyyy", culture);
            }

            var weekFactor = string.Empty;
            if (sameYear && sameMonth)
            {
                if (dateTo.DayOfYear - dateFrom.DayOfYear == 7)
                {
                    weekFactor = string.Format("KW {0}, ", dateTo.DayOfYear / 7);
                }

                return string.Format("{0}{1}. - {2}", weekFactor, dateFrom.Day, dateTo.ToString("d. MMMM yyyy", culture));
            }

            if (sameYear)
            {
                if (dateTo.DayOfYear - dateFrom.DayOfYear == 7)
                {
                    weekFactor = string.Format("KW {0}, ", dateTo.DayOfYear / 7);
                }

                return string.Format("{0}{1} - {2}", weekFactor, dateFrom.ToString("d. MMMM", culture), dateTo.ToString("d. MMMM yyyy", culture));
            }

            return string.Format("{0} - {1}", dateFrom.ToString("d. MMMM yyyy", culture), dateTo.ToString("d. MMMM yyyy", culture));
        }

        #endregion
    }
}