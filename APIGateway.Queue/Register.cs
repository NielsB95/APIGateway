using System;
using Microsoft.Extensions.DependencyInjection;

namespace APIGateway.Queue
{
    public static class Register
    {
        public static IServiceCollection AddRequestQueue(this IServiceCollection services)
        {

            return services;
        }
    }
}