using Domain;

namespace BusinessLogicInterface
{
    public interface IStarshipLogic : IEntityLogic<Starship>
    {
        Task Add(List<Starship> entity);
        Task<int> Add(Starship entity);
        Task Update(int id, Starship entity);
    }
}
