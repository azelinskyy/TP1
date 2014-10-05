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
                            City = model.City != null ? model.City.Name : null, 
                            DateAdded = model.DateAdded.ToShortDateString(), 
                            Title = model.Title, 
                            ZipCode = model.ZipCode,
                            Architect = model.Architect != null ? model.Architect.Name : null,
                            DateModified = model.DateModified,
                            Description  = model.Description,
                            FinishDate = model.FinishDate != null ? model.FinishDate.DateTime : null,
                            Owner = model.Owner != null ? model.Owner.Name : null,
                            Price  = model.Price,
                            Space  = model.Space,
                            StartDate = model.StartDate != null ? model.StartDate.DateTime : null
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
                           //City = obj.City.Name,
                          // DateAdded = obj.DateAdded.ToShortDateString(),
                           Title = obj.Title,
                           ZipCode = obj.ZipCode,
                           //Architect = obj.Architect != null ? model.Architect.Name : null,
                           DateModified = obj.DateModified,
                           Description = obj.Description,
                          // FinishDate = obj.FinishDate != null ? model.FinishDate.DateTime : null,
                          // Owner = obj.Owner != null ? model.Owner.Name : null,
                           Price = obj.Price,
                           Space = obj.Space,
                          // StartDate = obj.StartDate != null ? obj.StartDate : null
                       };
        }

        #endregion
    }
}