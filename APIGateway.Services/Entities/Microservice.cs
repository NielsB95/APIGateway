using System;
using System.Collections.Generic;

namespace APIGateway.Services.Entities
{
    public class Microservice
    {
        public string Name { get; set; }
        public Uri DomainName { get; set; }
        public int Port { get; set; }

        public IList<Endpoint> Endpoints { get; set; }
    }
}