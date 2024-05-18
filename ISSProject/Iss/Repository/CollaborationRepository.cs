﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Database;
using Iss.Entity;

namespace Iss.Repository
{
    internal class CollaborationRepository : IColaborationRepository
    {
        private IDatabaseConnection databaseConnection;
        private ISqlDataAdapterWrapper adapter;

        public CollaborationRepository()
        {
            databaseConnection = new DatabaseConnection();
            adapter = new SqlDataAdapterWrapper();
        }
        public CollaborationRepository(IDatabaseConnection databaseConnection, ISqlDataAdapterWrapper adapter)
        {
            this.databaseConnection = databaseConnection;
            this.adapter = adapter;
        }

        public void CreateCollaboration(Collaboration collaboration)
        {
            databaseConnection.OpenConnection();

            string influencerQuery = "SELECT ID FROM Influencer WHERE Name='Selly'";

            SqlCommand influencerCommand = new SqlCommand(influencerQuery, databaseConnection.SqlConnection);
            // Execute the query to get the influencer ID
            int influencerId = Convert.ToInt32(influencerCommand.ExecuteScalar());

            string query = @"INSERT INTO Collaboration (AdAccountID, InfluencerID, Status, AdOverview, CollaborationTitle, ContentRequirements, CollaborationFee,  StartDate, EndDate) 
                                VALUES (@AdAccountID, @InfluencerID, @Status, @AdOverview, @CollaborationTitle, @ContentRequirements, @CollaborationFee, @StartDate, @EndDate)";

            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@AdAccountID", User.User.getInstance().Id);
            command.Parameters.AddWithValue("@InfluencerID", influencerId);
            command.Parameters.AddWithValue("@Status", collaboration.status);
            command.Parameters.AddWithValue("@AdOverview", collaboration.adOverview);
            command.Parameters.AddWithValue("@ContentRequirements", collaboration.contentRequirement);
            command.Parameters.AddWithValue("@CollaborationTitle", collaboration.collaborationTitle);
            command.Parameters.AddWithValue("@CollaborationFee", collaboration.collaborationFee);
            command.Parameters.AddWithValue("@StartDate", collaboration.startDate);
            command.Parameters.AddWithValue("@EndDate", collaboration.endDate);

            adapter.InsertCommand(command);
            adapter.ExecuteNonQuery(command);
            databaseConnection.CloseConnection();
        }

        public List<Collaboration> GetCollaborationsForAdAccount()
        {
            List<Collaboration> collaborations = new List<Collaboration>();
            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();

            string query = "SELECT * FROM Collaboration WHERE AdAccountID = @AdAccountID";

            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            System.Diagnostics.Debug.WriteLine(User.User.getInstance().Id);
            command.Parameters.AddWithValue("@AdAccountID", User.User.getInstance().Id);

            // Set the SelectCommand property of the SqlDataAdapter
            adapter.SelectCommand(command);
            adapter.ExecuteNonQuery(command);

            // Remove unnecessary code that sets InsertCommand and calls ExecuteNonQuery
            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                collaborations.Add(new Collaboration(Convert.ToInt32(dataRow["CollaborationID"]),
                    Convert.ToDateTime(dataRow["StartDate"]), Convert.ToBoolean(dataRow["Status"]),
                    dataRow["ContentRequirements"].ToString(), dataRow["AdOverview"].ToString(),
                    dataRow["CollaborationFee"].ToString(), Convert.ToDateTime(dataRow["EndDate"]).Day - Convert.ToDateTime(dataRow["StartDate"]).Day,
                    dataRow["CollaborationTitle"].ToString()));
            }

            databaseConnection.CloseConnection();
            return collaborations;
        }

        public List<Collaboration> GetCollaborationsForInfluencer()
        {
            List<Collaboration> collaborations = new List<Collaboration>();
            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();

            string query = "SELECT * FROM Collaboration WHERE InfluencerID = @InfluencerID";

            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);

            System.Diagnostics.Debug.WriteLine(User.User.getInstance().Id);
            command.Parameters.AddWithValue("@InfluencerID", 1);

            // Set the SelectCommand property of the SqlDataAdapter
            adapter.SelectCommand(command);
            adapter.ExecuteNonQuery(command);

            // Remove unnecessary code that sets InsertCommand and calls ExecuteNonQuery
            adapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                collaborations.Add(new Collaboration(Convert.ToInt32(dataRow["CollaborationID"]),
                Convert.ToDateTime(dataRow["StartDate"]), Convert.ToBoolean(dataRow["Status"]),
                dataRow["ContentRequirements"].ToString(), dataRow["AdOverview"].ToString(),
                dataRow["CollaborationFee"].ToString(), Convert.ToDateTime(dataRow["EndDate"]).Day - Convert.ToDateTime(dataRow["StartDate"]).Day,
                dataRow["CollaborationTitle"].ToString()));
            }

            databaseConnection.CloseConnection();
            return collaborations;
        }
    }
}
