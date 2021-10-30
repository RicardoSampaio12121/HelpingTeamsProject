using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RequestsApi.Entities;

namespace RequestsApi.Repositories
{
    public interface IManagementRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}