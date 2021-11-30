using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PSPGNR
{
    public static class DataBaseManager
    {
        private const string con = @"Server=localhost;Port=3306;Database=isi_tp1;Uid=root;Pwd=thethreedeadlyhallows;";

        public static int InsertPSP(Fiscalizacao fisc)
        {
            int tot = 0;

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

        public static int InsertGNR(Fiscalizacao fisc)
        {
            int tot = 0;

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
