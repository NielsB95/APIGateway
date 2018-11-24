using System;
using APIGateway.Services.Entities;
using APIGateway.Services.ServiceRegistration;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Services.Controllers
{
    [ApiController]
    [Route("Service"))]
    public class ServiceController : ControllerBase
    {
        private IMicroserviceManager serviceManager;

        public ServiceController(IMicroserviceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost]
        public ActionResult Add(Microservice service)
        {
            var result = this.serviceManager.Register(service);

            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}
