using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    /// <summary>
    /// Model of something that I forgot.
    /// </summary>
    public record ToAcceptRequestInfo
    {
        [JsonProperty("id")]
        public int propId { get; set; }

        [JsonProperty("price")]
        public float prodPrice { get; set; }
        
        [JsonProperty("quantity")]
        public int propQuantity { get; set; }
    }
}
