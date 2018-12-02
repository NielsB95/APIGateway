using System;
using APIGateway.Services.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIGateway.Services.Tests
{
    [TestClass]
    public class EndpointTests
    {
        [TestMethod]
        public void EndpointSignatureWithoutMicroserviceTest()
        {
            var endpoint = new Endpoint()
            {
                Method = "GET",
                Pathname = "Authenticate"
            };

            Assert.AreEqual("GET-Authenticate", endpoint.Signature);
        }

        [TestMethod]
        public void EndpointSignatureWithMicroserviceTest()
        {
            var endpoint = new Endpoint()
            {
                Method = "GET",
                Pathname = "Authenticate",
                Microservice = new Microservice()
                {
                    Prefix = "Authentication"
                }
            };

            Assert.AreEqual("GET-Authentication/Authenticate", endpoint.Signature);
        }

        [TestMethod]
        public void EndpointGatewayUrlTest()
        {
            var endpoint = new Endpoint()
            {
                Method = "GET",
                Pathname = "Authenticate",
                Microservice = new Microservice()
                {
                    Prefix = "Authentication"
                }
            };

            Assert.IsTrue(endpoint.GatewayUrl.EndsWith("Authentication/Authenticate", StringComparison.Ordinal));
        }

        [TestMethod]
        public void EndpointServiceUrlTest()
        {
            var endpoint = new Endpoint()
            {
                Method = "GET",
                Pathname = "Authenticate",
                Microservice = new Microservice()
                {
                    Prefix = "Authentication",
                    DomainName = "http://localhost",
                    Port = 80
                }
            };

            Assert.AreEqual("http://localhost:80/Authenticate", endpoint.ServiceUrl);
        }

        [TestMethod]
        public void EndpointGatewayUrlWithoutMicroserviceTest()
        {
            var endpoint = new Endpoint()
            {
                Method = "GET",
                Pathname = "Authenticate"
            };

            Assert.AreEqual("Authenticate", endpoint.GatewayUrl);
        }

        [TestMethod]
        public void EndpointServiceUrlWithoutMicroserviceTest()
        {
            var endpoint = new Endpoint()
            {
                Method = "GET",
                Pathname = "Authenticate"
            };

            Assert.AreEqual("Authenticate", endpoint.ServiceUrl);
        }
    }
}
