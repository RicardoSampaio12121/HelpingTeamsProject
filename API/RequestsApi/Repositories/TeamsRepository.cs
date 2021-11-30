/*
 * This file contains a class that implements the ITeamsRepository
 */
using MySql.Data.MySqlClient;
using RequestsApi.Dtos;
using RequestsApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestsApi.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=root;Pwd=thethreedeadlyhallows;";

        /// <summary>
        /// Adds a team member to a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task AddTeamMemberAsync(int teamId, AddMemberDto member)
        {
            var con = new MySqlConnection(TeamsRepository.con);
            string sql = $"INSERT INTO team_members (name, surname, team, organization) VALUES (@name, @surname, @team, @organization)";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = member.Name;
            cmd.Parameters.Add("@surname", MySqlDbType.VarChar).Value = member.Surname;
            cmd.Parameters.Add("@team", MySqlDbType.Int32).Value = teamId;
            cmd.Parameters.Add("@organization", MySqlDbType.VarChar).Value = member.Organization;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        /// <summary>
        /// Adds one or more team members to a team
        /// </summary>
        /// <param name="members"></param>
        /// <returns></returns>
        public async Task AddTeamMembersAsync(List<AddMemberDto> members)
        {
            var con = new MySqlConnection(TeamsRepository.con);
            string sql = $"INSERT INTO team_members (name, surname, team, organization) VALUES (@name, @surname, (SELECT MAX(id) FROM teams), @organization)";

            await using MySqlCommand cmd = new(sql, con);

            await con.OpenAsync();

            foreach (var member in members)
            {
                cmd.Parameters.AddWithValue("@name", member.Name);
                cmd.Parameters.AddWithValue("@surname", member.Surname);
                cmd.Parameters.AddWithValue("@organization", member.Organization);

                await cmd.ExecuteNonQueryAsync();

                cmd.Parameters.Clear();
            }
            await con.CloseAsync();
        }

        /// <summary>
        /// Creates a team
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public async Task CreateTeamAsync(string location)
        {
            var con = new MySqlConnection(TeamsRepository.con);
            string sql = $"INSERT INTO teams (location) VALUES ('{location}')";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        /// <summary>
        /// Gets the information of a team by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TeamModel> GetTeamByIdAsync(int id)
        {
            TeamModel team = new();

            var con = new MySqlConnection(TeamsRepository.con);
            const string sql = "SELECT * FROM teams WHERE id = @id";
            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                team.Id = int.Parse(sqlDr[0].ToString());
                team.Location = sqlDr[1].ToString();
            }
            
            return team;
        }

        /// <summary>
        /// Gets the information of all the teams
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get all the team members of a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TeamMemberModel>> GetTteamMembersAsync(int teamId)
        {
            var con = new MySqlConnection(TeamsRepository.con);
            string sql = $"SELECT * FROM team_members WHERE team = '{teamId}'";
            List<TeamMemberModel> output = new();

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                output.Add(new TeamMemberModel()
                {
                    Id = int.Parse(sqlDr[0].ToString()),
                    Name = sqlDr[1].ToString(),
                    Surname = sqlDr[2].ToString(),
                    Team = int.Parse(sqlDr[3].ToString()),
                    Organization = sqlDr[4].ToString()
                }) ;
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }

        /// <summary>
        /// Remove all team members from a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task RemoveAllTeamMembers(int teamId)
        {
            var con = new MySqlConnection(TeamsRepository.con);
            string sql = "DELETE FROM team_members WHERE team = @team";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@team", MySqlDbType.Int32).Value = teamId;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        /// <summary>
        /// Removes a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task RemoveTeam(int teamId)
        {
            var con = new MySqlConnection(TeamsRepository.con);
            string sql = "DELETE FROM teams WHERE id = @id";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = teamId;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        /// <summary>
        /// Removes a team member
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task RemoveTeamMember(int memberId)
        {
            var con = new MySqlConnection(TeamsRepository.con);
            string sql = "DELETE FROM team_members WHERE id = @id";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = memberId;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }
    }
}
