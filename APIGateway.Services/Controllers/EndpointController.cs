using System;
using System.Collections.Generic;
using APIGateway.Services.Entities;
using APIGateway.Services.ServiceRegistration;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Services.Controllers
{
    [ApiController]
    [Route("Endpoints")]
    public class EndpointController : ControllerBase
    {
        IMicroserviceManager microserviceManager;

        public EndpointController(IMicroserviceManager microserviceManager)
        {
            this.microserviceManager = microserviceManager;
        }


        [HttpGet]
        public ActionResult<List<Endpoint>> GetEndpoints(Guid serviceID)
        {
            return Ok(microserviceManager.GetEndpoints(serviceID));
        }
    }
}
