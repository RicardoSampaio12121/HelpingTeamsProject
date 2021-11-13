using System.Collections.Generic;

namespace RequestsApi.Entities
{
    public record TeamModel
    {
        public int Id { get; init; }
        public string Location { get; init; }
    }
}