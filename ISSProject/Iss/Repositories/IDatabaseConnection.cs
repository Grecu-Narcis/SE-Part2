using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IDatabaseConnection
    {
        SqlConnection SqlConnection { get; }
        public void OpenConnection();
        public void CloseConnection();
    }
}
