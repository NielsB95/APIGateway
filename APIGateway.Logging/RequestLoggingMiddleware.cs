using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace APIGateway.Logging
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            // Do something before

            await _next(context);

            // Maybe also something afterwards?
        }
    }
}
