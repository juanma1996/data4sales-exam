using ApiClient;
using ApiClientInterface;
using BusinessLogic;
using BusinessLogicInterface;
using DataAccess;
using DataAccessInterface;
using Domain;
using Microsoft.Extensions.DependencyInjection;


namespace Factory
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;

        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }

        public void AddCustomServices()
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IImporterLogic, ImporterLogic>();
            services.AddScoped<IEntityLogic<Planet>, PlanetLogic>();
            services.AddScoped<IApiClient, StarWarsApiClient>();
            services.AddScoped<IImporterRepository, ImporterRepository>();
        }
    }
}
