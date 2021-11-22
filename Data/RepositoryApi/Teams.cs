using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Data.Connector;

namespace Data.RepositoryApi
{
    public static class Teams
    {
        public static async Task<string> GetTeamsAsync()
        {
            string url = "https://localhost:44358/teams/GetTeams";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task<string> GetTeamMembersAsync(int teamId)
        {
            string url = $"https://localhost:44358/teams/GetTeamMembers/{teamId}";

            using (HttpResponseMessage response = await Connector.Connector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task AddTeamMemberById(int teamId, string memberAsJson)
        {
            string url = $"https://localhost:44358/teams/AddMember/{teamId}";

            var stringContent = new StringContent(memberAsJson, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }

        public static async Task RemoveMemberFromTeam(int memberId)
        {
            string url = $"https://localhost:44358/teams/RemoveMember/{memberId}";
            await Connector.Connector.ApiClient.DeleteAsync(url);
        }

        public static async Task CreateTeam(string teamAsJson)
        {
            string url = $"https://localhost:44358/teams/CreateTeam";

            var stringContent = new StringContent(teamAsJson, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }

        public static async Task AddTeamMembers(string membersAsJson)
        {
            string url = $"https://localhost:44358/teams/AddMembers";

            var stringContent = new StringContent(membersAsJson, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }



        


    }
}
