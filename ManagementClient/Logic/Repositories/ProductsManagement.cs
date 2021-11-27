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

        public static async Task<IEnumerable<PendingRequestModel>> GetPendingRequests()
        {
            var pendingRequests = await Products.GetPendingRequests();
            return JsonConvert.DeserializeObject<IEnumerable<PendingRequestModel>>(pendingRequests);
        }

        public static async Task<IEnumerable<PendingRequestProductModel>> GetPendingRequestProducts(int reqId)
        {
            var products = await Products.GetPendingRequestProducts(reqId);
            return JsonConvert.DeserializeObject<IEnumerable<PendingRequestProductModel>>(products);
        }

        public static async Task<Entities.ProductModel> GetProduct(string name)
        {
            var product = await Products.GetProducts(name);
            return JsonConvert.DeserializeObject<Entities.ProductModel>(product);
        }

        public static async Task AcceptRequest(int reqId, int teamId)
        {
            try
            {
                //1º -> Recolher preço dos produtos, id dos produtos e quantidade de cada produto encomendada 
                var infoAsJson = await Products.GetIdQuantityPrice(reqId);
                var info = JsonConvert.DeserializeObject<IEnumerable<ToAcceptRequestInfo>>(infoAsJson);

                float price = 0;

                foreach (var i in info)
                {
                    price += i.propQuantity * i.prodPrice;
                }

                AcceptRequest req = new()
                {
                    teamId = teamId,
                    price = price,
                    decision = "accepted"
                };

                //2º -> Serielizar a informação para json
                string json = JsonConvert.SerializeObject(req);

                //3º -> Adicionar à tabela de requests como aceite
                await Products.AcceptRequest(reqId, json);

                //4º -> Adicionar os produtos a uma tabela à parte
                List<int> prodIds = new();

                foreach (var i in info)
                {
                    prodIds.Add(i.propId);
                }

                string idsAsJson = JsonConvert.SerializeObject(prodIds);
                await Products.AcceptRequestProducts(idsAsJson);

                //5º -> Eliminar da tabela pending_requests_products
                await Products.DeletePendingRequestProducts(reqId);

                //6º -> Eliminar da tabela pending_requests
                await Products.DeletePendingReques(reqId);

                //7º -> Atualizar quantidade na tabela available_products

                List<UpdateAvailableProductsQuantityModel> toUpdate = new();

                foreach (var i in info)
                {
                    toUpdate.Add(new UpdateAvailableProductsQuantityModel()
                    {
                        prodId = i.propId,
                        quantityToTake = i.propQuantity
                    });
                }

                string toUpdateAsJson = JsonConvert.SerializeObject(toUpdate);
                await Products.UpdateProductsQuantity(toUpdateAsJson);
            
            }catch(Exception ex)
            {
                throw;
            }
        }

        public static async Task CreateProduct(Entities.ProductModel product)
        {
            var productAsJson = JsonConvert.SerializeObject(product);
            await Products.CreateProduct(productAsJson);
        }

        public static async Task AddStock(Entities.ProductModel product)
        {
            //var productAsJson = JsonConvert.SerializeObject(product);
            await Products.AddStock(product.LogicProductAsDataProduct());
        }
    }
}