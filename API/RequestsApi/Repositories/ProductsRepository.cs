using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Threading.Tasks;
using RequestsApi.Entities;
using MySql.Data.MySqlClient;
using RequestsApi.Dtos;
using System;

namespace RequestsApi.Repositories
{
    /// <summary>
    /// Repository to manage some functions that only the people responsible for the shipping of products can access
    /// </summary>
    public class ProductsRepository : IProductsRepository
    {
        //TODO: Take the connection string to a secure place
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
            var con = new MySqlConnection(ProductsRepository.con);
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
                    Quantity = int.Parse(sqlDr[2].ToString()),
                    UnitPrice = float.Parse(sqlDr[3].ToString())
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }

        public async Task<Product> GatherProductAsync(int productId)
        {
            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"SELECT * FROM available_products WHERE id = '{productId}'";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();
            await sqlDr.ReadAsync();
            
            var output = new Product()
            {
                Id = sqlDr.GetInt32(0),
                Name = sqlDr.GetString(1),
                Quantity = sqlDr.GetInt32(2),
                UnitPrice = sqlDr.GetFloat(3)
            };

            return output;
        }

        public async Task<Product> GatherProductByNameAsync(string productName)
        {
            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"SELECT * FROM available_products WHERE name = '{productName}'";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();
            await sqlDr.ReadAsync();

            var output = new Product()
            {
                Id = sqlDr.GetInt32(0),
                Name = sqlDr.GetString(1),
                Quantity = sqlDr.GetInt32(2),
                UnitPrice = sqlDr.GetFloat(3)
            };

            return output;
        }

        public async Task CreateProduct(CreateProductDto product)
        {
            MySqlConnection con = new(ProductsRepository.con);
            const string sql =
                "INSERT INTO available_products (name, quantity, unit_price) VALUE (@name, @quantity, @price)";
            
            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();

            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = product.Name;
            cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = product.Quantity;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar, 100).Value = product.price;

            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task AddStock(int id, int quantity)
        {
            MySqlConnection con = new(ProductsRepository.con);
            string sql =
               $"UPDATE available_products SET quantity = quantity + @toAdd WHERE id = @id";

            await using MySqlCommand cmd = new(sql, con);

            cmd.Parameters.Add("@toAdd", MySqlDbType.Int32).Value = quantity;
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task CreateRequest(int teamId)
        {
            MySqlConnection con = new(ProductsRepository.con);

            string sql = "INSERT INTO pending_requests (teamId, date) VALUES (@team, @date)";

            await using MySqlCommand cmd = new(sql, con);

            cmd.Parameters.Add("@team", MySqlDbType.Int32).Value = teamId;
            cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now;
            
            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task AddProductsToRequest(List<MakeRequestDto> products)
        {
            MySqlConnection con = new(ProductsRepository.con);

            string sql = "INSERT INTO pending_requests_products (product_id, quantity, pending_request_id) VALUES (@prod, @quant, (SELECT MAX(id) FROM pending_requests))";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            foreach (var product in products)
            {
                cmd.Parameters.Add("@prod", MySqlDbType.Int32).Value = product.productId;
                cmd.Parameters.Add("@quant", MySqlDbType.Int32).Value = product.quantity;

                await cmd.ExecuteNonQueryAsync();

                cmd.Parameters.Clear();
            }
            
            await con.CloseAsync();
        }
    }
}