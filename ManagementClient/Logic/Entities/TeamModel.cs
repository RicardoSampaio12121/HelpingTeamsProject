using System.Collections.Generic;

namespace Logic.Entities
{
    /// <summary>
    /// Model of a team
    /// </summary>
    public record TeamModel
    {
        public int Id { get; set; }
        public string Location { get; init; }
    }
}