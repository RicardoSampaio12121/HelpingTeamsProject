/*
 * This file contains the definition of all the methods that interact with the database tables related to the teams
 */
using RequestsApi.Dtos;
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
        Task AddTeamMembersAsync(List<AddMemberDto> members);
        Task AddTeamMemberAsync(int teamId, AddMemberDto member);
        Task RemoveTeamMember(int memberId);
        Task<TeamModel> GetTeamByIdAsync(int id);
        Task RemoveTeam(int teamId);
        Task RemoveAllTeamMembers(int teamId);
    }
}
