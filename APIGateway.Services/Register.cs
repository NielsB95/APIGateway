using APIGateway.Services.ServiceRegistration;
using Microsoft.Extensions.DependencyInjection;

namespace APIGateway.Services
{
    public static class Register
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
            services.AddSingleton<IMicroserviceManager>(new MicroserviceManager());

            return services;
        }
    }
}
