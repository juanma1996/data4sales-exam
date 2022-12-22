using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class PeopleLogic : EntityLogic<People>, IPeopleLogic
{
    public PeopleLogic(IRepository<People> peopleRepository) : base(peopleRepository)
    {
    }

    public Task Add(List<People> entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> Add(People entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, People entity)
    {
        throw new NotImplementedException();
    }
}