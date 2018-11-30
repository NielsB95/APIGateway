using System.ComponentModel.DataAnnotations;

namespace APIGateway.Services.Entities
{
    public class Endpoint
    {
        [Required]
        public string Method { get; set; }

        [Required]
        public string Pathname { get; set; }

        public string Signature
        {
            get
            {
                return string.Format("{0}-{1}", Method, Pathname);
            }
        }
    }
}
