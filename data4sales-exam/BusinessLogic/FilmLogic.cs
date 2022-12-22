using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class FilmLogic : EntityLogic<Film>, IFilmLogic
{
    public FilmLogic(IRepository<Film> filmRepository) : base(filmRepository)
    {
    }

    public Task Add(IEnumerable<Film> entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> Add(Film entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, Film entity)
    {
        throw new NotImplementedException();
    }
}