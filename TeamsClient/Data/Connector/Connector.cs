using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Data.Connector
{
    public static class Connector
    {
        public static HttpClient ApiClient { get; set; }

        /// <summary>
        /// Connects to the api
        /// </summary>
        public static void InitializeClient()
        {
            ApiClient = new();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
        }
    }
}
