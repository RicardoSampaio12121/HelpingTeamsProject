/*
 * This file contains the definition of the methods that access the database tables related to requests
 */

using RequestsApi.Dtos;
using RequestsApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestsApi.Repositories
{
    public interface IRequestsRepository
    {
        Task<IEnumerable<CompletedRequestModel>> GetCompletedRequests();
        Task<IEnumerable<CompletedRequestModel>> GetCompletedRequests(int teamId);
        Task<IEnumerable<CompletedRequestProductModel>> GetCompletedRequestProducts(int requestId);
        Task HandleRequest(AcceptRequestDto info);
        Task HandleRequestProducts(List<int> ids);
        Task DeletePendingRequestProducts(int requestId);
        Task DeletePendingRequest(int requestId);
        Task CreateRequest(int teamId);
        Task AddProductsToRequest(List<MakeRequestDto> products);
        Task<IEnumerable<PendingRequestModel>> GetPendingRequestsByTeam(int teamId);
        Task<IEnumerable<PendingRequestProductModel>> GetPendingRequestProducts(int requestId);
        Task<IEnumerable<PendingRequestModel>> GetPendingRequests();
    }
}
