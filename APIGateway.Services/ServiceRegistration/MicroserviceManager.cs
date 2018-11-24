using System;
using System.Linq;
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
        public bool Register(Microservice service)
        {
            var validationResult = this.Validate(service);
            if (!validationResult)
                return false;

            // Add the microservice.
            this.microservices.TryAdd(service.ID, service);

            // Add all the endpoints exposed by this service.
            foreach (var endpoint in service.Endpoints)
                if (this.endpoints.TryAdd("", service.ID))
                    Console.WriteLine("Added endpoint");
                else
                    Console.WriteLine("Endpoint exists already");

            // Succesfull if we've made it this far.
            return true;
        }

        /// <summary>
        /// Validate the specified service.
        /// </summary>
        /// <returns>The validate.</returns>
        /// <param name="service">Service.</param>
        public bool Validate(Microservice service)
        {
            if (service == null)
                return false;

            if (service.Endpoints == null || !service.Endpoints.Any())
                return false;

            return true;
        }
    }
}