namespace APIGateway.Services.Entities
{
    public class Endpoint
    {
        public string Method { get; set; }
        public string Pathname { get; set; }

        public string GetSignature()
        {
            return string.Format("{0}-{1}", Method, Pathname);
        }
    }
}
