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
        private const string defaultUrl = "https://localhost:44358/products";
        public static async Task<string> GetAllAvailableProducts()
        {
            string url = $"{defaultUrl}/GetAvailableProducts";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<string> GetPendingRequestProducts(int requestId)
        {
            string url = $"{defaultUrl}/GetPendingRequestProducts/{requestId}";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<string> GetCompletedRequestProducts(int reqId)
        {
            string url = $"{defaultUrl}/GetCompletedRequestProducts/{reqId}";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<string> GetCompletedRequests(int teamId)
        {
            string url = $"{defaultUrl}/GetCompletedRequests/{teamId}";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<string> GetPendingRequests(int teamId)
        {
            string url = $"{defaultUrl}/GetPendingRequests/{teamId}";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task MakeRequest(int teamId, string productsAsJson)
        {
            string url = $"{defaultUrl}/MakeRequest/{teamId}";
            var stringContent = new StringContent(productsAsJson, Encoding.UTF8, "application/json");
            await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }
    }
}
