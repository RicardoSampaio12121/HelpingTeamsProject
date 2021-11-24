using Microsoft.AspNetCore.Mvc;
using RequestsApi.Dtos;
using RequestsApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//TODO: Add a price field to the available_products in the database, this means we also have to change the DTO's and possibly the entities that are used to stores products

namespace RequestsApi.Controllers
{
    /// <summary>
    /// /management endpoint of the api
    /// This controls the functions that only people responsible for the shipping of the products can use
    /// </summary>
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _repository;
     
        /// <summary>
        /// Constructor for the controller
        /// </summary>
        /// <param name="repository"></param>
        public ProductsController(IProductsRepository repository)
        {
            this._repository = repository;
        }
        
        /// <summary>
        /// /management/GetAvailableProducts endpoint
        /// This gets all the available products from the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAvailableProducts")]
        public async Task<IEnumerable<ReturnProductDto>> GetProductsAsync()
        {
            var output = (await _repository.GetProductsAsync()).Select(product => product.AsReturnProductDto());
            return output;
        }
        
        /// <summary>
        /// Gets the information of a product from the database by it's id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>
        /// Returns a ReturnProductDto
        /// </returns>
        [HttpGet("GetAvailableProduct/{productId}")]
        public async Task<ActionResult<ReturnProductDto>> GetProduct(int productId)
        {
            var output = (await _repository.GatherProductAsync(productId)).AsReturnProductDto();
            return output;
        }

        /// <summary>
        /// Gets the information of a product from the database by it's name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns>
        /// Returns a ReturnProductDto
        /// </returns>
        [HttpGet("GetAvailableProductByName/{productName}")]
        public async Task<ActionResult<ReturnProductDto>> GetProductByName(string productName)
        {   
            var output = (await _repository.GatherProductByNameAsync(productName)).AsReturnProductDto();
            return output;
        }

        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("CreateProduct")]
        public async Task<ActionResult<CreateProductDto>> CreateProduct(CreateProductDto product)
        {
            await _repository.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductByName), new { productName = product.Name }, product);
        }

        /// <summary>
        /// Adds stock to a product in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantityToAdd"></param>
        /// <returns></returns>
        [HttpPut("AddStock/{id}")]
        public async Task<ActionResult> AddStock(int id, int quantityToAdd)
        {
            await _repository.AddStock(id, quantityToAdd);
            return NoContent();
        }
    }
}