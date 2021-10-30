using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RequestsApi.Entities;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace RequestsApi.Repositories
{
    public class ManagementRepository : IManagementRepository
    {
        private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=ricardo;Pwd=thethreedeadlyhallows;";
        
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var con = new MySqlConnection(ManagementRepository.con);
            const string sql = "SELECT * FROM productsAvailable";
            List<Product> output = new();
            
            await using (MySqlCommand cmd = new(sql, con))
            {
                await con.OpenAsync();
                var sqlDr = await cmd.ExecuteReaderAsync();
                
                while (await sqlDr.ReadAsync())
                {
                    output.Add(new Product()
                    {
                        Name = sqlDr[0].ToString(),
                        Quantity = int.Parse(sqlDr[1].ToString())
                    });
                }
                await sqlDr.CloseAsync();
                await con.CloseAsync();

            }
            
            return output;
        }
    }
}