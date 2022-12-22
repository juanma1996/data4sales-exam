using Domain;

namespace BusinessLogicInterface;

public interface IPlanetLogic : IEntityLogic<Planet>
{
    Task Add(IEnumerable<Planet> entity);
    Task<int> Add(Planet entity);
    Task Update(int id, Planet entity);
}