using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Iss.Repository
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public static string ConnectionString = "Data Source = NARCIS\\SQLEXPRESS02; Initial Catalog = db_ISS; Integrated Security = True; TrustServerCertificate=True;";

        public SqlConnection sqlConnection { get; private set; } =  new SqlConnection(ConnectionString);



        

        public virtual void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public virtual void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
     
    }
}
