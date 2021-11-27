using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public record HandleRequest
    {
        public int teamId { get; set; }
        public float price { get; set; }
        public string decision { get; set; }
    }
}
