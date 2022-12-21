using Domain;

namespace BusinessLogicInterface
{
    public interface IPlanetLogic
    {
        Task Add(List<Planet> entity);
        Task<int> Add(Planet entity);
        Task Update(int id, Planet entity);
    }
}
