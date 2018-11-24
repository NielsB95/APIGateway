using APIGateway.Services.Entities;

namespace APIGateway.Services.ServiceRegistration
{
    public interface IMicroserviceManager
    {
        void Register(Microservice service);
    }
}
