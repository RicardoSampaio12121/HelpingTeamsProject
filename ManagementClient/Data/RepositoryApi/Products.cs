using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Connector;
using Newtonsoft.Json;

namespace Data.RepositoryApi
{
    public static class Products
    {
        private const string standardUrl = "https://localhost:44358/products";

        public static async Task<string> GetProducts(string name = "")
        {
            string url;
            if (name == "")
            {
                url = $"{standardUrl}/GetAvailableProducts";
            }
            else
            {
                url = $"{standardUrl}/GetAvailableProduct/{name}";
            }

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<string> GetPendingRequestProducts(int reqId)
        {
            string url = $"{standardUrl}/GetPendingRequestProducts/{reqId}";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<string> GetIdQuantityPrice(int reqId)
        {
            string url = $"{standardUrl}/GetIdPriceQuantity/{reqId}";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task HandleRequest(int requestId, string info)
        {
            string url = $"{standardUrl}/HandleRequest/{requestId}";

            var stringContent = new StringContent(info, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }

        public static async Task HandleRequestProducts(string prodIds)
        {
            string url = $"{standardUrl}/HandleRequestProducts";

            var stringContent = new StringContent(prodIds, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }

        public static async Task DeletePendingReques(int reqId)
        {
            string url = $"{standardUrl}/DeletePendingRequest/{reqId}";
            await Connector.Connector.ApiClient.DeleteAsync(url);
        }

        public static async Task DeletePendingRequestProducts(int reqId)
        {
            string url = $"{standardUrl}/DeletePendingRequestProducts/{reqId}";
            await Connector.Connector.ApiClient.DeleteAsync(url);
        }

        public static async Task UpdateProductsQuantity(string toUpdateAsJson)
        {
            string url = $"{standardUrl}/UpdateProductsQuantity";
            
            var stringContent = new StringContent(toUpdateAsJson, Encoding.UTF8, "application/json");
            await Connector.Connector.ApiClient.PutAsync(url, stringContent);
        }

        public static async Task<string> GetPendingRequests()
        {
            string url = $"{standardUrl}/GetPendingRequests";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task CreateProduct(string productAsJson)
        {
            string url = $"{standardUrl}/CreateProduct";

            var stringContent = new StringContent(productAsJson, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }

        public static async Task AddStock(int prodId, string json)
        {
            string url = $"{standardUrl}/AddStock/{prodId}";

            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PutAsync(url, stringContent);
        }
    }
}
