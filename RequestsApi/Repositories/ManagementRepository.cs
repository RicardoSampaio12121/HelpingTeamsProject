using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Threading.Tasks;
using RequestsApi.Entities;
using MySql.Data.MySqlClient;
using RequestsApi.Dtos;

namespace RequestsApi.Repositories
{
    /// <summary>
    /// Repository to manage some functions that only the people responsible for the shipping of products can access
    /// </summary>
    public class ManagementRepository : IManagementRepository
    {
        private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=root;Pwd=thethreedeadlyhallows;";
        //private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=claudio;Pwd=cmffs1810;";

        /// <summary>
        /// Gets all the available products in tha database
        /// </summary>
        /// <returns>
        /// IEnumerable of available products
        /// </returns>
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var con = new MySqlConnection(ManagementRepository.con);
            const string sql = "SELECT * FROM available_products";
            List<Product> output = new();

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();
                
            while (await sqlDr.ReadAsync())
            {
                output.Add(new Product()
                {
                    Id = int.Parse(sqlDr[0].ToString()),
                    Name = sqlDr[1].ToString(),
                    Quantity = int.Parse(sqlDr[2].ToString())
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }

        public async Task<Product> GatherProductAsync(int productId)
        {
            MySqlConnection con = new(ManagementRepository.con);
            string sql = $"SELECT * FROM available_products WHERE id = '{productId}'";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();
            await sqlDr.ReadAsync();
            
            var output = new Product()
            {
                Id = sqlDr.GetInt32(0),
                Name = sqlDr.GetString(1),
                Quantity = sqlDr.GetInt32(2)
            };

            return output;
        }

        public async Task<Product> GatherProductByNameAsync(string productName)
        {
            MySqlConnection con = new(ManagementRepository.con);
            string sql = $"SELECT * FROM available_products WHERE name = '{productName}'";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();
            await sqlDr.ReadAsync();

            var output = new Product()
            {
                Id = sqlDr.GetInt32(0),
                Name = sqlDr.GetString(1),
                Quantity = sqlDr.GetInt32(2)
            };

            return output;
        }

        public async Task CreateProduct(CreateProductDto product)
        {
            MySqlConnection con = new(ManagementRepository.con);
            const string sql =
                "INSERT INTO available_products (name, quantity) VALUE (@name, @quantity)";
            
            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();

            cmd.Parameters.AddWithValue(@"name", product.Name);
            cmd.Parameters.AddWithValue("@quantity", product.Quantity);

            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task CreateTeam(TeamModel team)
        {
            MySqlConnection con = new(ManagementRepository.con);
            string sqlTeam =
                $"INSERT INTO teams (location) VALUES ({team.Location})";

            string sqlMembers = $"INSERT INTO team_members (name, surname, team, organization) VALUES";

            foreach(var member in team.TeamMembers)
            {
                sqlMembers += $" ({member.Name}, {member.Surname}, (SELECT MAX(id) FROM teams), {member.Organization}),";
            }

            sqlMembers = sqlMembers.Remove(sqlMembers.Length - 1);

            await using MySqlCommand cmdMembers = new(sqlMembers, con);
            await using MySqlCommand cmdTeam = new(sqlTeam, con);
            
            await con.OpenAsync();

            await cmdTeam.ExecuteNonQueryAsync();
            await cmdMembers.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task AddStock(int id, int quantity)
        {
            MySqlConnection con = new(ManagementRepository.con);
            string sql =
               $"UPDATE available_products SET quantity=quantity+'{quantity}' WHERE id='{id}'";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

    }
}