using System.Net.Http.Headers;
using System.Text.Json;
using ApiClientInterface;
using Domain;

namespace ApiClient;

public class StarWarsApiClient : IApiClient
{
    protected readonly string AcceptHeader = "application/json";
    protected readonly string BaseAddress = @"http://swapi.dev/api/";

    public async Task<IEnumerable<T>> GetListAsync<T>(IEnumerable<string> urls)
    {
        var t = Task.Run(() =>
        {
            var items = urls.Select(url => GetAsync<T>(url).Result).ToList();
            return items.AsEnumerable();
        });

        return await t;
    }

    public async Task<IEnumerable<Film>> GetAllFilmAsync()
    {
        const string url = "films";
        var res = await GetAsync<Response>(url);
        return res.Results;
    }

    private HttpClient GetClient()
    {
        var client = new HttpClient();

        client.BaseAddress = new Uri(BaseAddress);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptHeader));

        return client;
    }

    public async Task<T> GetAsync<T>(string url)
    {
        using var client = GetClient();
        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<T>(jsonResponse)!;
        return result;
    }
}