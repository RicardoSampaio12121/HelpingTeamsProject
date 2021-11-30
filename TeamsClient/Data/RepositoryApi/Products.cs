using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Data.RepositoryApi
{
    public static class Products
    {
        private const string defaultProductsUrl = "https://localhost:44358/products";
        private const string defaultRequestsUrl = "https://localhost:44358/requests";

        /// <summary>
        /// Sends an http Get to the specified endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<string> CallHttpGetProducts(string endpoint)
        {
            string url = $"{defaultProductsUrl}/{endpoint}";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

        /// <summary>
        /// Sends an http Get to the specified endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<string> CallHttpGetRequests(string endpoint)
        {
            string url = $"{defaultRequestsUrl}/{endpoint}";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

        /// <summary>
        /// Sends an http post request to the specified endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="contentAsJson"></param>
        /// <returns></returns>
        public static async Task CallHttpPostRequests(string endpoint, string contentAsJson)
        {
            string url = $"{defaultRequestsUrl}/{endpoint}";
            var stringContent = new StringContent(contentAsJson, Encoding.UTF8, "application/json");
            await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }
    }
}
