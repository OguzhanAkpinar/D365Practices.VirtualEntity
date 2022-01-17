using System.IO;
using System.Net;

namespace VirtualEntityPlugins.Business.Helpers
{
    public static class ODataHelper
    {
        public static string Call(string url, string method)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = method;
            request.Timeout = 500000;

            var response = (HttpWebResponse)request.GetResponse();
            string content = string.Empty;
            using (var stream = response.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();
                }
            }
            return content;
        }
    }
}
