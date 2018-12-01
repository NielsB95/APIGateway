using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace APIGateway.Services.Entities
{
    public class Endpoint
    {
        [Required]
        public string Method { get; set; }

        [Required]
        public string Pathname { get; set; }

        [JsonIgnore]
        public string Signature
        {
            get
            {
                return string.Format("{0}-{1}", Method, Pathname);
            }
        }
    }
}
