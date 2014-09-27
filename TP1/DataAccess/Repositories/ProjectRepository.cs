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
    using System.Collections.Generic;
    using System.Data;
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
            this.GetDbContext().Entry(item).State = EntityState.Detached;
            this.GetDbContext().Entry(item).State = EntityState.Modified;
            this.GetDbContext().SaveChanges();
        }

        #endregion
    }
}