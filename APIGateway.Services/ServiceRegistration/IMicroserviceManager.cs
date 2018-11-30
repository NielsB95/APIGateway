using System;
using System.Collections.Generic;
using APIGateway.Services.Entities;

namespace APIGateway.Services.ServiceRegistration
{
    public interface IMicroserviceManager
    {
        bool Register(Microservice service);
        IList<Microservice> RegisteredServices();
        IList<Endpoint> GetEndpoints(Guid serviceID);
    }
}
