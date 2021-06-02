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
    public class Procedure
    {
        public static void P_INS_Festival(string ime,int god)
        {
            using (var db = new BpProjekatModelContext())
            {
                db.Database.SqlQuery<BpProjekatModelContext>("EXEC P_INS_Festival '" + ime + "'," + god + ";").ToList();
            }
        }

        public static string P_SEL_Ime(int id)
        {
            var P_Ime = new SqlParameter("@P_Ime",SqlDbType.NVarChar,20);
            P_Ime.Direction = ParameterDirection.Output;
            string ime = "";
            using (var db = new BpProjekatModelContext())
            {
                var query = db.Database.ExecuteSqlCommand("EXEC P_SEL_Ime @P_Id, @P_Ime OUT;",new SqlParameter("@P_Id",id), P_Ime);
                ime = P_Ime.Value.ToString();
            }
            return ime;
        }

        public static string P_StripoviPoKategoriji(int id)
        {
            string str = "";
            var i = new SqlParameter("@i", SqlDbType.VarChar, 100);
            i.Direction = ParameterDirection.Output;
            using (var db = new BpProjekatModelContext())
            {
                var query = db.Database.ExecuteSqlCommand("EXEC P_StripoviPoKategoriji @P_Id, @i OUT;", new SqlParameter("@P_Id", id), i);
                str = i.Value.ToString();
            }
            return str;
        }
    }
}
