using Microsoft.AspNetCore.Mvc;
using RequestsApi.Dtos;
using RequestsApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Controllers
{
    [ApiController]
    [Route("requests")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestsRepository _repository;

        public RequestsController(IRequestsRepository repo)
        {
            _repository = repo;
        }

        [HttpGet("GetCompletedRequests")]
        public async Task<IEnumerable<ReturnCompletedRequestDto>> GetCompletedRequests()
        {
            var output = (await _repository.GetCompletedRequests()).Select(request => request.AsReturnCompletedRequestDto());
            return output;
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

        [HttpPost("HandleRequest/{requestId}")]
        public async Task<ActionResult> AcceptRequest(int requestId, AcceptRequestDto info)
        {
            await _repository.HandleRequest(info);
            return Ok();
        }

        [HttpPost("MakeRequest/{teamId}")]
        public async Task<ActionResult> MakeRequest(int teamId, List<MakeRequestDto> products)
        {
            await _repository.CreateRequest(teamId);
            await _repository.AddProductsToRequest(products);

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
    }
}
