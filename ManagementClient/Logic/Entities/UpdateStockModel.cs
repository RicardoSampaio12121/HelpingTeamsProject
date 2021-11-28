using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public record UpdateStockModel
    {
        public int quantityToAdd { get; set; }
    }
}
