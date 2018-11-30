using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using APIGateway.Services.Entities.Base;
using APIGateway.Services.Entities.Base.Validation.Attributes;

namespace APIGateway.Services.Entities
{
    public class Microservice : BaseEntity
    {
        private Guid? id;
        public Guid ID
        {
            get
            {
                if (!this.id.HasValue)
                    this.id = Guid.NewGuid();
                return this.id.Value;
            }
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public Uri DomainName { get; set; }

        [Required]
        public int Port { get; set; }

        public string Version { get; set; }

        [NotNullOrEmpty]
        public IList<Endpoint> Endpoints { get; set; }
    }
}