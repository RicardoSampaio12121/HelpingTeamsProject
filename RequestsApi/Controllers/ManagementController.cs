using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RequestsApi.Dtos;
using RequestsApi.Entities;
using RequestsApi.Repositories;

namespace RequestsApi.Controllers
{
    /// <summary>
    /// /management endpoint of the api
    /// This controls the functions that only people responsible for the shipping of the products can use
    /// </summary>
    [ApiController]
    [Route("management")]
    public class ManagementController : ControllerBase
    {
        private readonly IManagementRepository _repository;
     
        /// <summary>
        /// Constructor for the controller
        /// </summary>
        /// <param name="repository"></param>
        public ManagementController(IManagementRepository repository)
        {
            this._repository = repository;
        }
        
        /// <summary>
        /// /management/GetAvailableProducts endpoint
        /// This gets all the available products from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAvailableProducts")]
        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var output = (await _repository.GetProductsAsync()).Select(product => product.AsProductDto());
            return output;
        }

        [HttpGet("{productName}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(string productName)
        {
            var output = (await _repository.GetProductAsync(productName)).AsProductDto();
            return output;
        }
        
        [HttpPost("CreateProduct")]
        public async Task<ActionResult<ProductDto>> CreateProduct(Product product)
        {
            await _repository.CreateItem(product);
            var actionName = nameof(GetProductAsync);
            var routeValues = new {productName = product.Name};
            
            //T ODO: CreatedAtAction is throwing an error, it creates the product tho.
            return CreatedAtAction(actionName, routeValues, product.AsProductDto());
        }
    }
}