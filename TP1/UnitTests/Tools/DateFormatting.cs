// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateFormatting.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The date formatting.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTests.Tools
{
    using System;

    using NUnit.Framework;

    using global::Tools.Export;

    /// <summary>
    /// The date formatting.
    /// </summary>
    [TestFixture]
    public class DateFormatting
    {
        #region Public Methods and Operators

        /// <summary>
        /// The one day.
        /// </summary>
        [Test]
        public void OneDay()
        {
            var dateTo = new DateTime(2014, 9, 10);
            DateTime dateFrom = dateTo;

            var formatter = new DateFormatter();
            string formatedDate = formatter.Format(dateFrom, dateTo);

            Assert.AreEqual("10. September 2014", formatedDate);
        }

        /// <summary>
        /// The one week between months.
        /// </summary>
        [Test]
        public void OneWeekBetweenMonths()
        {
            var dateTo = new DateTime(2014, 9, 5);
            DateTime dateFrom = dateTo.AddDays(-7);

            var formatter = new DateFormatter();
            string formatedDate = formatter.Format(dateFrom, dateTo);

            Assert.AreEqual("KW 35, 29. August - 5. September 2014", formatedDate);
        }

        /// <summary>
        /// The one week from same month.
        /// </summary>
        [Test]
        public void OneWeekFromSameMonth()
        {
            var dateTo = new DateTime(2014, 9, 10);
            DateTime dateFrom = dateTo.AddDays(-7);

            var formatter = new DateFormatter();
            string formatedDate = formatter.Format(dateFrom, dateTo);

            Assert.AreEqual("KW 36, 3. - 10. September 2014", formatedDate);
        }

        /// <summary>
        /// The period between months.
        /// </summary>
        [Test]
        public void PeriodBetweenMonths()
        {
            var dateTo = new DateTime(2014, 9, 5);
            DateTime dateFrom = dateTo.AddDays(-21);

            var formatter = new DateFormatter();
            string formatedDate = formatter.Format(dateFrom, dateTo);

            Assert.AreEqual("15. August - 5. September 2014", formatedDate);
        }

        /// <summary>
        /// The period between years.
        /// </summary>
        [Test]
        public void PeriodBetweenYears()
        {
            var dateTo = new DateTime(2014, 9, 5);
            var dateFrom = new DateTime(2013, 7, 12);

            var formatter = new DateFormatter();
            string formatedDate = formatter.Format(dateFrom, dateTo);

            Assert.AreEqual("12. July 2013 - 5. September 2014", formatedDate);
        }

        /// <summary>
        /// The period in month.
        /// </summary>
        [Test]
        public void PeriodInMonth()
        {
            var dateTo = new DateTime(2014, 9, 22);
            DateTime dateFrom = dateTo.AddDays(-12);

            var formatter = new DateFormatter();
            string formatedDate = formatter.Format(dateFrom, dateTo);

            Assert.AreEqual("10. - 22. September 2014", formatedDate);
        }

        #endregion
    }
}