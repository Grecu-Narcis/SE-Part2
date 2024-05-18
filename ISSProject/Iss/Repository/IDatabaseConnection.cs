﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public interface IDatabaseConnection
    {
        public SqlConnection SqlConnection { get; }
        public void OpenConnection();
        public void CloseConnection();
    }
}
