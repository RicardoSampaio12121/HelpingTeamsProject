using Logic.Entities;
using Data.RepositoryApi;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Logic.Repositories
{
    public static class TeamsManagement
    {
        public static async Task CreateTeam(TeamModel team) 
        {
            var teamAsJson = Newtonsoft.Json.JsonConvert.SerializeObject(team);
            await Teams.CreateTeam(teamAsJson);
        }
        
    }
}