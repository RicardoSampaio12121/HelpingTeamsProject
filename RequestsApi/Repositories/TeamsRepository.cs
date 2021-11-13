using MySql.Data.MySqlClient;
using RequestsApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestsApi.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=root;Pwd=thethreedeadlyhallows;";


        public async Task<IEnumerable<TeamModel>> GetTeamsAsync()
        {
            var con = new MySqlConnection(TeamsRepository.con);
            const string sql = "SELECT * FROM teams";
            List<TeamModel> output = new();

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                output.Add(new TeamModel()
                {
                    Id = int.Parse(sqlDr[0].ToString()),
                    Location = sqlDr[1].ToString()
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }
    }
}
