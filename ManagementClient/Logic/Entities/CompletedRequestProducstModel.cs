﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities
{
    public record CompletedRequestProducstModel
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int  requestId { get; set; }
    }
}
