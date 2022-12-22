using Domain;

namespace BusinessLogicInterface;

public interface ISpecieLogic : IEntityLogic<Specie>
{
    Task Add(List<Specie> entity);
    Task<int> Add(Specie entity);
    Task Update(int id, Specie entity);
}