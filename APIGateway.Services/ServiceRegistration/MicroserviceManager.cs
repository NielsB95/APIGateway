using System;
using System.Collections.Concurrent;
using APIGateway.Services.Entities;
using System.Collections.Generic;
using System.Linq;

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
        public bool Register(Microservice service)
        {
            var validationResult = service.Validate();
            if (!validationResult)
                return false;

            // Add the microservice.
            this.microservices.TryAdd(service.ID, service);

            // Add all the endpoints exposed by this service.
            foreach (var endpoint in service.Endpoints)
                if (this.endpoints.TryAdd(endpoint.Signature, service.ID))
                    Console.WriteLine("Added endpoint");
                else
                    Console.WriteLine("Endpoint exists already");

            // Succesfull if we've made it this far.
            return true;
        }

        public IList<Microservice> RegisteredServices()
        {
            return this.microservices.Select(x => x.Value).ToList();
        }
    }
}