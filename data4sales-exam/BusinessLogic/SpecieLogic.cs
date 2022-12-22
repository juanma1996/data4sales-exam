using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class SpecieLogic : EntityLogic<Specie>, ISpecieLogic
{
    public SpecieLogic(IRepository<Specie> specieRepository) : base(specieRepository)
    {
    }

    public Task Add(List<Specie> entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> Add(Specie entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Specie entity)
    {
        throw new NotImplementedException();
    }
}