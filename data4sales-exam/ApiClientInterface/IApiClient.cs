using Domain;

namespace ApiClientInterface;

public interface IApiClient
{
    Task<IEnumerable<T>> GetListAsync<T>(IEnumerable<string> urls);
    Task<List<Film>> GetAllFilmAsync();
}