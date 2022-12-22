using Domain;

namespace BusinessLogicInterface;

public interface IPeopleLogic : IEntityLogic<People>
{
    Task Add(List<People> entity);
    Task<int> Add(People entity);
    Task Update(int id, People entity);
}