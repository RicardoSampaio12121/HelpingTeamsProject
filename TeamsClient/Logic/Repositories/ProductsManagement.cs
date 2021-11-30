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
        /// <summary>
        /// Gets all the available products
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<ProductModel>> GetAllAvailableProducts()
        {
            var output = await Products.CallHttpGetProducts("GetAvailableProducts");
            return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(output);
        }

        /// <summary>
        /// Gets the products related to a pending request
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<PendingRequestProductModel>> GetPendingRequestProducts(int requestId)
        {
            var output = await Products.CallHttpGetRequests($"GetPendingRequestProducts/{requestId}");
            return JsonConvert.DeserializeObject<IEnumerable<PendingRequestProductModel>>(output);
        }

        /// <summary>
        /// Gets the products related to a completed request
        /// </summary>
        /// <param name="reqId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<CompletedRequestProductModel>> GetCompletedRequestProducts(int reqId)
        {
            var output = await Products.CallHttpGetRequests($"GetCompletedRequestProducts/{reqId}");
            return JsonConvert.DeserializeObject<IEnumerable<CompletedRequestProductModel>>(output);
        }

        /// <summary>
        /// Gets the completed request of a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<CompletedRequestModel>> GetCompletedRequests(int teamId)
        {
            var output = await Products.CallHttpGetRequests($"GetCompletedRequests/{teamId}");
            return JsonConvert.DeserializeObject<IEnumerable<CompletedRequestModel>>(output);
        }

        /// <summary>
        /// Gets the pending requests of a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<PendingRequestModel>> GetPendingRequests(int teamId)
        {
            var output = await Products.CallHttpGetRequests($"GetPendingRequests/{teamId}");
            return JsonConvert.DeserializeObject<IEnumerable<PendingRequestModel>>(output);

        }

        /// <summary>
        /// Makes a request
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="basket"></param>
        /// <returns></returns>
        public static async Task MakeRequest(int teamId, List<ProductInBasket> basket)
        {
            string productsAsJson = JsonConvert.SerializeObject(basket); 
            await Products.CallHttpPostRequests($"MakeRequest/{teamId}", productsAsJson);
        }
    }
}
