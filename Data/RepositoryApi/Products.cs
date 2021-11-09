using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Connector;

namespace Data.RepositoryApi
{
    public static class Products
    {
        public static async Task<string> GetProducts(string name = "")
        {
            string url;
            if (name == "")
            {
                url = "https://localhost:44358/management/GetAvailableProducts";
            }
            else
            {
                url = $"https://localhost:44358/management/GetAvailableProduct/{name}";
            }

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<string>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task CreateProduct(string productAsJson)
        {
            string url = "https://localhost:44358/management/CreateProduct";

            var stringContent = new StringContent(productAsJson, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }
    }
}
