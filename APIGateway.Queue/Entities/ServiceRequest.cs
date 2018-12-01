using System.Net.Http;
using APIGateway.Queue.Util;
using Microsoft.AspNetCore.Http;

namespace APIGateway.Queue.Entities
{
    public class ServiceRequest
    {
        private HttpContext context;
        private string microserviceAddress;
        private int microservicePort;
        private RequestDelegate respond;

        public ServiceRequest(HttpContext context, string microserviceAddress, int microservicePort, RequestDelegate respond)
        {
            this.context = context;
            this.microserviceAddress = microserviceAddress;
            this.microservicePort = microservicePort;
            this.respond = respond;
        }

        public async void Process()
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
            context.Response.Body = await response.Content.ReadAsStreamAsync();

            await respond(context);
        }

        private string ComposeNewUrl()
        {
            return "http://google.com/";
        }
    }
}
