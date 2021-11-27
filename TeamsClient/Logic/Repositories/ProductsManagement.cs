using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.RepositoryApi;
using Logic.Entities;
using Newtonsoft.Json;

namespace Logic.Repositories
{
    public class ProductsManagement
    {
        public static async Task<IEnumerable<ProductModel>> GetAllAvailableProducts()
        {
            var output = await Products.GetAllAvailableProducts();
            return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(output);
        }

        public static async Task<IEnumerable<PendingRequestProductModel>> GetPendingRequestProducts(int requestId)
        {
            var output = await Products.GetPendingRequestProducts(requestId);
            return JsonConvert.DeserializeObject<IEnumerable<PendingRequestProductModel>>(output);
        }

        public static async Task<IEnumerable<PendingRequestModel>> GetPendingRequests(int teamId)
        {
            var output = await Products.GetPendingRequests(teamId);
            return JsonConvert.DeserializeObject<IEnumerable<PendingRequestModel>>(output);

        }

        public static async Task MakeRequest(int teamId, List<ProductInBasket> basket)
        {
            string productsAsJson = JsonConvert.SerializeObject(basket); 
            await Products.MakeRequest(teamId, productsAsJson);
        }
    }
}
