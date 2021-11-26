using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public record ProductInBasket
    {
        public int productId { get; init; }
        public int quantity { get; init; }

    }
}
