using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RequestsApi.Dtos
{ 
    /// <summary>
    /// DTO of a product
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Quantity"></param>
    public record ProductDto(string Name, [Range(1, 1000)] int Quantity, float price);
    public record ReturnProductDto(string Name, [Range(1, 1000)] int Quantity, float price);
    public record CreateProductDto(string Name, [Range(1, 1000)] int Quantity, float price);

    public record TeamDto(int id, string location);
    public record CreateTeamDto(string location);
    public record ReturnTeamDto(int id, string location);

    public record TeamMemberDto(int id, string name, string surname, int teamId, string organization);
    public record AddMemberDto(string Name, string Surname, string Organization);
    public record ReturnTeamMemberDto(int id, string name, string surname, int teamId, string organization);



}