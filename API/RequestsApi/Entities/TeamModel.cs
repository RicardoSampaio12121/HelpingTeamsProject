using System.Collections.Generic;

namespace RequestsApi.Entities
{
    public record TeamModel
    {
        public int Id { get; set; }
        public string Location { get; set; }
    }
}