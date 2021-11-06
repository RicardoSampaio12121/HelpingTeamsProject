using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.RepositoryApi
{
    public static class Products
    {
        public static async Task<List<ProductModel>> GetAllProducts()
        {
            string url = "https://localhost:44358/management/GetAvailableProducts";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<ProductModel> products = await response.Content.ReadAsAsync<List<ProductModel>>();

                    return products;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
