using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Database
{
    public class SqlCommandWrapper : ISqlCommandWrapper
    {
        private readonly SqlCommand sqlCommand;
        public SqlCommandWrapper(SqlCommand sqlCommand)
        {
            this.sqlCommand = sqlCommand;
        }
        public int ExecuteScalar()
        {
            return (int)sqlCommand.ExecuteScalar();
        }
    }
}
