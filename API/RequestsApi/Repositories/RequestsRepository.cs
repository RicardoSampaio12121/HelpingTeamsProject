/*
 * This file has a class that implements the IRequestsRepository
 */

using MySql.Data.MySqlClient;
using RequestsApi.Dtos;
using RequestsApi.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RequestsApi.Repositories
{
    public class RequestsRepository : IRequestsRepository
    {
        //TODO: take this to appsetting.json
        string connectionString = "Server=localhost;Port=3306;Database=isi_tp1;Uid=root;Pwd=thethreedeadlyhallows;";
        /// <summary>
        /// Gets the information of completed requests
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CompletedRequestModel>> GetCompletedRequests()
        {
            List<CompletedRequestModel> output = new();

            MySqlConnection con = new(connectionString);
            string sql = $"SELECT * FROM requests";

            await using MySqlCommand cmd = new(sql, con);

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

        /// <summary>
        /// Gets the information of the completed requests of a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CompletedRequestModel>> GetCompletedRequests(int teamId)
        {
            List<CompletedRequestModel> output = new();

            MySqlConnection con = new(connectionString);
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

        /// <summary>
        /// Gets the products related to a specific request
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CompletedRequestProductModel>> GetCompletedRequestProducts(int requestId)
        {
            List<CompletedRequestProductModel> output = new();

            MySqlConnection con = new(connectionString);
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

        /// <summary>
        /// Completes a request(denies or accepts it)
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task HandleRequest(AcceptRequestDto info)
        {
            MySqlConnection con = new(connectionString);

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

        /// <summary>
        /// Inserts information about the products of a request that just got completed
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task HandleRequestProducts(List<int> ids)
        {
            MySqlConnection con = new(connectionString);

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

        /// <summary>
        /// Deletes the products of a request that is no longer pending
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task DeletePendingRequestProducts(int requestId)
        {
            var con = new MySqlConnection(connectionString);
            string sql = "DELETE FROM pending_requests_products WHERE pending_request_id = @id";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = requestId;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        /// <summary>
        /// Deletes a no longer pending request
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task DeletePendingRequest(int requestId)
        {
            var con = new MySqlConnection(connectionString);
            string sql = "DELETE FROM pending_requests WHERE id = @id";

            await using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = requestId;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        /// <summary>
        /// Creates a request
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task CreateRequest(int teamId)
        {
            MySqlConnection con = new(connectionString);

            string sql = "INSERT INTO pending_requests (teamId, date) VALUES (@team, @date)";

            await using MySqlCommand cmd = new(sql, con);

            cmd.Parameters.Add("@team", MySqlDbType.Int32).Value = teamId;
            cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await con.CloseAsync();
        }

        /// <summary>
        /// Inserts the products related to the recently added request
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public async Task AddProductsToRequest(List<MakeRequestDto> products)
        {
            MySqlConnection con = new(connectionString);

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

        /// <summary>
        /// Get all the pending requests related to a team
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PendingRequestModel>> GetPendingRequestsByTeam(int teamId)
        {
            List<PendingRequestModel> output = new();

            MySqlConnection con = new(connectionString);
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

        /// <summary>
        /// Gets the products related to a specific pending request
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PendingRequestProductModel>> GetPendingRequestProducts(int requestId)
        {
            List<PendingRequestProductModel> output = new();

            MySqlConnection con = new(connectionString);
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

        /// <summary>
        /// Get all the pending requests
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PendingRequestModel>> GetPendingRequests()
        {
            List<PendingRequestModel> output = new();

            MySqlConnection con = new(connectionString);
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
    }
}
