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
    public class AdSetRepository : IAdSetRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        public void AddAdSet(AdSet adSet)
        {
            databaseConnection.OpenConnection();
            string query = "INSERT INTO AdSet(Name, TargetAudience, AdAccountID) values (@name, @targetAudience, @AdAccountID)";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@name", adSet.Name);
            command.Parameters.AddWithValue("@targetAudience", adSet.TargetAudience);
            command.Parameters.AddWithValue("@AdAccountID", User.User.getInstance().Id);
            dataAdapter.InsertCommand = command;
            dataAdapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void DeleteAdSet(AdSet adSet)
        {
            databaseConnection.OpenConnection();
            string query = "DELETE FROM AdSet WHERE ID=@id";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@id", adSet.Id);
            dataAdapter.DeleteCommand = command;
            dataAdapter.DeleteCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void UpdateAdSet(AdSet adSet)
        {
            databaseConnection.OpenConnection();
            string query = "UPDATE AdSet SET Name=@Name, TargetAudience=@audience";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@name", adSet.Name);
            command.Parameters.AddWithValue("@audience", adSet.TargetAudience);
            dataAdapter.UpdateCommand = command;
            dataAdapter.UpdateCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public AdSet GetAdSetByName(AdSet adSet)
        {
            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM AdSet WHERE Name = @name";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@name", adSet.Name);
            dataAdapter.SelectCommand = command;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            dataAdapter.Fill(dataSet);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[0];
                string id = dataRow["ID"].ToString();
                adSet.Id = id;
            }

            databaseConnection.CloseConnection();
            return adSet;
        }

        public void AddAdToAdSet(AdSet adSet, Ad ad)
        {
            databaseConnection.OpenConnection();
            string query = "UPDATE Ad SET AdSetID = @adSetID WHERE ID = @adID";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adSetID", adSet.Id);
            command.Parameters.AddWithValue("@adID", ad.Id);
            dataAdapter.UpdateCommand = command;
            dataAdapter.UpdateCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public void RemoveAdFromAdSet(AdSet adSet, Ad ad)
        {
            databaseConnection.OpenConnection();
            string query = "UPDATE Ad SET AdSetID = NULL WHERE ID = @adID";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@adSetID", adSet.Id);
            command.Parameters.AddWithValue("@adID", ad.Id);
            dataAdapter.UpdateCommand = command;
            dataAdapter.UpdateCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

        public List<AdSet> GetAdSetsThatAreNotInCampaign()
        {
            List<AdSet> adSets = new List<AdSet>();
            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM AdSet WHERE CampaignID IS NULL AND AdAccountID=@id";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@id", User.User.getInstance().Id);
            dataAdapter.SelectCommand = command;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            dataAdapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string id = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string targetAudience = dataRow["TargetAudience"].ToString();
                AdSet adSet = new AdSet(id, name, targetAudience);
                adSets.Add(adSet);
            }
            databaseConnection.CloseConnection();
            return adSets;
        }

        public List<AdSet> GetAdSetsInCampaign(string id)
        {
            List<AdSet> adSets = new List<AdSet>();
            DataSet dataSet = new DataSet();
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM AdSet WHERE CampaignID=@id";
            SqlCommand command = new SqlCommand(query, databaseConnection.SqlConnection);
            command.Parameters.AddWithValue("@id", id);
            dataAdapter.SelectCommand = command;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            dataAdapter.Fill(dataSet);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string adSetId = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string targetAudience = dataRow["TargetAudience"].ToString();
                AdSet adSet = new AdSet(adSetId, name, targetAudience);
                adSets.Add(adSet);
            }
            databaseConnection.CloseConnection();
            return adSets;
        }
    }
}
