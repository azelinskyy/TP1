// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestAddressRepository.cs" company="Team Alpha Solutions">
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

    using global::Infrastructure.Contexts;

    using Model.DomainModels;

    using NUnit.Framework;

    /// <summary>
    ///     The test address repository.
    /// </summary>
    public class TestAddressRepository
    {
        #region Fields

        /// <summary>
        ///     The proj.
        /// </summary>
        private Address address;

        /// <summary>
        ///     The repo.
        /// </summary>
        private AddressRepoWrapper repo;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.repo = new AddressRepoWrapper();
            this.address = new Address { AddressString = "My address" };
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
            Assert.Throws<NotImplementedException>(() => this.repo.Add(this.address));
        }

        /// <summary>
        ///     The test add range.
        /// </summary>
        [Test]
        public void TestAddRange()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.AddRange(new List<Address> { this.address }));
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
            Assert.Throws<NotImplementedException>(() => this.repo.Remove(this.address));
        }

        /// <summary>
        ///     The test remove range.
        /// </summary>
        [Test]
        public void TestRemoveRange()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.RemoveRange(new List<Address> { this.address }));
        }

        /// <summary>
        ///     The test update.
        /// </summary>
        [Test]
        public void TestUpdate()
        {
            Assert.Throws<NotImplementedException>(() => this.repo.Update(this.address));
        }

        #endregion

        /// <summary>
        ///     The address repo wrapper.
        /// </summary>
        internal sealed class AddressRepoWrapper : AddressRepository
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