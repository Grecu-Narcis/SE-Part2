// <copyright file="TODORepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Backend.Models;
    using Backend.Services;

    public class TODORepository : INterfaceToDoRepository<TODOClass>
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private readonly SqlDataAdapter adapter = new SqlDataAdapter();

        public void AddingTODO(TODOClass newTODO)
        {
            databaseConnection.OpenConnection();
            string query = "INSERT INTO TODOs (Task) VALUES (@task)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@task", newTODO.Task);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void RemovingTODO(TODOClass newTODO)
        {
            databaseConnection.OpenConnection();
            string query = "DELETE FROM TODOs WHERE ID = @id";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@id", newTODO.ID);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public List<TODOClass> GetTODOS()
        {
            List<TODOClass> todosList = new List<TODOClass>();
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM TODOs";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                TODOClass todo = new TODOClass
                {
                    ID = (int)reader["ID"],
                    Task = (string)reader["Task"]
                };
                todosList.Add(todo);
            }

            reader.Close();
            databaseConnection.CloseConnection();
            return todosList;
        }
    }
}
