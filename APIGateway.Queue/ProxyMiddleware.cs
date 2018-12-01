using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using APIGateway.Queue.Entities;
using APIGateway.Queue.RequestQueue;
using APIGateway.Services.ServiceRegistration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;

namespace APIGateway.Queue
{
    public class ProxyMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IRequestQueueManager queueManager;
        private readonly IMicroserviceManager serviceManager;

        public ProxyMiddleware(RequestDelegate next, IRequestQueueManager queueManager, IMicroserviceManager serviceManager)
        {
            this.next = next;
            this.queueManager = queueManager;
            this.serviceManager = serviceManager;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path;
            var method = context.Request.Method;
            var microservice = serviceManager.Match(method, path);

            // Let one of the microservices handle the request if we can find
            // a match based on the path.
            if (microservice != null)
            {
                // Create a ServiceRequest
                var serviceRequest = new ServiceRequest(context, microservice.DomainName, microservice.Port);

                // Add to queue
                //this.queueManager.Enqueue(serviceRequest);

                await serviceRequest.Process();
            }

            await next(context);
        }
    }
}
