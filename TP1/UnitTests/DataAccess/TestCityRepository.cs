// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCityRepository.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The test city repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UnitTests.DataAccess
{
    using System;
    using System.Collections.Generic;

    using global::DataAccess.Repositories;

    using Infrastructure.Contexts;

    using Model.DomainModels;

    using NUnit.Framework;

    /// <summary>
    ///     The test city repository.
    /// </summary>
    public class TestCityRepository
    {
        #region Fields

        /// <summary>
        ///     The proj.
        /// </summary>
        private City city;

        /// <summary>
        ///     The repo.
        /// </summary>
        private CityRepoWrapper repo;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.repo = new CityRepoWrapper();
            this.city = new City { Name = "Lviv" };
        }

        /// <summary>
        ///     The tear down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.repo = null;
        }

        /// <summary>
        ///     The test add.
        /// </summary>
        [Test]
        public void TestAdd()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.Add(this.city));
        }

        /// <summary>
        ///     The test add range.
        /// </summary>
        [Test]
        public void TestAddRange()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.AddRange(new List<City> { this.city }));
        }

        /// <summary>
        ///     The test get all.
        /// </summary>
        [Test]
        public void TestGetAll()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.GetAll());
        }

        /// <summary>
        ///     The test get by id.
        /// </summary>
        [Test]
        public void TestGetById()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.GetById(1));
        }

        /// <summary>
        ///     The test remove.
        /// </summary>
        [Test]
        public void TestRemove()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.Remove(this.city));
        }

        /// <summary>
        ///     The test remove range.
        /// </summary>
        [Test]
        public void TestRemoveRange()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.RemoveRange(new List<City> { this.city }));
        }

        /// <summary>
        /// The test update.
        /// </summary>
        [Test]
        public void TestUpdate()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.Update(this.city));
        }

        #endregion

        /// <summary>
        ///     The city repo wrapper.
        /// </summary>
        internal sealed class CityRepoWrapper : CityRepository
        {
            #region Fields

            /// <summary>
            ///     The context.
            /// </summary>
            private DomainContext context;

            #endregion

            #region Methods

            /// <summary>
            ///     The get db context.
            /// </summary>
            /// <returns>
            ///     The <see cref="DomainContext" />.
            /// </returns>
            protected override DomainContext GetDbContext()
            {
                return this.context = this.context ?? new DomainContext();
            }

            #endregion
        }
    }
}