// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestProjectRepository.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The test project repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UnitTests.DataAccess
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;

    using global::DataAccess.Repositories;

    using global::Infrastructure.Contexts;

    using Model.DomainModels;
    using Model.Filters;

    using NUnit.Framework;

    /// <summary>
    ///     The test project repository.
    /// </summary>
    [TestFixture]
    public class TestProjectRepository
    {
        #region Fields

        /// <summary>
        ///     The proj.
        /// </summary>
        private Project proj;

        /// <summary>
        ///     The repo.
        /// </summary>
        private ProjectRepoWrapper repo;

        /// <summary>
        ///     The repo.
        /// </summary>
        private ProjectRepoWrapperAsync repoAsync;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.repo = new ProjectRepoWrapper();
            this.repoAsync = new ProjectRepoWrapperAsync();
            DateTime modify = DateTime.Now;
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            this.proj = new Project
                            {
                                Id = 143, 
                                City = new City { Id = 32, Name = "Lviv" }, 
                                DateAdded = DateTime.ParseExact("06/16/1986", "d", CultureInfo.InvariantCulture), 
                                Title = "Test proj", 
                                ZipCode = "79031", 
                                Address = new Address { AddressString = "Home" }, 
                                Architect = new Company { Name = "A" }, 
                                DateModified = modify, 
                                StartDate = new DomainDate { DateTime = start, Description = "Start" }, 
                                Description = "Cool project", 
                                FinishDate = new DomainDate { DateTime = end, Description = "End" }, 
                                Owner = new Company { Name = "Me" }, 
                                Price = "10443", 
                                Space = "to big"
                            };
        }

        /// <summary>
        ///     The tear down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.repo = null;
        }

        [Test]
        public async void TestAsync()
        {
            int n = 100;
            var sw = new Stopwatch();
            sw.Start();
            int sumSunc = 0;
            for (int i = 0; i < n; i++)
            {
                sumSunc += this.repo.GetCount();
            }

            sw.Stop();
            TimeSpan timeSync = sw.Elapsed;

            sw.Restart();
            int sumAsync = 0;
            for (int i = 0; i < n; i++)
            {
                sumAsync += await this.repo.GetProjectsCountAsync();
            }

            sw.Stop();
            TimeSpan timeAsync = sw.Elapsed;
            long k = timeSync.Ticks / timeAsync.Ticks;
            Assert.AreEqual(sumAsync, sumSunc);
            Assert.Less(timeAsync, timeSync);
        }

        [Test]
        public async void TestToListAsync()
        {
            var filter = new ProjectGridFilter { From = DateTime.Now.AddDays(-7), To = DateTime.Now };
            var list = await this.repoAsync.GetProjectsFilteredByProjectGridAsync(filter);
            Assert.True(list.Any());
        }

        /// <summary>
        ///     The test add.
        /// </summary>
        [Test]
        public void TestAdd()
        {
            int countBeforeAdd = this.repo.GetAll().Count();
            this.proj.Id = 0;
            this.repo.Add(this.proj);
            int countAfterAdd = this.repo.GetAll().Count();
            Assert.AreEqual(countAfterAdd - countBeforeAdd, 1);
            Assert.AreNotEqual(this.proj.Id, 0);
        }

        /// <summary>
        ///     The test delete.
        /// </summary>
        [Test]
        public void TestDelete()
        {
            int countBeforeAdd = this.repo.GetAll().Count();
            this.proj.Id = 0;
            this.repo.Add(this.proj);
            int countAfterAdd = this.repo.GetAll().Count();
            Assert.AreEqual(countAfterAdd - countBeforeAdd, 1);

            this.repo.Remove(this.proj);
            int countAfterDel = this.repo.GetAll().Count();

            Assert.AreEqual(countBeforeAdd, countAfterDel);
            Assert.Throws<InvalidOperationException>(() => this.repo.GetById(this.proj.Id));
        }

        /// <summary>
        ///     The test exception on add.
        /// </summary>
        [Test]
        public void TestExceptionOnAdd()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.repo.Add(this.proj));
        }

        /// <summary>
        ///     The test update.
        /// </summary>
        [Test]
        public void TestUpdate()
        {
            this.proj.Id = 0;
            this.repo.Add(this.proj);

            this.proj.Price = "0";
            this.repo.Update(this.proj);

            Project projFromDb = this.repo.GetById(this.proj.Id);
            Assert.AreEqual(this.proj.Price, projFromDb.Price);
        }

        #endregion

        /// <summary>
        ///     The project repo wrapper.
        /// </summary>
        internal sealed class ProjectRepoWrapper : ProjectRepository
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

        internal sealed class ProjectRepoWrapperAsync : ProjectRepositoryAsync
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