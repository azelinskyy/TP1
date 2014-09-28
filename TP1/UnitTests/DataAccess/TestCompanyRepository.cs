// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCompanyRepository.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The test company repository.
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
    ///     The test company repository.
    /// </summary>
    public class TestCompanyRepository
    {
        #region Fields

        /// <summary>
        ///     The proj.
        /// </summary>
        private Company company;

        /// <summary>
        ///     The repo.
        /// </summary>
        private CompanyRepoWrapper repo;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.repo = new CompanyRepoWrapper();
            this.company = new Company { Name = "United LTD" };
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
            Assert.Throws<NotImplementedException>(() => this.repo.Add(this.company));
        }

        /// <summary>
        ///     The test add range.
        /// </summary>
        [Test]
        public void TestAddRange()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.AddRange(new List<Company> { this.company }));
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
            Assert.Throws<NotImplementedException>(() => this.repo.Remove(this.company));
        }

        /// <summary>
        ///     The test remove range.
        /// </summary>
        [Test]
        public void TestRemoveRange()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.RemoveRange(new List<Company> { this.company }));
        }

        /// <summary>
        /// The test update.
        /// </summary>
        [Test]
        public void TestUpdate()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.Update(this.company));
        }

        #endregion

        /// <summary>
        ///     The company repo wrapper.
        /// </summary>
        internal sealed class CompanyRepoWrapper : CompanyRepository
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