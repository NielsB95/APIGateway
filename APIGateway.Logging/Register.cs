using System;
using Microsoft.Extensions.DependencyInjection;

namespace APIGateway.Logging
{
    public static class Register
    {
        public static IServiceCollection AddRequestLogging(this IServiceCollection services)
        {

            return services;
        }
    }
}
