using ApiClientInterface;
using Domain;
using System.Net.Http.Headers;

namespace ApiClient
{
    public class StarWarsApiClient : IApiClient
    {
        readonly protected string BaseAddress = @"http://swapi.dev/api/";
        readonly protected string AcceptHeader = "application/json";

        HttpClient GetClient()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(BaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptHeader));

            return client;
        }

        public async Task<T> GetAsync<T>(string url)
        {

            try
            {
                T result = default(T);

                using (HttpClient client = GetClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    //throw if error
                    response.EnsureSuccessStatusCode();
                    result = await response.Content.ReadAsAsync<T>();
                }

                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(IEnumerable<string> urls)
        {

            Task<IEnumerable<T>> t = Task.Run(() =>
            {
                List<T> items = new List<T>();
                foreach (var url in urls)
                {
                    T item = GetAsync<T>(url).Result;
                    items.Add(item);

                }
                return items.AsEnumerable();
            });

            return await t;

        }

        public async Task<Planet> GetPlanetAsync(string id)
        {
            string url = string.Format("{0}/{1}", "planets", id);
            return await GetAsync<Planet>(url);
        }

        public async Task<List<Film>> GetAllFilmAsync()
        {
            var url = string.Format("films");
            var res = await GetAsync<Response>(url);
            return res.results;
        }
    }
}