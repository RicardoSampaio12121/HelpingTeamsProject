using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public record PendingRequestModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("productId")]
        public int TeamId { get; set; }
        
        [JsonProperty("date")]
        public DateTime RequestDate { get; set; }
    }
}
