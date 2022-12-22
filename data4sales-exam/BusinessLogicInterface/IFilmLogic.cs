using Domain;

namespace BusinessLogicInterface;

public interface IFilmLogic : IEntityLogic<Film>
{
    Task Add(IEnumerable<Film> entity);
    Task<int> Add(Film entity);
    Task Update(int id, Film entity);
}