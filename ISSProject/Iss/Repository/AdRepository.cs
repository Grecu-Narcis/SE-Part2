using Iss.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Iss.Repository
{
    internal class AdRepository : IAdRepository
    {
        DatabaseConnection databaseConnection = new DatabaseConnection();
        SqlDataAdapter adapter = new SqlDataAdapter();
        string AdAcountId = User.User.getInstance().Id;

        public AdRepository() { }
        public AdRepository(string AdAcountId)
        {
            this.AdAcountId = AdAcountId;
        }

        public void addAd(Ad adToAdd)
        {
            databaseConnection.OpenConnection();
            string query = "INSERT INTO Ad(Name,Description,Url,AdAccountID,Photo) values (@name, @description, @url, @adAccountId,@photo)";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@name", adToAdd.ProductName);
            command.Parameters.AddWithValue("@description", adToAdd.Description);
            command.Parameters.AddWithValue("@url", adToAdd.WebsiteLink);
            command.Parameters.AddWithValue("@photo", adToAdd.Photo);
            command.Parameters.AddWithValue("@adAccountId", AdAcountId);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();

        }

        public Ad getAdByName(string adName)
        {
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM Ad WHERE Name=@Name";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@Name", adName);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            List<Ad> ads = new List<Ad>();
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                // No result found, return null
                return null;
            }
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string id = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string description = dataRow["Description"].ToString();
                string url = dataRow["Url"].ToString();
                string photo = dataRow["Photo"].ToString();
                Ad ad = new Ad(id, name, photo, description, url);
                ads.Add(ad);
            }
            databaseConnection.CloseConnection();
            return ads[0];
        }

        public List<Ad> getAdsThatAreNotInAdSet() 
        { 
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM Ad WHERE AdSetID IS NULL AND AdAccountID = @adAccountId";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adAccountId", AdAcountId);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            List<Ad> ads = new List<Ad>();
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string id = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string description = dataRow["Description"].ToString();
                string url = dataRow["Url"].ToString();
                string photo = dataRow["Photo"].ToString();
                Ad ad = new Ad(id, name, photo, description, url);
                ads.Add(ad);
            }
            databaseConnection.CloseConnection();
            return ads;
        }

        public List<Ad> getAdsForAdSet(string adSetId)
        {
            databaseConnection.OpenConnection();
            string query = "SELECT * FROM Ad WHERE AdAccountID = @adAccountId AND AdSetID = @id";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@adAccountId", AdAcountId);
            command.Parameters.AddWithValue("@id", adSetId);
            adapter.SelectCommand = command;
            adapter.SelectCommand.ExecuteNonQuery();
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            List<Ad> ads = new List<Ad>();
            foreach (DataRow dataRow in dataSet.Tables[0].Rows)
            {
                string ID = dataRow["ID"].ToString();
                string name = dataRow["Name"].ToString();
                string description = dataRow["Description"].ToString();
                string url = dataRow["Url"].ToString();
                string photo = dataRow["Photo"].ToString();
                Ad ad = new Ad(ID, name, photo, description, url);
                ads.Add(ad);
            }
            databaseConnection.CloseConnection();
            return ads;
        }

        public void updateAd(Ad adToUpdate)
        {
            databaseConnection.OpenConnection();
            string query = "UPDATE Ad SET Name = @name, Description = @description, Url = @url, Photo=@photo WHERE ID = @id";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@name", adToUpdate.ProductName);
            command.Parameters.AddWithValue("@description", adToUpdate.Description);
            command.Parameters.AddWithValue("@url", adToUpdate.WebsiteLink);
            command.Parameters.AddWithValue("@photo", adToUpdate.Photo);
            command.Parameters.AddWithValue("@id", adToUpdate.Id);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            //MessageBox.Show(ad.id);
            databaseConnection.CloseConnection();
        }

        public void deleteAd(Ad adToDelete)
        {
            string query = "DELETE FROM Ad WHERE ID = @Id";
            SqlCommand command = new SqlCommand(query, databaseConnection.sqlConnection);
            command.Parameters.AddWithValue("@Id", this.getAdByName(adToDelete.ProductName).Id);
            adapter.DeleteCommand = command;
            databaseConnection.OpenConnection();
            adapter.DeleteCommand.ExecuteNonQuery();
            databaseConnection.CloseConnection();
        }

    }
}
