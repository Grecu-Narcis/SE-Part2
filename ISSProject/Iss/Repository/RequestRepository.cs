using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace Iss.Repository
{
    public class RequestRepository: IRequestRepository
    {
        int influencerId;
        List<Request> requests = new List<Request>();


        public RequestRepository()
        {
            this.influencerId = getInfluencerId();
        }

        public int getInfluencerId()
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            databaseConnection.OpenConnection();

            string influencerQuery = "SELECT ID FROM Influencer WHERE Name='Selly'";
            SqlCommand influencerCommand = new SqlCommand(influencerQuery, databaseConnection.sqlConnection);
            int influencerId = Convert.ToInt32(influencerCommand.ExecuteScalar());
            databaseConnection.CloseConnection();
            return influencerId;
        }

        public void addRequest(Request requestToAdd)
        {
            // Add the requestToAdd to the database


            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();

            databaseConnection.OpenConnection();

            string influencerQuery = "SELECT ID FROM Influencer WHERE Name='Selly'";

            SqlCommand influencerCommand = new SqlCommand(influencerQuery, databaseConnection.sqlConnection);
            // Execute the query to get the influencer ID
            int influencerId = Convert.ToInt32(influencerCommand.ExecuteScalar());

            string query = "INSERT INTO Request(AdAccountID, InfluencerID, CollaborationTitle, AdOverview, ContentRequirements, CompensationPackage, InfluencerAccept, AdAccountAccept, StartDate, EndDate) VALUES (@AdAccountID, @InfluencerID, @collaborationTitle, @AdOverview, @contentRequirements, @compensation, @influencerAccept, @adAccountAccept, @startDate, @endDate)";

            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@AdAccountID", User.User.getInstance().Id);
            command.Parameters.AddWithValue("@InfluencerID", influencerId);
            command.Parameters.AddWithValue("@collaborationTitle", requestToAdd.collaborationTitle);
            command.Parameters.AddWithValue("@AdOverview", requestToAdd.adOverview);
            command.Parameters.AddWithValue("@contentRequirements", requestToAdd.contentRequirements);
            command.Parameters.AddWithValue("@compensation", requestToAdd.compensation);
            command.Parameters.AddWithValue("@influencerAccept", requestToAdd.influencerAccept);
            command.Parameters.AddWithValue("@adAccountAccept", requestToAdd.adAccountAccept);
            command.Parameters.AddWithValue("@startDate", requestToAdd.startDate);
            command.Parameters.AddWithValue("@endDate", requestToAdd.endDate);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public List<Request> getRequestsForInfluencer()
        {

            DatabaseConnection databaseConnection = new DatabaseConnection();
            string query = "SELECT * FROM Request WHERE InfluencerID=@influencerId AND InfluencerAccept=@influenceraccept";

            try
            {
                using (SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection))
                {
                    command.Parameters.AddWithValue("@influencerId", this.influencerId);
                    command.Parameters.AddWithValue("@influenceraccept", 0);
                    databaseConnection.OpenConnection();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Request request = new Request(
                                    reader.GetString(reader.GetOrdinal("CollaborationTitle")),
                                    reader.GetString(reader.GetOrdinal("AdOverview")),
                                    reader.GetString(reader.GetOrdinal("ContentRequirements")),
                                    reader.GetString(reader.GetOrdinal("CompensationPackage")),
                                    reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                    reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                    reader.GetBoolean(reader.GetOrdinal("InfluencerAccept")),
                                    reader.GetBoolean(reader.GetOrdinal("AdAccountAccept"))
                                );
                                requests.Add(request);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                databaseConnection.CloseConnection();
            }

            return requests;
        }


        public void deleteRequest(Request requestToDelete)
        {
            // Delete the requestToAdd from the database
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            databaseConnection.OpenConnection();
            string query = "DELETE FROM Request WHERE CollaborationTitle=@collaborationTitle";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@collaborationTitle", requestToDelete.collaborationTitle);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();

        }

        public List<Request> getRequestsList()
        {
            return this.requests;
        }

        public List<Request> getRequestsForAdAccount()
        {
            DatabaseConnection databaseConnection = new DatabaseConnection();
            string query = "SELECT * FROM Request WHERE AdAccountID=@adAccountId AND AdAccountAccept=@adAccountAccept";

            try
            {
                using (SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection))
                {
                    command.Parameters.AddWithValue("@adAccountId", User.User.getInstance().Id);
                    command.Parameters.AddWithValue("@adAccountAccept", 0);
                    databaseConnection.OpenConnection();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Request request = new Request(
                                    reader.GetString(reader.GetOrdinal("CollaborationTitle")),
                                    reader.GetString(reader.GetOrdinal("AdOverview")),
                                    reader.GetString(reader.GetOrdinal("ContentRequirements")),
                                    reader.GetString(reader.GetOrdinal("CompensationPackage")),
                                    reader.GetDateTime(reader.GetOrdinal("StartDate")),
                                    reader.GetDateTime(reader.GetOrdinal("EndDate")),
                                    reader.GetBoolean(reader.GetOrdinal("InfluencerAccept")),
                                    reader.GetBoolean(reader.GetOrdinal("AdAccountAccept")));
                                requests.Add(request);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                databaseConnection.CloseConnection();
            }

            return requests;
        }

        public void updateRequest(Request requestToUpdate)
        {
            //update only compensation, content requirements and acceptance status
            DatabaseConnection databaseConnection = new DatabaseConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            databaseConnection.OpenConnection();
            // update the requestToAdd in the database with the new compensation, content requirements and acceptance status
            string query = "UPDATE Request SET CompensationPackage=@compensation, ContentRequirements=@contentRequirements, InfluencerAccept=@influencerAccept, AdAccountAccept=@adAccountAccept WHERE CollaborationTitle=@collaborationTitle";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@compensation", requestToUpdate.compensation);
            command.Parameters.AddWithValue("@contentRequirements", requestToUpdate.contentRequirements);
            command.Parameters.AddWithValue("@influencerAccept", requestToUpdate.influencerAccept);
            command.Parameters.AddWithValue("@adAccountAccept", requestToUpdate.adAccountAccept);
            command.Parameters.AddWithValue("@collaborationTitle", requestToUpdate.collaborationTitle);
            command.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }
    }
}
