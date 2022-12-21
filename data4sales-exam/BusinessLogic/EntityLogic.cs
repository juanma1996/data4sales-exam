using BusinessLogicInterface;
using DataAccessInterface;

namespace BusinessLogic
{
    public class EntityLogic<T> : IEntityLogic<T> where T : class
    {
        internal readonly IRepository<T> repository;

        public EntityLogic(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> Get(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await repository.GetAllAsync();
        }

        public async Task Delete(int id)
        {
            await repository.DeleteAsync(id);
        }
    }
}
