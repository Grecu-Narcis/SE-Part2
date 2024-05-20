using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Database
{
    public class SqlDataAdapterWrapper : ISqlDataAdapterWrapper
    {
        private readonly SqlDataAdapter adapter;

        public SqlDataAdapterWrapper()
        {
            adapter = new SqlDataAdapter();
        }

        public void InsertCommand(SqlCommand command)
        {
            adapter.InsertCommand = command;
        }

        public void Fill(DataSet dataSet)
        {
            adapter.Fill(dataSet);
        }
        public void SelectCommand(SqlCommand command)
        {
            adapter.SelectCommand = command;
        }
        public void ExecuteNonQuery(SqlCommand command)
        {
            if (command.Connection.State != ConnectionState.Open)
            {
                command.Connection.Open();
            }

            command.ExecuteNonQuery();
        }
    }
}
