namespace BusinessLogicInterface
{
    public interface IEntityLogic<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task Delete(int id);
    }
}
