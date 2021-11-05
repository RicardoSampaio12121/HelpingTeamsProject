using System.Collections.Generic;

namespace Logic.Entities
{
    public record TeamModel
    {
        public string Location { get; init; }
        public IEnumerable<TeamMemberModel> TeamMembers { get; init; }
    }
}