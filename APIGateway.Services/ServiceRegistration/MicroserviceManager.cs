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

        public IList<Endpoint> GetEndpoints(Guid serviceID)
        {
            return microservices[serviceID].Endpoints;
        }

        /// <summary>
        /// Register the specified service and all its endpoints.
        /// </summary>
        /// <param name="service">Service.</param>
        public bool Register(Microservice service)
        {
            var isValid = service.Validate();
            if (!isValid)
                return false;

            // Add the microservice.
            this.microservices.TryAdd(service.ID, service);

            // Add all the endpoints exposed by this service.
            foreach (var endpoint in service.Endpoints)
                this.endpoints.TryAdd(endpoint.Signature, service.ID);

            // Succesfull if we've made it this far.
            return true;
        }

        /// <summary>
        /// Returns a list the registered services.
        /// </summary>
        /// <returns>The services.</returns>
        public IList<Microservice> RegisteredServices()
        {
            return this.microservices.Select(x => x.Value).ToList();
        }

        /// <summary>
        /// Try to match the specified path on a Microservice.
        /// </summary>
        /// <returns>The match.</returns>
        /// <param name="path">Path.</param>
        public Microservice Match(string method, string path)
        {
            // Check if the first char is a slash. Remove when true.
            if (path.First().Equals('/'))
                path = string.Concat(path.SkipWhile(x => x.Equals('/')));

            // Make sure the method is written in UPPERCASE.
            method = method.ToUpper();

            var endpointKey = string.Format("{0}-{1}", method, path);

            // Get the microservice guid based on the registered paths.
            this.endpoints.TryGetValue(endpointKey, out Guid guid);

            // Return if no matching service was found.
            if (guid.Equals(Guid.Empty))
                return null;

            // Get service by Guid
            this.microservices.TryGetValue(guid, out Microservice service);

            // and return it.
            return service;
        }
    }
}