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
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("productId")]
        public int product_id { get; set; }
        
        [JsonProperty("quantity")]
        public int quantity { get; set; }
        
        [JsonProperty("pendingRequestId")]
        public int pendingRequestId { get; set; }
    }
}
