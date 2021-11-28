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

        public async Task<IEnumerable<PendingRequestModel>> GetPendingRequestsByTeam(int teamId)
        {
            List<PendingRequestModel> output = new();

            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"SELECT * FROM pending_requests WHERE teamId = @id";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = teamId;
            
            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                output.Add(new PendingRequestModel()
                {
                    Id = int.Parse(sqlDr[0].ToString()),
                    TeamId = int.Parse(sqlDr[1].ToString()),
                    Date = DateTime.Parse(sqlDr[2].ToString())
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }

        public async Task<IEnumerable<PendingRequestProductModel>> GetPendingRequestProducts(int requestId)
        {
            List<PendingRequestProductModel> output = new();

            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"SELECT * FROM pending_requests_products WHERE pending_request_id = @reqId";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@reqId", MySqlDbType.Int32).Value = requestId;

            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                output.Add(new PendingRequestProductModel()
                {
                    Id = int.Parse(sqlDr[0].ToString()),
                    productId = int.Parse(sqlDr[1].ToString()),
                    quantity = int.Parse(sqlDr[2].ToString()),
                    pendingRequestId = int.Parse(sqlDr[3].ToString())
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }

        public async Task<IEnumerable<PendingRequestModel>> GetPendingRequests()
        {
            List<PendingRequestModel> output = new();

            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"SELECT * FROM pending_requests";

            await using MySqlCommand cmd = new(sql, con);

            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                output.Add(new PendingRequestModel()
                {
                    Id = int.Parse(sqlDr[0].ToString()),
                    TeamId = int.Parse(sqlDr[1].ToString()),
                    Date = DateTime.Parse(sqlDr[2].ToString())
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }

        public async Task<IEnumerable<IdPriceQuantityModel>> GetIdPriceQuantity(int reqId)
        {
            List<IdPriceQuantityModel> output = new();

            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"select ap.unit_price as prodPrice, prp.product_id AS prodId, prp.quantity AS prodQuantity from available_products ap inner join pending_requests_products prp ON prp.product_id = ap.id and prp.pending_request_id = @reqId";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@reqId", MySqlDbType.Int32).Value = reqId;

            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                output.Add(new IdPriceQuantityModel()
                {
                    price = float.Parse(sqlDr[0].ToString()),
                    id = int.Parse(sqlDr[1].ToString()),
                    quantity = int.Parse(sqlDr[2].ToString())
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }

        public async Task HandleRequest(AcceptRequestDto info)
        {
            MySqlConnection con = new(ProductsRepository.con);

            string sql = "INSERT INTO requests (team_id, price, date, decision) VALUES (@teamId, @price, @date, @decision)";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
           
            cmd.Parameters.Add("@teamId", MySqlDbType.Int32).Value = info.teamId;
            cmd.Parameters.Add("@price", MySqlDbType.Float).Value = info.price;
            cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@decision", MySqlDbType.VarChar, 100).Value = info.decision;

            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task HandleRequestProducts(List<int> ids)
        {
            MySqlConnection con = new(ProductsRepository.con);

            string sql = "INSERT INTO requests_products (product_id, request_id) VALUES (@prodId, (SELECT MAX(id) FROM requests))";

            await using MySqlCommand cmd = new(sql, con);
            await con.OpenAsync();
            
            foreach (var id in ids)
            {
                cmd.Parameters.Add("@prodId", MySqlDbType.Int32).Value = id;

                await cmd.ExecuteNonQueryAsync();
                
                cmd.Parameters.Clear();
            }
            await con.CloseAsync();
        }

        public async Task DeletePendingRequestProducts(int requestId)
        {
            var con = new MySqlConnection(ProductsRepository.con);
            string sql = "DELETE FROM pending_requests_products WHERE pending_request_id = @id";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = requestId;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task DeletePendingRequest(int requestId)
        {
            var con = new MySqlConnection(ProductsRepository.con);
            string sql = "DELETE FROM pending_requests WHERE id = @id";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = requestId;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        public async Task UpdateProductsQuantity(List<UpdateProductsQuantityDto> toUpdate)
        {
            MySqlConnection con = new(ProductsRepository.con);
            string sql =
               $"UPDATE available_products SET quantity = quantity - @toTake WHERE id = @id";

            await using MySqlCommand cmd = new(sql, con);

            await con.OpenAsync();
            
            foreach (var values in toUpdate)
            {
                cmd.Parameters.Add("@toTake", MySqlDbType.Int32).Value = values.quantityToTake;
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = values.prodId;
                
                await cmd.ExecuteNonQueryAsync();
                cmd.Parameters.Clear();
            }

            await con.CloseAsync();
        }

        public async Task<IEnumerable<CompletedRequestModel>> GetCompletedRequests(int teamId)
        {
            List<CompletedRequestModel> output = new();

            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"SELECT * FROM requests WHERE team_id = @teamId";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@teamId", MySqlDbType.Int32).Value = teamId;

            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                output.Add(new CompletedRequestModel()
                {
                    id = int.Parse(sqlDr[0].ToString()),
                    teamId = int.Parse(sqlDr[1].ToString()),
                    price = float.Parse(sqlDr[2].ToString()),
                    date = DateTime.Parse(sqlDr[3].ToString()),
                    decision = sqlDr[4].ToString()
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }

        public async Task<IEnumerable<CompletedRequestProductModel>> GetCompletedRequestProducts(int requestId)
        {
            List<CompletedRequestProductModel> output = new();

            MySqlConnection con = new(ProductsRepository.con);
            string sql = $"SELECT * FROM requests_products WHERE request_id = @req_id";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@req_id", MySqlDbType.Int32).Value = requestId;

            await con.OpenAsync();
            var sqlDr = await cmd.ExecuteReaderAsync();

            while (await sqlDr.ReadAsync())
            {
                output.Add(new CompletedRequestProductModel()
                {
                    id = int.Parse(sqlDr[0].ToString()),
                    productId = int.Parse(sqlDr[1].ToString()),
                    requestId = int.Parse(sqlDr[2].ToString())
                });
            }
            await sqlDr.CloseAsync();
            await con.CloseAsync();

            return output;
        }
    }
}