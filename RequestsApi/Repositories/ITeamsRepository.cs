using RequestsApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestsApi.Repositories
{
    public interface ITeamsRepository
    {
         Task<IEnumerable<TeamModel>> GetTeamsAsync();
        Task<IEnumerable<TeamMemberModel>> GetTteamMembersAsync(int teamId);
        Task CreateTeamAsync(string organization);
    }
}
