// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestProjectConvertFactory.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The test project convert factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTests.Factories
{
    using System;
    using System.Globalization;

    using Model.DomainModels;
    using Model.DTOs;

    using NUnit.Framework;

    using Services.Factories;

    /// <summary>
    /// The test project convert factory.
    /// </summary>
    [TestFixture]
    public class TestProjectConvertFactory
    {
        #region Fields

        /// <summary>
        /// The converter.
        /// </summary>
        private ProjectConvertFactory converter;

        /// <summary>
        /// The dto.
        /// </summary>
        private ProjectDto dto;

        /// <summary>
        /// The model.
        /// </summary>
        private Project model;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.dto = new ProjectDto
                           {
                               Id = 143, 
                               City = new CityDto { Id = 32, Name = "Lviv" }, 
                               DateAdded = DateTime.ParseExact("06/16/1986", "d", CultureInfo.InvariantCulture), 
                               Title = "Test proj", 
                               ZipCode = "79031"
                           };

            this.model = new Project
                             {
                                 Id = 143, 
                                 City = new City { Id = 32, Name = "Lviv" }, 
                                 DateAdded = DateTime.ParseExact("06/16/1986", "d", CultureInfo.InvariantCulture), 
                                 Title = "Test proj", 
                                 ZipCode = "79031"
                             };

            this.converter = new ProjectConvertFactory();
        }

        /// <summary>
        /// The test from model.
        /// </summary>
        [Test]
        public void TestFromModel()
        {
            ProjectDto result = this.converter.FromModel(this.model);
            Assert.AreEqual(this.dto.Id, result.Id);
            Assert.AreEqual(this.dto.City.Id, result.City.Id);
            Assert.AreEqual(this.dto.City.Name, result.City.Name);
            Assert.AreEqual(this.dto.DateAdded, result.DateAdded);
            Assert.AreEqual(this.dto.Title, result.Title);
            Assert.AreEqual(this.dto.ZipCode, result.ZipCode);
        }

        /// <summary>
        /// The test to model.
        /// </summary>
        [Test]
        public void TestToModel()
        {
            Project result = this.converter.ToModel(this.dto);
            Assert.AreEqual(this.model.Id, result.Id);
            Assert.AreEqual(this.model.City.Id, result.City.Id);
            Assert.AreEqual(this.model.City.Name, result.City.Name);
            Assert.AreEqual(this.model.DateAdded, result.DateAdded);
            Assert.AreEqual(this.model.Title, result.Title);
            Assert.AreEqual(this.model.ZipCode, result.ZipCode);
        }

        #endregion
    }
}