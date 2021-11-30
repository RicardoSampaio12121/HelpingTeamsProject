using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Model of the product of a pending request
    /// </summary>
    public record PendingRequestProductModel
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public int pendingRequestId { get; set; }
    }
}
