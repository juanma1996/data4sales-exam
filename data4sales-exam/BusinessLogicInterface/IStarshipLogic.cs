using Domain;

namespace BusinessLogicInterface;

public interface IStarshipLogic : IEntityLogic<Starship>
{
    Task Add(IEnumerable<Starship> entity);
    Task<int> Add(Starship entity);
    Task Update(int id, Starship entity);
}