using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmpRegd.common
{
    public class DbContext
    {
        public string ConnectionString { get; set; }
        public DbContext(string connecttionString)
        {
            this.ConnectionString = connecttionString;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
