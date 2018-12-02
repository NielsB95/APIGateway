using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using APIGateway.Services.Entities.Base;
using APIGateway.Services.Entities.Base.Validation.Attributes;
using APIGateway.Services.Util;
using Newtonsoft.Json;

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

        public int? Port { get; set; }

        public string Version { get; set; }

        /// <summary>
        /// This property defines the prefix of the microservice that is
        /// used for composing the exposed endpoint.
        /// </summary>
        /// <value>The prefix.</value>
        public string Prefix { get; set; }

        [NotNullOrEmpty]
        public IList<Endpoint> Endpoints { get; set; }

        public string ServiceUrl
        {
            get
            {
                if (Port.HasValue)
                    return string.Format("{0}:{1}", DomainName, Port);
                else
                    return DomainName;
            }
        }

        public string GatewayBaseUrl
        {
            get
            {
                return UrlComposer.ComposeGatewayBaseUrl(this.Prefix);
            }
        }
    }
}