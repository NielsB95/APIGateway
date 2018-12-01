using System.Net.Http;
using System.Threading.Tasks;
using APIGateway.Queue.Util;
using APIGateway.Services.Entities;
using Microsoft.AspNetCore.Http;

namespace APIGateway.Queue.Entities
{
    public class ServiceRequest
    {
        private HttpContext context;
        private Microservice microservice;

        public ServiceRequest(HttpContext context, Microservice microservice)
        {
            this.context = context;
            this.microservice = microservice;
        }

        /// <summary>
        /// Process this request.
        /// </summary>
        /// <returns>The process.</returns>
        public async Task Process()
        {
            string composedUrl = this.ComposeUrl();
            HttpResponseMessage response = null;
            switch (this.context.Request.Method)
            {
                case "GET":
                    response = await RequestProcessor.GET(composedUrl, context);
                    break;
                case "POST":
                    response = await RequestProcessor.POST(composedUrl, context);
                    break;
            }

            // Copy the response from the proxied request.
            context.Response.StatusCode = (int)response.StatusCode;
            await response.Content.CopyToAsync(context.Response.Body);
        }

        /// <summary>
        /// Composes the URL.
        /// </summary>
        /// <returns>The URL.</returns>
        private string ComposeUrl()
        {
            return this.microservice.Url;
        }
    }
}
