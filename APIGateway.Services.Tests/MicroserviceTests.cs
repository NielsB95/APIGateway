using System;
using APIGateway.Services.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIGateway.Services.Tests
{
    [TestClass]
    public class MicroserviceTests
    {
        [TestMethod]
        public void ServiceUrlWithoutPortTest()
        {
            var service = new Microservice()
            {
                DomainName = "http://localhost"
            };

            Assert.AreEqual("http://localhost", service.ServiceUrl);
        }

        [TestMethod]
        public void ServiceUrlWithPortTest()
        {
            var service = new Microservice()
            {
                DomainName = "http://localhost",
                Port = 80
            };

            Assert.AreEqual("http://localhost:80", service.ServiceUrl);
        }

        [TestMethod]
        public void GatewayBaseUrlTest()
        {
            var service = new Microservice()
            {
                Prefix = "Authentication"
            };

            Assert.IsTrue(service.GatewayBaseUrl.EndsWith("Authentication", StringComparison.Ordinal));
        }
    }
}
