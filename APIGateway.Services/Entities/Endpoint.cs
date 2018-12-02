using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace APIGateway.Services.Entities
{
    public class Endpoint
    {
        [Required]
        public string Method { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Pathname { get; set; }

        [JsonIgnore]
        public string Signature
        {
            get
            {
                if (Microservice != null && !string.IsNullOrEmpty(Microservice.Prefix))
                {
                    return string.Format("{0}-{1}/{2}", Method, Microservice.Prefix, Pathname);
                }

                return string.Format("{0}-{1}", Method, Pathname);
            }
        }

        [JsonIgnore]
        public Microservice Microservice { get; internal set; }

        public string GatewayUrl
        {
            get
            {
                if (Microservice == null)
                    return this.Pathname;
                return string.Format("{0}/{1}", Microservice.GatewayBaseUrl, this.Pathname);
            }
        }

        public string ServiceUrl
        {
            get
            {
                if (Microservice == null)
                    return this.Pathname;
                return string.Format("{0}/{1}", Microservice.ServiceUrl, this.Pathname);
            }
        }
    }
}
