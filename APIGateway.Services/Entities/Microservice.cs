using System;
using System.Collections.Generic;

namespace APIGateway.Services.Entities
{
    public class Microservice
    {
        private Guid id;
        public Guid ID
        {
            get
            {
                if (this.id == default(Guid))
                    this.id = new Guid();
                return this.id;
            }
        }

        public string Name { get; set; }
        public Uri DomainName { get; set; }
        public int Port { get; set; }

        public IList<Endpoint> Endpoints { get; set; }
    }
}