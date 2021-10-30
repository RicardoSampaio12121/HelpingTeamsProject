using System.ComponentModel.DataAnnotations;

namespace RequestsApi.Dtos
{
    public record ProductDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(0, 1000)]
        public int Quantity { get; init; }
    }
}