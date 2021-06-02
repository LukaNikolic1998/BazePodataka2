using BpProjekat;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Funkcije
    {
        public static List<string> F_GET_StripPoKategoriji(int id)
        {
            List<string> strips = new List<string>();

            using (var db = new BpProjekatModelContext())
            {
                string connectionString = @"Server =DESKTOP-820A4J3; Database = BpProjekatModel; Trusted_Connection = True;";
                string sql = "select * from F_GET_StripPoKategoriji(" + id + ");";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        strips.Add((string)reader[0]);
                    }
                }
                sqlConnection.Close();
            }
            return strips;
        }

        public static int F_GET_BrojStripova()
        {
            int broj;
            var return_value = new SqlParameter("@return_value", SqlDbType.NVarChar, 20);
            return_value.Direction = ParameterDirection.Output;
            using (var db = new BpProjekatModelContext())
            {
                var query = db.Database.ExecuteSqlCommand("EXEC @return_value = F_GET_BrojStripova;", return_value);
                broj = Int32.Parse(return_value.Value.ToString());
            }
            return broj;
        }

        public static List<Tuple<string, string, string>> F_GET_TriTabele()
        {
            List<Tuple<string, string, string>> strips = new List<Tuple<string, string, string>>();
            using (var db = new BpProjekatModelContext())
            {
                string connectionString = @"Server =DESKTOP-820A4J3; Database = BpProjekatModel; Trusted_Connection = True;";
                string sql = "select * from F_GET_TriTabele();";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        strips.Add(new Tuple<string, string, string>((string)reader[0],(string)reader[1],(string)reader[2]));
                        Console.WriteLine((string)reader[0]);
                    }
                }
                sqlConnection.Close();
            }
            return strips;
        }
    }
}
