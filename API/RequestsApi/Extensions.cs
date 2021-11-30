using RequestsApi.Dtos;
using RequestsApi.Entities;

namespace RequestsApi
{
    /// <summary>
    /// This class has extensions to convert from and to DTOs
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Receives a Product object and returns a ProductDto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductDto AsProductDto(this Product product)
        {
            return new ProductDto(product.Name, product.Quantity, product.UnitPrice);
        }
        
        /// <summary>
        /// Gets a Product and returns a ReturnProductDto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ReturnProductDto AsReturnProductDto(this Product product)
        {
            return new ReturnProductDto(product.Id, product.Name, product.Quantity, product.UnitPrice);
        }

        /// <summary>
        /// Gets a TeamModel and returns a TeamDto
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static TeamDto AsTeamDto(this TeamModel team)
        {
            return new TeamDto(team.Id, team.Location);
        }

        /// <summary>
        /// Gets a TeamModel and returns a ReturnTeamDto
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static ReturnTeamDto AsReturnTeamDto(this TeamModel team)
        {
            return new ReturnTeamDto(team.Id, team.Location);
        }
       
        /// <summary>
        /// Gets a TeamMemberModel and returns a ReturnTeamMemberDto
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static ReturnTeamMemberDto AsReturnTeamMemberDto(this TeamMemberModel member)
        {
            return new ReturnTeamMemberDto(member.Id, member.Name, member.Surname, member.Team, member.Organization);
        }

        /// <summary>
        /// Gets a PendingRequestModel and returns a ReturnPendingRequestDto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ReturnPendingRequestDto AsReturnPendingRequestDto(this PendingRequestModel request)
        {
            return new ReturnPendingRequestDto(request.Id, request.TeamId, request.Date);
        }

        /// <summary>
        /// Gets a PendingRequestProductModel and return a ReturnPendingRequestProductDto
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ReturnPendingRequestProductDto AsReturnPendingRequestProductDto(this PendingRequestProductModel product)
        {
            return new ReturnPendingRequestProductDto(product.Id, product.productId, product.quantity, product.pendingRequestId);
        }

        /// <summary>
        /// Gets a IdPriceQuantityModel and returns a ReturnIdPriceQuantityDto
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static ReturnIdPriceQuantityDto AsReturnIdPriceQuantityDto(this IdPriceQuantityModel info)
        {
            return new ReturnIdPriceQuantityDto(info.id, info.price, info.quantity);
        }
        
        /// <summary>
        /// Gets a CompletedRequestModel and returns a ReturnCompletedRequestDto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ReturnCompletedRequestDto AsReturnCompletedRequestDto(this CompletedRequestModel request)
        {
            return new ReturnCompletedRequestDto(request.id, request.teamId, request.price, request.date, request.decision);
        }

        /// <summary>
        /// Gets a CompletedRequestProductModel and returns a ReturnCompletedRequestProducDto
        /// </summary>
        /// <param name="prod"></param>
        /// <returns></returns>
        public static ReturnCompletedRequestProductDto  AsReturnCompletedRequestProductDto(this CompletedRequestProductModel prod)
        {
            return new ReturnCompletedRequestProductDto(prod.id, prod.productId, prod.requestId);
        }
    }
}