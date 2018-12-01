using APIGateway.Queue.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APIGateway.Queue.Tests.Util
{
    [TestClass]
    public class UrlSanitizerTests
    {
        [TestMethod]
        public void UrlSanitizerTest()
        {
            var url = UrlSanitizer.Sanitize("http://google.com/10/");
            Assert.AreEqual("http://google.com/{int}/", url);

            var url2 = UrlSanitizer.Sanitize("1");
            Assert.AreEqual("{int}", url2);

            var url3 = UrlSanitizer.Sanitize("google.com/10/hello/40");
            Assert.AreEqual("google.com/{int}/hello/{int}", url3);
        }
    }
}
