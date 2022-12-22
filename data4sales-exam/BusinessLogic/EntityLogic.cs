using BusinessLogicInterface;
using DataAccessInterface;

namespace BusinessLogic
{
    public class EntityLogic<T> : IEntityLogic<T> where T : class
    {
        internal readonly IRepository<T> Repository;

        public EntityLogic(IRepository<T> repository)
        {
            this.Repository = repository;
        }

        public async Task<T> Get(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await Repository.GetAllAsync();
        }

        public async Task Delete(int id)
        {
            await Repository.DeleteAsync(id);
        }
    }
}
