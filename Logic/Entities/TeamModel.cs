using System.Collections.Generic;

namespace Logic.Entities
{
    public record TeamModel
    {
        public int Id { get; set; }
        public string Location { get; init; }
    }
}