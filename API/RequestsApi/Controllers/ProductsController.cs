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

        [HttpPost("MakeRequest/{teamId}")]
        public async Task<ActionResult> MakeRequest(int teamId, List<MakeRequestDto> products)
        {
            await _repository.CreateRequest(teamId);
            await _repository.AddProductsToRequest(products);

            //TODO: Return something acording to the standards
            return Ok();
        }

        [HttpGet("GetPendingRequests/{teamId}")]
        public async Task<IEnumerable<ReturnPendingRequestDto>> GetPendingRequestsByTeam(int teamId)
        {
            var output = (await _repository.GetPendingRequestsByTeam(teamId)).Select(request => request.AsReturnPendingRequestDto());
            return output;
        }

        [HttpGet("GetPendingRequestProducts/{requestId}")]
        public async Task<IEnumerable<ReturnPendingRequestProductDto>> GetPendingRequestProducts(int requestId)
        {
            var output = (await _repository.GetPendingRequestProducts(requestId)).Select(product => product.AsReturnPendingRequestProductDto());
            return output;
        }

        [HttpGet("GetPendingRequests")]
        public async Task<IEnumerable<ReturnPendingRequestDto>> GetPendingRequests()
        {
            var output = (await _repository.GetPendingRequests()).Select(request => request.AsReturnPendingRequestDto());
            return output;
        }

        [HttpGet("GetIdPriceQuantity/{reqId}")]
        public async Task<IEnumerable<ReturnIdPriceQuantityDto>> GetPendingRequests(int reqId)
        {
            var output = (await _repository.GetIdPriceQuantity(reqId)).Select(request => request.AsReturnIdPriceQuantityDto());
            return output;
        }

        [HttpPost("HandleRequest/{requestId}")]
        public async Task<ActionResult> AcceptRequest(int requestId, AcceptRequestDto info)
        {
            await _repository.HandleRequest(info);
            return Ok();
        }

        [HttpPost("HandleRequestProducts")]
        public async Task<ActionResult> HandleRequestProducts(List<int> ids)
        {
            await _repository.HandleRequestProducts(ids);
            return Ok();
        }

        [HttpDelete("DeletePendingRequestProducts/{requestId}")]
        public async Task<ActionResult> DeletePendingRequestProducts(int requestId)
        {
            await _repository.DeletePendingRequestProducts(requestId);
            return NoContent();
        }

        [HttpDelete("DeletePendingRequest/{requestId}")]
        public async Task<ActionResult> DeletePendingRequest(int requestId)
        {
            await _repository.DeletePendingRequest(requestId);
            return NoContent();
        }

        [HttpPut("UpdateProductsQuantity")]
        public async Task<ActionResult> UpdateProductsQuantity(List<UpdateProductsQuantityDto> toUpdate)
        {
            await _repository.UpdateProductsQuantity(toUpdate);
            return NoContent();
        }

        [HttpGet("GetCompletedRequests/{teamId}")]
        public async Task<IEnumerable<ReturnCompletedRequestDto>> GetCompletedRequests(int teamId)
        {
            var output = (await _repository.GetCompletedRequests(teamId)).Select(request => request.AsReturnCompletedRequestDto());
            return output;
        }

        [HttpGet("GetCompletedRequestProducts/{requestId}")]
        public async Task<IEnumerable<ReturnCompletedRequestProductDto>> GetCompletedRequestProducts(int requestId)
        {
            var output = (await _repository.GetCompletedRequestProducts(requestId)).Select(request => request.AsReturnCompletedRequestProductDto());
            return output;
        }
    }
}