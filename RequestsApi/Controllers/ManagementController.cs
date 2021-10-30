using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RequestsApi.Dtos;
using RequestsApi.Entities;
using RequestsApi.Repositories;

namespace RequestsApi.Controllers
{
    [ApiController]
    [Route("management")]
    public class ManagementController : ControllerBase
    {
        private readonly IManagementRepository _repository;
        
        public ManagementController(IManagementRepository repository)
        {
            this._repository = repository;
        }
        
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = (await _repository.GetProductsAsync());
            return products;
        }
    }
}