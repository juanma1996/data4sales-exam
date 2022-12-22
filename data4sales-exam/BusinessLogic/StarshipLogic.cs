using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class StarshipLogic : EntityLogic<Starship>, IStarshipLogic
{
    public StarshipLogic(IRepository<Starship> starshipRepository) : base(starshipRepository)
    {
    }

    public async Task Add(IEnumerable<Starship> entity)
    {
        foreach (var item in entity)
        {
            await Add(item);
        }
    }

    public async Task<int> Add(Starship entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(int id, Starship entity)
    {
        throw new NotImplementedException();
    }
}