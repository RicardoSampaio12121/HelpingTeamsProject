using System.Collections.Generic;
using MySql.Data.MySqlClient;
using RESTAuth.Models;
using System;
using System.Threading.Tasks;

namespace RESTAuth.Repository
{
    public class DashBoardLogin : IDashBoardLogin
    {
        private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=claudio;Pwd=cmffs1810;";
        public async Task<int> VerifyLogin(string username, string password)
        {
            var con = new MySqlConnection(DashBoardLogin.con);
            string sql = $"SELECT COUNT(*) from dashboard_login where name like '{username}' AND password like '{password}'";

            await using MySqlCommand cmd = new(sql, con);

            await con.OpenAsync();
            int result = (int)await cmd.ExecuteScalarAsync();
            await con.CloseAsync();

            return result;
        }
    }
}
