namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using DataAccess.Repositories.Interfaces.Async;

    using Infrastructure.Helpers;

    using Model.DomainModels;
    using Model.Filters;

    public class ProjectRepositoryAsync : RepositoryBaseAsync<Project>, IProjectRepositoryAsync
    {
        #region Public Methods and Operators

        public override async Task AddAsync(Project item)
        {
            if (item.Id != 0)
            {
                throw new ArgumentOutOfRangeException("Id");
            }

            item.DateAdded = DateTime.Now;
            this.GetDbContext().Projects.Add(item);
            await this.GetDbContext().SaveChangesAsync().ConfigureAwait(false);
        }

        public override async Task AddRangeAsync(IList<Project> items)
        {
            this.GetDbContext().Projects.AddRange(items);
            await this.GetDbContext().SaveChangesAsync().ConfigureAwait(false);
        }

        public override async Task<List<Project>> GetAllAsync()
        {
            return await this.GetDbContext().Projects.ToListAsync().ConfigureAwait(false);
        }

        public override async Task<Project> GetByIdAsync(int id)
        {
            return await this.GetDbContext().Projects.SingleAsync(p => p.Id == id).ConfigureAwait(false);
        }

        public override async Task<int> GetCountAsync()
        {
            return await this.GetDbContext().Projects.CountAsync().ConfigureAwait(false);
        }

        public async Task<List<Project>> GetProjectsFilteredByDateRangeExcludingIdsAsync(ProjectGridFilter filter)
        {
            var dueDate = filter.To.AddTicks(new TimeSpan(0, 23, 59, 59).Ticks);
            IQueryable<Project> projects =
                this.GetDbContext().Projects.Where(p => p.DateAdded >= filter.From && p.DateAdded <= dueDate);

            // exclude manually unselected projects
            if (filter.UnselectedIds != null && filter.UnselectedIds.Any())
            {
                projects = projects.Where(p => !filter.UnselectedIds.Contains(p.Id));
            }

            return await projects.ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> GetProjectsFilteredByDateRangeCountAsync(ProjectGridFilter filter)
        {
            var dueDate = filter.To.AddTicks(new TimeSpan(0, 23, 59, 59).Ticks);
            IQueryable<Project> projects =
                this.GetDbContext().Projects.Where(p => p.DateAdded >= filter.From && p.DateAdded <= dueDate);
            return await projects.CountAsync().ConfigureAwait(false);
        }

        public async Task<List<Project>> GetProjectsFilteredByProjectGridAsync(ProjectGridFilter filter)
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
            return await projects.ToListAsync().ConfigureAwait(false);
        }

        public override async Task RemoveAsync(Project item)
        {
            Project projectToRemove = await this.GetDbContext().Projects.SingleAsync(p => p.Id == item.Id);
            this.GetDbContext().Projects.Remove(projectToRemove);
            await this.GetDbContext().SaveChangesAsync().ConfigureAwait(false);
        }

        public override async Task RemoveRangeAsync(IList<Project> items)
        {
            List<int> itemIds = items.Select(i => i.Id).ToList();
            IQueryable<Project> projectsToRemove = this.GetDbContext().Projects.Where(p => itemIds.Contains(p.Id));
            this.GetDbContext().Projects.RemoveRange(projectsToRemove);
            await this.GetDbContext().SaveChangesAsync().ConfigureAwait(false);
        }

        public override async Task UpdateAsync(Project item)
        {
            Project project = await this.GetByIdAsync(item.Id);
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

            await this.GetDbContext().SaveChangesAsync().ConfigureAwait(false);
        }

        #endregion
    }
}
