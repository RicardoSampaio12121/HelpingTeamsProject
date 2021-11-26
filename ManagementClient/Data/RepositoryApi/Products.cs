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
            string url = $"{standardUrl}/CreateProduct";

            var stringContent = new StringContent(productAsJson, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }

        public static async Task AddStock(ProductModel product)
        {
            string url = $"{standardUrl}/AddStock/{product.Id}";

            //var stringContent = new StringContent(productAsJson, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PutAsJsonAsync(url, product);
        }
    }
}
