using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Model of the product of a completed request
    /// </summary>
    public record CompletedRequestProductModel
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int requestId { get; set; }
    }
}
