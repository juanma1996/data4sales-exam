using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class SpecieLogic : EntityLogic<Specie>, ISpecieLogic
{
    public SpecieLogic(IRepository<Specie> specieRepository) : base(specieRepository)
    {
    }

    public async Task Add(IEnumerable<Specie> entity)
    {
        foreach (var item in entity)
        {
            await Add(item);
        }
    }

    public async Task<int> Add(Specie entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(int id, Specie entity)
    {
        throw new NotImplementedException();
    }
}