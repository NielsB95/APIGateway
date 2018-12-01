using System;
using APIGateway.Queue.RequestQueue;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace APIGateway.Queue
{
    public static class Register
    {
        public static IServiceCollection AddRequestQueue(this IServiceCollection services)
        {
            services.AddSingleton<IRequestQueueManager>(new RequestQueueManager());

            return services;
        }

        public static IApplicationBuilder AddRequestQueue(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProxyMiddleware>();
        }
    }
}