using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace APIGateway.Logging
{
    public static class Register
    {
        public static IServiceCollection AddRequestLogging(this IServiceCollection services)
        {

            return services;
        }

        public static IApplicationBuilder AddRequestLogging(
    this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
