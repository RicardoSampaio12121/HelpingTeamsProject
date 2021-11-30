using Logic.Entities;
using Data.RepositoryApi;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logic.Repositories
{
    public static class TeamsManagement
    {
        /// <summary>
        /// Creates a team, including team members
        /// </summary>
        /// <param name="team"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public static async Task CreateTeamWithMembers(CreateTeamModel team ,List<TeamMemberModel> members)
        {
            string teamAsJson = JsonConvert.SerializeObject(team);
            string membersAsJson = JsonConvert.SerializeObject(members);

            await Teams.CallPostTeams("CreateTeam", teamAsJson);
            await Teams.CallPostTeams("AddMembers", membersAsJson);
        }

        /// <summary>
        /// Creates a team
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        public static async Task CreateTeam(CreateTeamModel team)
        {
            string teamAsJson = JsonConvert.SerializeObject(team);
            await Teams.CallPostTeams("CreateTeam", teamAsJson);
        }

        /// <summary>
        /// Adds a member to a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static async Task AddMemberToTeam(int teamId, TeamMemberModel member)
        {
            string memberAsJson = JsonConvert.SerializeObject(member);
            await Teams.CallPostTeams($"AddMember/{teamId}", memberAsJson);
        }

        /// <summary>
        /// Gets all the teams
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<TeamModel>> GetTeamsAsync()
        {
            var output = await Teams.CallGetTeams("GetTeams");
            return JsonConvert.DeserializeObject<IEnumerable<TeamModel>>(output);
        }

        /// <summary>
        /// Gets all the team members from a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<TeamMemberModel>> GetTeamMembersAsync(int teamId)
        {
            var output = await Teams.CallGetTeams($"GetTeamMembers/{teamId}");
            return JsonConvert.DeserializeObject<IEnumerable<TeamMemberModel>>(output);
        }

        /// <summary>
        /// Removes a member from a team
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task RemoveMemberFromTeam(int id)
        {
            await Teams.CallDeleteTeams($"RemoveMember/{id}");
        }

        /// <summary>
        /// Removes an entire team, including its members
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public static async Task RemoveTeam(int teamId)
        {
            await Teams.CallDeleteTeams($"RemoveAllTeamMembers/{teamId}");
            await Teams.CallDeleteTeams($"RemoveTeam/{teamId}");
        }
    }
}