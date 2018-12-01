using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace APIGateway.Logging
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string file = Path.Combine(Directory.GetCurrentDirectory(), "Log.log");

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            // Do something before

            await next(context);

            // Write the request to a file.
            using (StreamWriter writer = File.AppendText(file))
            {
                // Compose the log.
                var log = string.Format("{0} {1}\t{2}{3}", DateTime.Now, context.Request.Method, context.Request.Host, context.Request.Path);

                // Append the query if there is one.
                var query = context.Request.QueryString.ToString();
                if (!String.IsNullOrEmpty(query))
                    log = string.Format("{0}{1}", log, query);

                // Write to 
                writer.WriteLine(log);
            }
        }
    }
}
