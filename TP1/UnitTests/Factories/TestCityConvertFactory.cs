// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestCityConvertFactory.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The test city convert factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTests.Factories
{
    using Model.DomainModels;
    using Model.DTOs;

    using NUnit.Framework;

    using Services.Factories;

    /// <summary>
    /// The test city convert factory.
    /// </summary>
    [TestFixture]
    public class TestCityConvertFactory
    {
        #region Fields

        /// <summary>
        /// The converter.
        /// </summary>
        private CityConvertFactory converter;

        /// <summary>
        /// The dto.
        /// </summary>
        private CityDto dto;

        /// <summary>
        /// The model.
        /// </summary>
        private City model;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.dto = new CityDto { Id = 143, Name = "Lviv" };

            this.model = new City { Id = 143, Name = "Lviv" };

            this.converter = new CityConvertFactory();
        }

        /// <summary>
        /// The test from model.
        /// </summary>
        [Test]
        public void TestFromModel()
        {
            CityDto result = this.converter.FromModel(this.model);
            Assert.AreEqual(this.dto.Id, result.Id);
            Assert.AreEqual(this.dto.Name, result.Name);
        }

        /// <summary>
        /// The test to model.
        /// </summary>
        [Test]
        public void TestToModel()
        {
            City result = this.converter.ToModel(this.dto);
            Assert.AreEqual(this.model.Id, result.Id);
            Assert.AreEqual(this.model.Name, result.Name);
        }

        #endregion
    }
}