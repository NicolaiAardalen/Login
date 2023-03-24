using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataBaseLayer
{
    public class DBLayer
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);
        public DataTable GetAllDataFromAccounts()
        {
            try
            {
                DataTable Accounts = new DataTable();

                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Accounts", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                Accounts.Load(reader);
                conn.Close();

                return Accounts;

            }
            catch (ArgumentOutOfRangeException) { return null; }
        }
        public DataTable GetAllDataFromAdmin()
        {
            try
            {
                DataTable Accounts = new DataTable();

                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Admin", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                Accounts.Load(reader);
                conn.Close();

                return Accounts;

            }
            catch (ArgumentOutOfRangeException) { return null; }
        }
        public void ChangePassword(string Password, string Email)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE Accounts SET Password = @pw WHERE Email = @em", conn);

                cmd.Parameters.AddWithValue("pw", Password);
                cmd.Parameters.AddWithValue("em", Email);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception) { }
        }
        public void SignUpANewAccoutnt(string Username, string Email, string Password, bool Admin)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO Accounts (Username, Email, Password, Admin) VALUES (@un, @em, @pw, @ad)", conn);

                cmd.Parameters.AddWithValue("un", Username);
                cmd.Parameters.AddWithValue("em", Email);
                cmd.Parameters.AddWithValue("pw", Password);
                cmd.Parameters.AddWithValue("ad", Admin);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception) { }
        }
        public void UpdateProtectedString(string ProtectedString, string ID)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE Accounts SET ProtectedString = @ps WHERE ID = @id", conn);

                cmd.Parameters.AddWithValue("ps", ProtectedString);
                cmd.Parameters.AddWithValue("id", ID);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception) { }
        }
    }
}
