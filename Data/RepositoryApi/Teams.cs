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

        //// This method receives a json with the information needed
        //public static async Task CreateTeam(string teamAsJson)
        //{
        //    string url = "https://localhost:44358/management/GetAvailableProducts";


        //    var content = new StringContent(teamAsJson, Encoding.UTF8, "application/json");

        //    /*using (HttpResponseMessage response = */
        //    await Connector.Connector.ApiClient.PostAsync(url, content);
        //    //{
        //    //if (response.IsSuccessStatusCode)
        //    //{
        //    //    // nada
        //    //}
        //    //else
        //    //{
        //    //    // tambem nada
        //    //}
        //    //}
        //}


    }
}
