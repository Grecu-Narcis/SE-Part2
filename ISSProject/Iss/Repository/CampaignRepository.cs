using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Repository
{
    public class CampaignRepository : ICampaignRepository
    {
        DatabaseConnection DatabaseConnection = new DatabaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public void addCampaign(Campaign campaignToAdd)
        {
            DatabaseConnection.OpenConnection();
            string query = "INSERT INTO Campaign(Name, StartDate, Duration, AdAccountID) values (@campaignName, @startDate, @duration, @adAccountID)";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@campaignName", campaignToAdd.campaignName);
            command.Parameters.AddWithValue("@startDate", campaignToAdd.startDate);
            command.Parameters.AddWithValue("@duration", campaignToAdd.duration);
            command.Parameters.AddWithValue("@adAccountID", User.User.getInstance().Id);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public Campaign getCampaignByName(Campaign campaignToGetByName)
        {
            DataSet dataSet = new DataSet();
            DatabaseConnection.OpenConnection();
            string query = "SELECT * FROM Campaign WHERE Name = @campaignName";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@campaignName", campaignToGetByName.campaignName);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            adapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                string id = dataRow["ID"].ToString();
                campaignToGetByName.campaignId = id;
            }

            DatabaseConnection.CloseConnection();
            return campaignToGetByName;
        }

        public void addAdSetToCampaign(Campaign campaignToAddAdSet, AdSet adSet)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE AdSet SET CampaignID = @campaignID WHERE ID = @adSetID";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@campaignID", campaignToAddAdSet.campaignId);
            command.Parameters.AddWithValue("@adSetID", adSet.Id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void deleteAdSetFromCampaign(Campaign campaignToDeleteAdSet, AdSet adSet)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE AdSet SET CampaignID = NULL WHERE ID = @adSetID";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@campaignID", campaignToDeleteAdSet.campaignId);
            command.Parameters.AddWithValue("@adSetID", adSet.Id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void deleteCampaign(Campaign campaignToDelete)
        {
            DatabaseConnection.OpenConnection();
            string query = "DELETE FROM Campaign WHERE ID = @adAccountId";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adAccountId", campaignToDelete.campaignId);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }

        public void updateCampaign(Campaign campaignToUpdate)
        {
            DatabaseConnection.OpenConnection();
            string query = "UPDATE Campaign SET Name=@name, StartDate=@date, Duration=@duration WHERE ID = @adAccountId";
            SqlCommand command = new SqlCommand(query, DatabaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adAccountId", campaignToUpdate.campaignId);
            command.Parameters.AddWithValue("@name", campaignToUpdate.campaignName);
            command.Parameters.AddWithValue("@date", campaignToUpdate.startDate);
            command.Parameters.AddWithValue("@duration", campaignToUpdate.duration);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            DatabaseConnection.CloseConnection();
        }
    }
}
