using Newtonsoft.Json;
using System;

namespace Logic.Entities
{
    public record PendingRequestModel
    {
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("productId")]
        public int teamId { get; set; }
        
        [JsonProperty("date")]
        public DateTime date { get; set; }
    }
}
