using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace RequestsApi.Dtos
{ 
    /// <summary>
    /// DTO of a product
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Quantity"></param>
    public record ProductDto(string Name, [Range(1, 1000)] int Quantity, float price);
    public record ReturnProductDto(int id, string Name, [Range(1, 1000)] int Quantity, float price);
    public record CreateProductDto(string Name, [Range(1, 1000)] int Quantity, float price);

    public record TeamDto(int id, string location);
    public record CreateTeamDto(string location);
    public record ReturnTeamDto(int id, string location);

    public record TeamMemberDto(int id, string name, string surname, int teamId, string organization);
    public record AddMemberDto(string Name, string Surname, string Organization);
    public record ReturnTeamMemberDto(int id, string name, string surname, int teamId, string organization);

    public record MakeRequestDto(int productId, int quantity);

    public record ReturnPendingRequestDto(int id, int productId, DateTime date);

    public record ReturnPendingRequestProductDto(int id, int productId, int quantity, int pendingRequestId);

    public record ReturnIdPriceQuantityDto(int id, float price, int quantity);

    public record AcceptRequestDto(int teamId, float price, string decision);

    public record UpdateProductsQuantityDto(int prodId, int quantityToTake);

    public record ReturnCompletedRequestDto(int id, int teamId, float price, DateTime date, string decision);

    public record ReturnCompletedRequestProductDto(int id, int productId, int requestId);

    public record UpdateProductQuantityDto(int quantityToAdd);
}