using Logic.Entities;
using Data.RepositoryApi;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Logic.Repositories
{
    public static class TeamsManagement
    {
        //public static async Task CreateTeam(TeamModel team) 
        //{
        //    var teamAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(team);
        //    await Teams.CreateTeam(teamAsJson);
        //}

        public static async Task<IEnumerable<TeamModel>> GetTeamsAsync()
        {
            var output = await Teams.GetTeamsAsync();
            return JsonConvert.DeserializeObject<IEnumerable<TeamModel>>(output);
            //return output;
        }     
    }
}