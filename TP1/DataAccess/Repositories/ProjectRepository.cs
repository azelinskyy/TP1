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
    using System.Data.SqlClient;
    using System.Linq;

    using Infrastructure.Helpers;

    using Model.DomainModels;
    using Model.Filters;

    /// <summary>
    ///     The project repository.
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

            item.DateAdded = DateTime.Now;
            this.GetDbContext().Projects.Add(item);
            this.GetDbContext().SaveChanges();
        }

        /// <summary>
        /// The add range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public override void AddRange(IList<Project> items)
        {
            foreach (Project project in items)
            {
                this.GetDbContext().Projects.Add(project);
            }

            this.GetDbContext().SaveChanges();
        }

        /// <summary>
        ///     The get all.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerable" />.
        /// </returns>
        public override List<Project> GetAll()
        {
            return this.GetDbContext().Projects.ToList();
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
        /// The get count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetCount()
        {
            return this.GetDbContext().Projects.Count();
        }

        /// <summary>
        /// The get projects filtered by date range.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Project> GetProjectsFilteredByDateRange(ProjectGridFilter filter)
        {
            var dueDate = filter.To.AddTicks(new TimeSpan(0, 23, 59, 59).Ticks);
            IQueryable<Project> projects =
                this.GetDbContext().Projects.Where(p => p.DateAdded >= filter.From && p.DateAdded <= dueDate);
            return projects.ToList();
        }

        /// <summary>
        /// The get projects filtered by date range count.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetProjectsFilteredByDateRangeCount(ProjectGridFilter filter)
        {
            var dueDate = filter.To.AddTicks(new TimeSpan(0, 23, 59, 59).Ticks);
            IQueryable<Project> projects =
                this.GetDbContext().Projects.Where(p => p.DateAdded >= filter.From && p.DateAdded <= dueDate);
            return projects.Count();
        }

        /// <summary>
        /// The get projects filtered by project grid.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public List<Project> GetProjectsFilteredByProjectGrid(ProjectGridFilter filter)
        {
            // General filtering by date
            var dueDate = filter.To.AddTicks(new TimeSpan(0, 23, 59, 59).Ticks);
            IQueryable<Project> projects =
                this.GetDbContext().Projects.Where(p => p.DateAdded >= filter.From && p.DateAdded <= dueDate);

            // sort by id if sorting field is not provided
            if (string.IsNullOrEmpty(filter.SortField))
            {
                filter.SortField = "Id";
            }

            switch (filter.SortOrder)
                {
                    case SortOrder.Unspecified:
                    case SortOrder.Ascending:
                        projects = projects.OrderBy(filter.SortField);
                        break;
                    case SortOrder.Descending:
                        projects = projects.OrderBy(filter.SortField);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            // filtering based on page size and number
            projects = projects.Skip(filter.PageSize * (filter.PageIndex - 1)).Take(filter.PageSize);
            return projects.ToList();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public override void Remove(Project item)
        {
            Project projectToRemove = this.GetDbContext().Projects.Single(p => p.Id == item.Id);
            this.GetDbContext().Projects.Remove(projectToRemove);
            this.GetDbContext().SaveChanges();
        }

        /// <summary>
        /// The remove range.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        public override void RemoveRange(IList<Project> items)
        {
            List<int> itemIds = items.Select(i => i.Id).ToList();
            IQueryable<Project> projectsToRemove = this.GetDbContext().Projects.Where(p => itemIds.Contains(p.Id));
            foreach (Project project in projectsToRemove)
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
            if (item.Address == null || string.IsNullOrEmpty(item.Address.AddressString))
            {
                this.GetDbContext().Entry(project).Reference(p => p.Address).CurrentValue = null;
            }
            else
            {
                (project.Address = project.Address ?? new Address()).AddressString = item.Address.AddressString;
            }

            if (item.Architect == null || string.IsNullOrEmpty(item.Architect.Name))
            {
                this.GetDbContext().Entry(project).Reference(p => p.Architect).CurrentValue = null;
            }
            else
            {
                (project.Architect = project.Architect ?? new Company()).Name = item.Architect.Name;
            }

            if (item.City == null || string.IsNullOrEmpty(item.City.Name))
            {
                this.GetDbContext().Entry(project).Reference(p => p.City).CurrentValue = null;
            }
            else
            {
                (project.City = project.City ?? new City()).Name = item.City.Name;
            }

            if (item.Owner == null || string.IsNullOrEmpty(item.Owner.Name))
            {
                this.GetDbContext().Entry(project).Reference(p => p.Owner).CurrentValue = null;
            }
            else
            {
                (project.Owner = project.Owner ?? new Company()).Name = item.Owner.Name;
            }

            project.DateModified = item.DateModified;
            project.Description = item.Description;
            project.FinishDate = item.FinishDate;
            project.Price = item.Price;
            project.Space = item.Space;
            project.StartDate = item.StartDate;
            project.Title = item.Title;
            project.ZipCode = item.ZipCode;
            project.BuildersRepresentative = item.BuildersRepresentative;
            project.PlannedApplicationDate = item.PlannedApplicationDate;

            this.GetDbContext().SaveChanges();
        }

        #endregion
    }
}