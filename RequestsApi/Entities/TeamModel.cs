using System.Collections.Generic;

namespace RequestsApi.Entities
{
    public record TeamModel
    {
        public string Location { get; init; }
        public IEnumerable<TeamMemberModel> TeamMembers { get; init; }
    }
}