using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCF.Data
{
    class Db
    {
        public static readonly string ConnectionString =
            @"Data Source=DOHAI\SQLEXPRESS;Initial Catalog=QLCF;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
