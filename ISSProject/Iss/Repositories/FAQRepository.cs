// <copyright file="FAQRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backend.Models;
using Backend.Services;

namespace Backend.Repositories
{
    public class FAQRepository : IFAQRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private readonly SqlDataAdapter adapter = new SqlDataAdapter();

        public List<FAQ> GetFAQList()
        {
            List<FAQ> listOfFAQ = new List<FAQ>();
            databaseConnection.OpenConnection();
            string query = "select * from FAQ";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                FAQ faq = new FAQ
                {
                    Id = (int)reader["id"],
                    Question = (string)reader["Question"],
                    Answer = (string)reader["Answer"],
                    Topic = (string)reader["Topic"]
                };
                listOfFAQ.Add(faq);
            }
            reader.Close();
            databaseConnection.CloseConnection();
            return listOfFAQ;
        }

        public void AddFAQ(Backend.Models.FAQ newQuestion)
        {
            databaseConnection.OpenConnection();
            string query = "INSERT INTO FAQ (Question, Answer, Topic) VALUES (@question, @answer, @topic)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@question", newQuestion.Question);
            command.Parameters.AddWithValue("@answer", newQuestion.Answer);
            command.Parameters.AddWithValue("@topic", newQuestion.Topic);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void DeleteFAQ(Backend.Models.FAQ updatedQuestion)
        {
            databaseConnection.OpenConnection();
            string query = "UPDATE FAQ SET Question = @question, Answer = @answer, Topic = @topic WHERE Id = @id";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@question", updatedQuestion.Question);
            command.Parameters.AddWithValue("@answer", updatedQuestion.Answer);
            command.Parameters.AddWithValue("@topic", updatedQuestion.Topic);
            command.Parameters.AddWithValue("@id", updatedQuestion.Id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }
    }
}
