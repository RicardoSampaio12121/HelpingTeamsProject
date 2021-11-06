using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Data.Connector
{
    public static class Connector
    {
        public static HttpClient ApiClient { get; set; }

        //TODO: dependency inversion nisto
        public static void InitializeClient()
        {
            ApiClient = new();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
        }
    }
}
