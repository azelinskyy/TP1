// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestHelpers.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The test helpers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTests.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;

    using global::Infrastructure.Helpers;

    using Model.DomainModels;

    using NUnit.Framework;

    /// <summary>
    /// The test helpers.
    /// </summary>
    [TestFixture]
    internal class TestHelpers
    {
        #region Fields

        /// <summary>
        /// The projects.
        /// </summary>
        private List<Project> projects;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.projects = new List<Project>
                                {
                                    new Project { Id = 2, Price = 100 }, 
                                    new Project { Id = 3, Price = 200 }, 
                                    new Project { Id = 1, Price = 200 }
                                };
        }

        /// <summary>
        /// The tear down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.projects = null;
        }

        /// <summary>
        /// The test order by string desending extension.
        /// </summary>
        [Test]
        public void TestOrderByStringDesendingExtension()
        {
            IOrderedEnumerable<Project> ordered = this.projects.OrderByStringDescending("Id");
            Assert.AreEqual(ordered.First().Id, 3);
            Assert.AreEqual(ordered.Last().Id, 1);
        }

        /// <summary>
        /// The test order by string extension.
        /// </summary>
        [Test]
        public void TestOrderByStringExtension()
        {
            IOrderedEnumerable<Project> ordered = this.projects.OrderByString("Id");
            Assert.AreEqual(ordered.First().Id, 1);
            Assert.AreEqual(ordered.Last().Id, 3);
        }

        /// <summary>
        /// The test then by string desending extension.
        /// </summary>
        [Test]
        public void TestThenByStringDesendingExtension()
        {
            IOrderedEnumerable<Project> ordered = this.projects.OrderByString("Price").ThenByStringDescending("Id");
            Assert.AreEqual(ordered.First().Id, 2);
            Assert.AreEqual(ordered.Last().Id, 1);
        }

        /// <summary>
        /// The test then by string extension.
        /// </summary>
        [Test]
        public void TestThenByStringExtension()
        {
            IOrderedEnumerable<Project> ordered = this.projects.OrderByString("Price").ThenByString("Id");
            Assert.AreEqual(ordered.First().Id, 2);
            Assert.AreEqual(ordered.Last().Id, 3);
        }

        #endregion
    }
}