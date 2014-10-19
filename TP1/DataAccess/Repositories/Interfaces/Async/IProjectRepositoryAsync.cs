namespace DataAccess.Repositories.Interfaces.Async
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Model.DomainModels;
    using Model.Filters;

    public interface IProjectRepositoryAsync : IRepositoryBaseAsync<Project>
    {
        Task<List<Project>> GetProjectsFilteredByDateRangeExcludingIdsAsync(ProjectGridFilter filter);

        Task<int> GetProjectsFilteredByDateRangeCountAsync(ProjectGridFilter filter);

        Task<List<Project>> GetProjectsFilteredByProjectGridAsync(ProjectGridFilter filter);
    }
}
