using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.RepositoryApi;
using Data.Entities;

namespace Logic.Repositories
{
    public static class ProductsManagement
    {
        public static async Task<List<ProductModel>> GetProducts()
        {
            var products = await Products.GetAllProducts();
            return products;
        }
    }
}