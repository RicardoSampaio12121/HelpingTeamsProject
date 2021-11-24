using Logic.Entities;
using Data.RepositoryApi;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logic.Repositories
{
    public static class TeamsManagement
    {
        public static async Task CreateTeamWithMembers(CreateTeamModel team ,List<TeamMemberModel> members)
        {
            string teamAsJson = JsonConvert.SerializeObject(team);
            string membersAsJson = JsonConvert.SerializeObject(members);

            await Teams.CreateTeam(teamAsJson);
            await Teams.AddTeamMembers(membersAsJson);
        }

        public static async Task CreateTeam(CreateTeamModel team)
        {
            string teamAsJson = JsonConvert.SerializeObject(team);

            await Teams.CreateTeam(teamAsJson);
        }

        public static async Task AddMemberToTeam(int teamId, TeamMemberModel member)
        {
            string memberAsJson = JsonConvert.SerializeObject(member);

            await Teams.AddTeamMemberById(teamId, memberAsJson);
        }

        public static async Task<IEnumerable<TeamModel>> GetTeamsAsync()
        {
            var output = await Teams.GetTeamsAsync();
            return JsonConvert.DeserializeObject<IEnumerable<TeamModel>>(output);
        }

        public static async Task<IEnumerable<TeamMemberModel>> GetTeamMembersAsync(int teamId)
        {
            var output = await Teams.GetTeamMembersAsync(teamId);
            return JsonConvert.DeserializeObject<IEnumerable<TeamMemberModel>>(output);
        }

        public static async Task RemoveMemberFromTeam(int id)
        {
            await Teams.RemoveMemberFromTeam(id);
        }

        public static async Task RemoveTeam(int teamId)
        {
            await Teams.RemoveAllTeamMembers(teamId);
            await Teams.RemoveTeam(teamId);
        }
    }
}