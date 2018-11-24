using APIGateway.Services.Entities;

namespace APIGateway.Services.ServiceRegistration
{
    public interface IMicroserviceManager
    {
        bool Register(Microservice service);

        bool Validate(Microservice service);
    }
}
