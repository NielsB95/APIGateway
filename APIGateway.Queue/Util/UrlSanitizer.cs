using System.Text.RegularExpressions;

namespace APIGateway.Queue.Util
{
    public static class UrlSanitizer
    {
        public static string Sanitize(string url)
        {
            return Regex.Replace(url, @"\d+", "{int}");
        }
    }
}
