using Domain;

namespace ApiClientInterface
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string url);
        Task<IEnumerable<T>> GetListAsync<T>(IEnumerable<string> urls);
        Task<Planet> GetPlanetAsync(string id);
        Task<List<Film>> GetAllFilmAsync();
    }
}