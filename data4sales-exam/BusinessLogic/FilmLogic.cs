using BusinessLogicInterface;
using DataAccessInterface;
using Domain;

namespace BusinessLogic;

public class FilmLogic : EntityLogic<Film>, IFilmLogic
{
    public FilmLogic(IRepository<Film> filmRepository) : base(filmRepository)
    {
    }

    public async Task Add(IEnumerable<Film> entity)
    {
        foreach (var item in entity)
        {
            await Add(item);
        }
    }

    public async Task<int> Add(Film entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(int id, Film entity)
    {
        throw new NotImplementedException();
    }
}