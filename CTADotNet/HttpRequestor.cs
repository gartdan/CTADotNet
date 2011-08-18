using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace CTADotNet
{
    public class HttpRequestor
    {
        public string ExecuteGet(string url, NetworkCredential credentials = null)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);
            request.Method = "GET";
            if (credentials != null)
                request.Credentials = credentials;
            var response = (HttpWebResponse) request.GetResponse();
            string result = string.Empty;
            using(Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                reader.Close();
            }
            return result;

        }
    }
}
