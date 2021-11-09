using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public class ProductModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Quantity of the product
        /// </summary>
        public int Quantity { get; set; }
    }
}
