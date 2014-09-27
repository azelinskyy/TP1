// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectRepository.cs" company="Team Alpha Solutions">
//   Copyright © 2014 Team Alpha Solutions
// </copyright>
// <summary>
//   The project repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Model.DomainModels;

    /// <summary>
    /// The project repository.
    /// </summary>
    public class ProjectRepository : RepositoryBase<Project>
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public override void Add(Project item)
        {
            if (item.Id != 0)
            {
                throw new ArgumentOutOfRangeException("Id");
            }

            this.GetDbContext().Projects.Add(item);
            this.GetDbContext().SaveChanges();
        }

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public override void AddRange(IEnumerable<Project> items)
        {
            foreach (Project project in items)
            {
                this.GetDbContext().Projects.Add(project);
            }

            this.GetDbContext().SaveChanges();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public override IEnumerable<Project> GetAll()
        {
            return this.GetDbContext().Projects;
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Project"/>.
        /// </returns>
        public override Project GetById(int id)
        {
            return this.GetDbContext().Projects.Single(p => p.Id == id);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public override void Remove(Project item)
        {
            this.GetDbContext().Projects.Remove(item);
            this.GetDbContext().SaveChanges();
        }

        /// <summary>
        /// The remove range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public override void RemoveRange(IEnumerable<Project> items)
        {
            foreach (Project project in items)
            {
                this.GetDbContext().Projects.Remove(project);
            }

            this.GetDbContext().SaveChanges();
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public override void Update(Project item)
        {
            Project project = this.GetById(item.Id);
            project.Address = item.Address;
            project.Architect = item.Architect;
            project.City = item.City;
            project.DateAdded = item.DateAdded;
            project.DateModified = item.DateModified;
            project.Description = item.Description;
            project.FinishDate = item.FinishDate;
            project.Owner = item.Owner;
            project.Price = item.Price;
            project.Space = item.Space;
            project.StartDate = item.StartDate;
            project.Title = item.Title;
            project.ZipCode = item.ZipCode;

            this.GetDbContext().SaveChanges();
        }

        #endregion
    }
}