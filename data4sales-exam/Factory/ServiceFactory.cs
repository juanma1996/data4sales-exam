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
        }
    }
}
