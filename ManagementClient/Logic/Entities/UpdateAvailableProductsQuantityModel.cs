using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Model to update the quantity of a product
    /// </summary>
    public record UpdateAvailableProductsQuantityModel
    {
        public int prodId { get; set; }
        public int quantityToTake { get; set; }
    }
}
