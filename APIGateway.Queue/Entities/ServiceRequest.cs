using System.Net.Http;
using System.Threading.Tasks;
using APIGateway.Queue.Util;
using Microsoft.AspNetCore.Http;

namespace APIGateway.Queue.Entities
{
    public class ServiceRequest
    {
        private HttpContext context;
        private string microserviceAddress;
        private int microservicePort;

        public ServiceRequest(HttpContext context, string microserviceAddress, int microservicePort)
        {
            this.context = context;
            this.microserviceAddress = microserviceAddress;
            this.microservicePort = microservicePort;
        }

        public async Task Process()
        {
            string newUrl = this.ComposeNewUrl();
            HttpResponseMessage response = null;
            switch (this.context.Request.Method)
            {
                case "GET":
                    response = await RequestProcessor.GET(newUrl, context);
                    break;
                case "POST":
                    response = await RequestProcessor.POST(newUrl, context);
                    break;
            }

            // Copy the response from the proxy request.
            await response.Content.CopyToAsync(context.Response.Body);
        }

        private string ComposeNewUrl()
        {
            return "http://google.com/";
        }
    }
}
