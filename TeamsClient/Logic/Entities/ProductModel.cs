using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Model of a product
    /// </summary>
    public record ProductModel
    {
        public int id { get; init; }
        public string name { get; init; }
        public int quantity { get; init; }
        public float unitPrice { get; init; }
    }
}
