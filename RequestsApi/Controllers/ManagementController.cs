using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RequestsApi.Dtos;
using RequestsApi.Entities;
using RequestsApi.Repositories;
using Newtonsoft.Json;
using System.Net.Http;

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
            //return JsonConvert.SerializeObject(output);
            return output;
        }
        
        [HttpGet("GetAvailableProduct/{productId}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int productId)
        {
            var output = (await _repository.GatherProductAsync(productId)).AsProductDto();
            return output;
        }

        [HttpGet("GetAvailableProductByName/{productName}")]
        public async Task<ActionResult<ProductDto>> GetProductByName(string productName)
        {   
            var output = (await _repository.GatherProductByNameAsync(productName)).AsProductDto();
            return output;
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult<CreateProductDto>> CreateProduct(CreateProductDto product)
        {

            await _repository.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductByName), new { productName = product.Name }, product);
        }

        [HttpPut("AddStock/{id}")]
        public async Task<ActionResult<ProductDto>> AddStock(int id, int quantityToAdd)
        {
            await _repository.AddStock(id, quantityToAdd);
            return NoContent();

        }
    }
}