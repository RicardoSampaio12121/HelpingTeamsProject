/*
 * This file contains web methods to communicate with the database
 */

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Configuration;


/// <summary>
/// This class contains web methods to communicate with the database
/// </summary>
[WebService]
public class CovidManagement : System.Web.Services.WebService
{

    public CovidManagement(){}

    /// <summary>
    /// Inserts and infected user in the database
    /// </summary>
    /// <param name="cc"></param>
    /// <returns></returns>
    [WebMethod]
    public int InsertInfectedUser(int cc)
    {
        int tot = 0;

        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

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

    /// <summary>
    /// Inserts people that were in contact with an infected user in the database
    /// </summary>
    /// <param name="ccs"></param>
    /// <param name="cc_infetado"></param>
    /// <returns></returns>
    [WebMethod]
    public int InsertUsersInContact(List<int> ccs, int cc_infetado)
    {
        int tot = 0;

        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

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