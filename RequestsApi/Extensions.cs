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
            return new ProductDto(product.Name, product.Quantity);
        }

        public static ReturnTeamDto AsReturnTeamDto(this TeamModel team)
        {
            return new ReturnTeamDto(team.Id, team.Location);
        }
    }
}