using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIGateway.Services.Entities.Base.Validation.Attributes;

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

        [Required]
        public string Name { get; set; }

        [Required]
        public Uri DomainName { get; set; }

        [Required]
        public int Port { get; set; }

        public string Version { get; set; }

        [ListNotEmptyOrNull]
        public IList<Endpoint> Endpoints { get; set; }
    }
}