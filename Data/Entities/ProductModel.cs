using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public record ProductModel
    {
        public int Id { get; init; }
        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Quantity of the product
        /// </summary>
        public int Quantity { get; init; }
    }
}
