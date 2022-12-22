using Domain;

namespace BusinessLogicInterface;

public interface ISpecieLogic : IEntityLogic<Specie>
{
    Task Add(IEnumerable<Specie> entity);
    Task<int> Add(Specie entity);
    Task Update(int id, Specie entity);
}