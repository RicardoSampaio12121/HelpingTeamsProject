using System.Collections.Generic;
using System.Threading.Tasks;
using RequestsApi.Dtos;
using RequestsApi.Entities;

namespace RequestsApi.Repositories
{
    /// <summary>
    /// Interface for the repository to manage some function that operate in the requests database that only the
    /// people responsible for the shipping of products can access
    /// </summary>
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task CreateProduct(CreateProductDto product);
        Task<Product> GatherProductAsync(int productId);
        Task<Product> GatherProductByNameAsync(string productName);
        Task AddStock(int id, int quantity);    
        Task<IEnumerable<IdPriceQuantityModel>> GetIdPriceQuantity(int reqId);   
        Task UpdateProductsQuantity(List<UpdateProductsQuantityDto> toUpdate);
    }
}