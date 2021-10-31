using System.ComponentModel.DataAnnotations;

namespace RequestsApi.Entities
{
    /// <summary>
    /// Model for a product
    /// </summary>
    public record Product
    {
        /// <summary>
        /// Name of the product
        /// </summary>
        [Required]
        public string Name { get; init; }
        
        /// <summary>
        /// Quantity of the product
        /// </summary>
        [Required]
        [Range(1, 1000)]
        public int Quantity { get; init; }
    }
}