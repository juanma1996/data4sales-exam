using ApiClient;
using ApiClientInterface;
using BusinessLogic;
using BusinessLogicInterface;
using DataAccess;
using DataAccessInterface;
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
            services.AddScoped(typeof(IEntityLogic<>), typeof(EntityLogic<>));
            services.AddScoped<IPlanetLogic, PlanetLogic>();
            services.AddScoped<IPeopleLogic, PeopleLogic>();
            services.AddScoped<IFilmLogic, FilmLogic>();
            services.AddScoped<ISpecieLogic, SpecieLogic>();
            services.AddScoped<IStarshipLogic, StarshipLogic>();
            services.AddScoped<IVehicleLogic, VehicleLogic>();
            services.AddScoped<IApiClient, StarWarsApiClient>();
            services.AddScoped<IImporterRepository, ImporterRepository>();
        }
    }
}
