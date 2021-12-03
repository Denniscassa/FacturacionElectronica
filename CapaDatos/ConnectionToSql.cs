using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;


namespace CapaDatos
{
    public abstract class  ConnectionToSql
    {
        public static string cn = "Data Source= DESKTOP-O080QAR/SQLEXPRESS ; Initial Catalog=db_topnevel; Integrated Security=true";

/*         private readonly string connectionString;

        public ConnectionToSql()
        {
            connectionString  = "Data Source= DESKTOP-O080QAR\\SQLEXPRESS ; Initial Catalog=MyCompany; Integrated Security=true";
        }

        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
*/
    }
}
