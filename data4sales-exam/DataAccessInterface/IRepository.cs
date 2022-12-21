

namespace DataAccessInterface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<int> AddAsync(T entity, string script);
        Task UpdateAsync(T entity, string script);
        Task DeleteAsync(int id);
        Task InsertRelation(string script);
    }
}
