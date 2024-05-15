using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Database
{
    public class SqlCommandWrapper : ISqlCommandWrapper
    {
        private readonly SqlCommand _sqlCommand;
        public SqlCommandWrapper(SqlCommand sqlCommand) {
            _sqlCommand = sqlCommand;
        }
        public int ExecuteScalar()
        {
            return (int)_sqlCommand.ExecuteScalar();
        }
    }
}
