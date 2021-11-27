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

        public static ReturnProductDto AsReturnProductDto(this Product product)
        {
            return new ReturnProductDto(product.Id, product.Name, product.Quantity, product.UnitPrice);
        }

        public static TeamDto AsTeamDto(this TeamModel team)
        {
            return new TeamDto(team.Id, team.Location);
        }

        public static ReturnTeamDto AsReturnTeamDto(this TeamModel team)
        {
            return new ReturnTeamDto(team.Id, team.Location);
        }

        //public static TeamMemberDto AsReturnMemberDto(this TeamMemberModel member)
        //{
        //    return new TeamMemberDto(member.Id, member.Name, member.Surname, member.Team, member.Organization);
        //}

        public static ReturnTeamMemberDto AsReturnTeamMemberDto(this TeamMemberModel member)
        {
            return new ReturnTeamMemberDto(member.Id, member.Name, member.Surname, member.Team, member.Organization);
        }

        public static ReturnPendingRequestDto AsReturnPendingRequestDto(this PendingRequestModel request)
        {
            return new ReturnPendingRequestDto(request.Id, request.TeamId, request.Date);
        }

        public static ReturnPendingRequestProductDto AsReturnPendingRequestProductDto(this PendingRequestProductModel product)
        {
            return new ReturnPendingRequestProductDto(product.Id, product.productId, product.quantity, product.pendingRequestId);
        }
    }
}