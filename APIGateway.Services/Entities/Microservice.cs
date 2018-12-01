using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using APIGateway.Services.Entities.Base;
using APIGateway.Services.Entities.Base.Validation.Attributes;

namespace APIGateway.Services.Entities
{
    [DebuggerDisplay("{Name}")]
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
        [ValidUrl]
        public string DomainName { get; set; }

        [Required]
        public int Port { get; set; }

        public string Version { get; set; }

        [NotNullOrEmpty]
        public IList<Endpoint> Endpoints { get; set; }

        public string Url
        {
            get
            {
                return string.Format("{0}:{1}", DomainName, Port);
            }
        }
    }
}