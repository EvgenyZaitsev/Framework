using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Framework.Utility.IPLocator
{
    public class IPLocator
    {
        public string IP { get; set; }
        private static string protocol = "http";
        private static string hostName = "ip-api.com";
        private static string pathToResource = "json/{ip}";
        private static string HttpMethod = "GET";

        public IPLocator(string ip)
        {
            this.IP = ip;
        }

        public string GetCityByIP()
        {
            string pathToResourceModified = pathToResource.Replace("{ip}", this.IP);
            string requestUri = string.Format("{0}://{1}/{2}", protocol, hostName, pathToResourceModified);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
            request.Method = HttpMethod;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string content = string.Empty;

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                content = reader.ReadToEnd();
            }

            IpData data = JsonConvert.DeserializeObject<IpData>(content);
            return data.City;
        }
        private class IpData
        {
            [JsonProperty("city", Required = Required.Always)]
            public string City { get; set; }

            [JsonProperty("country", Required = Required.Always)]
            public string Country { get; set; }

            [JsonProperty("timezone", Required = Required.Always)]
            public string TimeZone { get; set; }
        }
    }

    
}
