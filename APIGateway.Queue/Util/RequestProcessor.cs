using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace APIGateway.Queue.Util
{
    public static class RequestProcessor
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<HttpResponseMessage> GET(string newUrl, HttpContext context)
        {
            var url = new Uri(newUrl);
            var response = await client.GetAsync(url);

            return response;
        }

        public static async Task<HttpResponseMessage> POST(string newUrl, HttpContext context)
        {
            var url = new Uri(newUrl);
            var content = new StreamContent(context.Request.Body);
            var response = await client.PostAsync(url, content);

            return response;
        }
    }
}
