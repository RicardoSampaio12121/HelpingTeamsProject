using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;


/// <summary>
/// Descrição resumida de DataBaseManager
/// </summary>
[WebService]
public class CovidManagement : System.Web.Services.WebService
{

    public CovidManagement()
    {
    }
    private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=root;Pwd=thethreedeadlyhallows;";

    [WebMethod]
    public int InsertInfectedUser(int cc)
    {
        int tot = 0;

        using (MySqlConnection conn = new MySqlConnection(con))
        {
            string query = "INSERT INTO utentes_infetados (cc, Data) VALUES (@cc, @data)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.Add("@cc", MySqlDbType.Int32).Value = cc;
            cmd.Parameters.Add("@data", MySqlDbType.DateTime).Value = DateTime.Now;

            conn.Open();

            tot = cmd.ExecuteNonQuery();

            conn.Close();
        }

        return tot;   
    }

    [WebMethod]
    public int InsertUsersInContact(List<int> ccs, int cc_infetado)
    {
        int tot = 0;

        using (MySqlConnection conn = new MySqlConnection(con))
        {
            string query = "INSERT INTO utentes_contacto (cc, cc_infetado, data) VALUES (@cc, @ccInf, @data)";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            conn.Open();

            foreach (int cc in ccs)
            {
                cmd.Parameters.Add("@cc", MySqlDbType.Int32).Value = cc;
                cmd.Parameters.Add("@ccInf", MySqlDbType.Int32).Value = cc_infetado;
                cmd.Parameters.Add("@data", MySqlDbType.DateTime).Value = DateTime.Now;
            
                tot += cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            conn.Close();
        }

        return tot;
    }
}