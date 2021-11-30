/*
 * This file contains the controller for the products
 */
using Microsoft.AspNetCore.Mvc;
using RequestsApi.Dtos;
using RequestsApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// Get the Id, price and quantity of something that I don't remember
        /// </summary>
        /// <param name="reqId"></param>
        /// <returns></returns>
        [HttpGet("GetIdPriceQuantity/{reqId}")]
        public async Task<IEnumerable<ReturnIdPriceQuantityDto>> GetPendingRequests(int reqId)
        {
            var output = (await _repository.GetIdPriceQuantity(reqId)).Select(request => request.AsReturnIdPriceQuantityDto());
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
        public async Task<ActionResult> AddStock(int id, UpdateProductQuantityDto quantity)
        {
            await _repository.AddStock(id, quantity.quantityToAdd);
            return NoContent();
        }

        /// <summary>
        /// Update the stock of a product
        /// </summary>
        /// <param name="toUpdate"></param>
        /// <returns></returns>
        [HttpPut("UpdateProductsQuantity")]
        public async Task<ActionResult> UpdateProductsQuantity(List<UpdateProductsQuantityDto> toUpdate)
        {
            await _repository.UpdateProductsQuantity(toUpdate);
            return NoContent();
        }
    }
}