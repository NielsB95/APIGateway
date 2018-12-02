using System;
using System.Collections.Generic;
using APIGateway.Services.Entities;
using APIGateway.Services.ServiceRegistration;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace APIGateway.Pages.Models
{
    public class IndexModel : PageModel
    {
        private IMicroserviceManager manager;

        public IList<Endpoint> Endpoints
        {
            get { return this.manager.GetEndpoints(); }
        }

        public IList<Microservice> Microservices
        {
            get { return this.manager.RegisteredServices(); }
        }

        public IndexModel(IMicroserviceManager microserviceManager)
        {
            this.manager = microserviceManager;
        }
    }
}
