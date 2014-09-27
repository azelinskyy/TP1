// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectConvertFactory.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The project convert factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Services.Factories
{
    using System;

    using Model.DomainModels;
    using Model.DTOs;

    /// <summary>
    ///     The project convert factory.
    /// </summary>
    public class ProjectConvertFactory : IConvertFactory<Project, ProjectDto>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The from model.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ProjectDto"/>.
        /// </returns>
        public ProjectDto FromModel(Project model)
        {
            return new ProjectDto
                       {
                           Id = model.Id,
                           City = new CityConvertFactory().FromModel(model.City), 
                           DateAdded = model.DateAdded, 
                           Title = model.Title, 
                           ZipCode = model.ZipCode
                       };
        }

        /// <summary>
        /// The to model.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="Project"/>.
        /// </returns>
        /// <exception cref="NotImplementedException">
        /// </exception>
        public Project ToModel(ProjectDto obj)
        {
            return new Project
                       {
                           Id = obj.Id,
                           City = new CityConvertFactory().ToModel(obj.City),
                           DateAdded = obj.DateAdded,
                           Title = obj.Title,
                           ZipCode = obj.ZipCode
                       };
        }

        #endregion
    }
}