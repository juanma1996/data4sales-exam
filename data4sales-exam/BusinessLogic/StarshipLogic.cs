using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class StarshipLogic : EntityLogic<Starship>, IStarshipLogic
    {
        public StarshipLogic(IRepository<Starship> starshipRepository) : base(starshipRepository) { }

        public Task Add(List<Starship> entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Add(Starship entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Starship entity)
        {
            throw new NotImplementedException();
        }
    }
}
