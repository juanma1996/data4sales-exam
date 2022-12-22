using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class PeopleLogic : EntityLogic<People>, IPeopleLogic
{
    public PeopleLogic(IRepository<People> peopleRepository) : base(peopleRepository)
    {
    }

    public async Task Add(IEnumerable<People> entity)
    {
        foreach (var item in entity)
        {
            await Add(item);
        }
    }

    public async Task<int> Add(People entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(int id, People entity)
    {
        throw new NotImplementedException();
    }
}