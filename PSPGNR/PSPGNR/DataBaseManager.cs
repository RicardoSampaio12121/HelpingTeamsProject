/*
 * This file has the methods to insert the data into the database
 */

using MySql.Data.MySqlClient;
using System;
using System.Configuration;


namespace PSPGNR
{
    /// <summary>
    /// Has the methods to insert data to the database
    /// </summary>
    public static class DataBaseManager
    {
        /// <summary>
        /// Inserts the content from the XML file given by PSP into the database
        /// </summary>
        /// <param name="fisc"></param>
        /// <returns></returns>
        public static int InsertPSP(Fiscalizacao fisc)
        {
            int tot = 0;
            string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                string query = "INSERT INTO psp_covid (cc, infracao, date) VALUES (@cc, @inf, @date)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();

                foreach (var u in fisc.utente)
                {
                    if (u.infracao != null)
                    {
                        cmd.Parameters.Add("@inf", MySqlDbType.VarChar, 250).Value = u.infracao;
                    }
                    else
                    {
                        cmd.Parameters.Add("@inf", MySqlDbType.VarChar, 250).Value = null;
                    }

                    cmd.Parameters.Add("@cc", MySqlDbType.Int32).Value = u.nus;
                    cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now;

                    tot += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                conn.Close();
            }

            return tot;
        }

        /// <summary>
        /// Inserts the content in the JSON file given by the GNR into the database
        /// </summary>
        /// <param name="fisc"></param>
        /// <returns></returns>
        public static int InsertGNR(Fiscalizacao fisc)
        {
            int tot = 0;
            string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(con))
            {
                string query = "INSERT INTO gnr_covid (cc, infracao, date) VALUES (@cc, @inf, @date)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();

                foreach (var u in fisc.utente)
                {
                    if (u.infracao != null)
                    {
                        cmd.Parameters.Add("@inf", MySqlDbType.VarChar, 250).Value = u.infracao;
                    }
                    else
                    {
                        cmd.Parameters.Add("@inf", MySqlDbType.VarChar, 250).Value = null;
                    }

                    cmd.Parameters.Add("@cc", MySqlDbType.Int32).Value = u.nus;
                    cmd.Parameters.Add("@date", MySqlDbType.DateTime).Value = DateTime.Now;

                    tot += cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                conn.Close();
            }

            return tot;
        }
    }
}
