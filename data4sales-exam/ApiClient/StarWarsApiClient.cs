using ApiClientInterface;
using Domain;
using System.Net.Http.Headers;

namespace ApiClient
{
    public class StarWarsApiClient : IApiClient
    {
        protected readonly string BaseAddress = @"http://swapi.dev/api/";
        protected readonly string AcceptHeader = "application/json";

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
            var result = await response.Content.ReadAsAsync<T>();

            return result;
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(IEnumerable<string> urls)
        {

            var t = Task.Run(() =>
            {
                var items = urls.Select(url => GetAsync<T>(url).Result).ToList();
                return items.AsEnumerable();
            });

            return await t;

        }

        public async Task<List<Film>> GetAllFilmAsync()
        {
            const string url = "films";
            var res = await GetAsync<Response>(url);
            return res.Results;
        }
    }
}