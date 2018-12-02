using System;
using System.Net;
using System.Net.Sockets;

namespace APIGateway.Services.Util
{
    public static class UrlComposer
    {
        private static string ipAddress;

        internal static string getCurrentIP()
        {
            // Check if we have already cached the ipAddress.
            if (string.IsNullOrEmpty(ipAddress))
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipAddress = ip.ToString();
                        return ipAddress;
                    }
                }
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }

            return ipAddress;
        }

        internal static int getCurrentPort()
        {
            return 5001;
        }


        public static string ComposeGatewayBaseUrl(string pathnamePrefix)
        {
            var ip = getCurrentIP();
            var port = getCurrentPort();
            var baseUrl = string.Format("{0}:{1}", ip, port);

            // Return baseUrl if we have no pathnamePrefix.
            if (string.IsNullOrEmpty(pathnamePrefix))
                return baseUrl;

            return string.Format("http://{0}/{1}", baseUrl, pathnamePrefix);
        }
    }
}
