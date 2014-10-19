namespace DataAccess.Repositories.Interfaces.Async
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Model.DomainModels;

    public interface IRepositoryBaseAsync<T> where T : DomainModel
    {
        Task AddAsync(T item);

        Task AddRangeAsync(IList<T> items);

        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<int> GetCountAsync();

        Task RemoveAsync(T item);

        Task RemoveRangeAsync(IList<T> items);

        Task UpdateAsync(T item);
    }
}
