// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateDomainContext.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The create domain context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace UnitTests.DbContext
{
    using Infrastructure.Contexts;

    using NUnit.Framework;

    /// <summary>
    ///     The create domain context.
    /// </summary>
    [TestFixture]
    public class CreateDomainContext
    {
        #region Fields

        /// <summary>
        ///     The context.
        /// </summary>
        private DomainContext context;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The domain context can close connection.
        /// </summary>
        [Test]
        public void DomainContextCanCloseConnection()
        {
            this.context.Database.Connection.Open();
            Assert.DoesNotThrow(this.context.Database.Connection.Close);
        }

        /// <summary>
        ///     The domain context can open connection.
        /// </summary>
        [Test]
        public void DomainContextCanOpenConnection()
        {
            Assert.DoesNotThrow(this.context.Database.Connection.Open);
        }

        /// <summary>
        ///     The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.context = new DomainContext();
        }

        /// <summary>
        ///     The system can create domain context.
        /// </summary>
        [Test]
        public void SystemCanCreateDomainContext()
        {
            Assert.IsNotNull(this.context);
        }

        /// <summary>
        ///     The tear down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.context = null;
        }

        #endregion
    }
}