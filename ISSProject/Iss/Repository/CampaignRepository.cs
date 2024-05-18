using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Iss.Entity;

namespace Iss.Repository
{
    public class CampaignRepository : ICampaignRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public void AddCampaign(Campaign campaignToAdd)
        {
            databaseConnection.OpenConnection();
            string query = "INSERT INTO Campaign(Name, StartDate, Duration, AdAccountID) values (@campaignName, @startDate, @duration, @adAccountID)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@campaignName", campaignToAdd.campaignName);
            command.Parameters.AddWithValue("@startDate", campaignToAdd.startDate);
            command.Parameters.AddWithValue("@duration", campaignToAdd.duration);
            command.Parameters.AddWithValue("@adAccountID", User.User.getInstance().Id);
            dataAdapter.InsertCommand = command;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public Campaign GetCampaignByName(Campaign campaignToGetByName)
        {
            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM Campaign WHERE Name = @campaignName";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@campaignName", campaignToGetByName.campaignName);
            dataAdapter.SelectCommand = command;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                string id = dataRow["ID"].ToString();
                campaignToGetByName.campaignId = id;
            }

            databaseConnection.CloseConnection();
            return campaignToGetByName;
        }

        public void AddAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet)
        {
            databaseConnection.OpenConnection();
            string query = "UPDATE AdSet SET CampaignID = @campaignID WHERE ID = @adSetID";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@campaignID", campaignToAddAdSet.campaignId);
            command.Parameters.AddWithValue("@adSetID", adSet.Id);
            dataAdapter.UpdateCommand = command;
            dataAdapter.UpdateCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void DeleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet)
        {
            databaseConnection.OpenConnection();
            string query = "UPDATE AdSet SET CampaignID = NULL WHERE ID = @adSetID";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@campaignID", campaignToDeleteAdSet.campaignId);
            command.Parameters.AddWithValue("@adSetID", adSet.Id);
            dataAdapter.UpdateCommand = command;
            dataAdapter.UpdateCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void DeleteCampaign(Campaign campaignToDelete)
        {
            databaseConnection.OpenConnection();
            string query = "DELETE FROM Campaign WHERE ID = @adAccountId";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adAccountId", campaignToDelete.campaignId);
            dataAdapter.DeleteCommand = command;
            dataAdapter.DeleteCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void UpdateCampaign(Campaign campaignToUpdate)
        {
            databaseConnection.OpenConnection();
            string query = "UPDATE Campaign SET Name=@name, StartDate=@date, Duration=@duration WHERE ID = @adAccountId";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adAccountId", campaignToUpdate.campaignId);
            command.Parameters.AddWithValue("@name", campaignToUpdate.campaignName);
            command.Parameters.AddWithValue("@date", campaignToUpdate.startDate);
            command.Parameters.AddWithValue("@duration", campaignToUpdate.duration);
            dataAdapter.UpdateCommand = command;
            dataAdapter.UpdateCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }
    }
}
