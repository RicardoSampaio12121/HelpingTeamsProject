using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.RepositoryApi;
using Data.Entities;
using Logic.Entities;
using Newtonsoft.Json;

namespace Logic.Repositories
{
    public static class ProductsManagement
    {
        public static async Task<List<Entities.ProductModel>> GetProducts()
        {
            var products = await Products.GetProducts();
            return JsonConvert.DeserializeObject<List<Entities.ProductModel>>(products);
        }

        public static async Task<Entities.ProductModel> GetProduct(string name)
        {
            var product = await Products.GetProducts(name);
            return JsonConvert.DeserializeObject<Entities.ProductModel>(product);
        }

        public static async Task CreateProduct(Entities.ProductModel product)
        {
            var productAsJson = JsonConvert.SerializeObject(product);
            await Products.CreateProduct(productAsJson);
        }
    }
}