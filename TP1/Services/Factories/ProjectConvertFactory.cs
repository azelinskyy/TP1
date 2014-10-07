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
                           Address = model.Address != null ? model.Address.AddressString : null,
                           ZipCode = model.ZipCode,
                           Architect = model.Architect != null ? model.Architect.Name : null,
                           DateModified = model.DateModified,
                           Description = model.Description,
                           FinishDate = model.FinishDate != null ? model.FinishDate.Description : null,
                           Owner = model.Owner != null ? model.Owner.Name : null,
                           Price = model.Price,
                           Space = model.Space,
                           StartDate = model.StartDate != null ? model.StartDate.Description : null,
                           PlannedApplicationDate = model.PlannedApplicationDate,
                           BuildersRepresentative = model.BuildersRepresentative != null ? model.BuildersRepresentative.Name : null
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
                           City = !string.IsNullOrEmpty(obj.City) ? new City { Name = obj.City } : null,
                           Title = obj.Title,
                           Address = !string.IsNullOrEmpty(obj.Address) ? new Address { AddressString = obj.Address } : null,
                           ZipCode = obj.ZipCode,
                           Architect = !string.IsNullOrEmpty(obj.Architect) ? new Company { Name = obj.Architect } : null,
                           DateModified = obj.DateModified,
                           Description = obj.Description,
                           FinishDate = !string.IsNullOrEmpty(obj.FinishDate) ? new DomainDate { Description = obj.FinishDate } : new DomainDate(),
                           Owner = !string.IsNullOrEmpty(obj.Owner) ? new Company { Name = obj.Owner } : null,
                           Price = obj.Price,
                           Space = obj.Space,
                           StartDate = !string.IsNullOrEmpty(obj.StartDate) ? new DomainDate { Description = obj.StartDate } : new DomainDate(),
                           PlannedApplicationDate = obj.PlannedApplicationDate,
                           BuildersRepresentative = !string.IsNullOrEmpty(obj.BuildersRepresentative) ? new Company { Name = obj.BuildersRepresentative } : null
                       };
        }

        #endregion
    }
}