using System;
using System.Collections.Concurrent;
using APIGateway.Services.Entities;

namespace APIGateway.Services.ServiceRegistration
{
    public class MicroserviceManager : IMicroserviceManager
    {
        private readonly ConcurrentDictionary<Guid, Microservice> microservices;
        private readonly ConcurrentDictionary<string, Guid> endpoints;

        public MicroserviceManager()
        {
            this.microservices = new ConcurrentDictionary<Guid, Microservice>();
            this.endpoints = new ConcurrentDictionary<string, Guid>();
        }

        /// <summary>
        /// Register the specified service and all its endpoints.
        /// </summary>
        /// <param name="service">Service.</param>
        public void Register(Microservice service)
        {
            // Add the microservice.
            this.microservices.TryAdd(service.ID, service);

            // Add all the endpoints exposed by this service.
            foreach (var endpoint in service.Endpoints)
                if (this.endpoints.TryAdd("", service.ID))
                    Console.WriteLine("Added endpoint");
                else
                    Console.WriteLine("Endpoint exists already");
        }
    }
}