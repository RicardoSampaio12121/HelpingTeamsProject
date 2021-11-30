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
        private const string standartUrl = "https://localhost:44358/teams";

        /// <summary>
        /// Sends a get request to the api
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<string> CallGetTeams(string endpoint)
        {
            string url = $"{standartUrl}/{endpoint}";

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

        /// <summary>
        /// Sends a post request to the api
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="contentAsJson"></param>
        /// <returns></returns>
        public static async Task CallPostTeams(string endpoint, string contentAsJson)
        {
            string url = $"{standartUrl}/{endpoint}";

            var stringContent = new StringContent(contentAsJson, Encoding.UTF8, "application/json");
            var result = await Connector.Connector.ApiClient.PostAsync(url, stringContent);
        }

        /// <summary>
        /// Sends a delete request to the api
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public static async Task CallDeleteTeams(string endpoint)
        {
            string url = $"{standartUrl}/{endpoint}";
            await Connector.Connector.ApiClient.DeleteAsync(url);
        }
    }
}
