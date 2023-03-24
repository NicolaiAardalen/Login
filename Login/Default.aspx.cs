using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace Login
{
    public partial class Default : System.Web.UI.Page
    {
        private BLayer bl = new BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUser();
                WelcomeUser();
            }
        }
        public void WelcomeUser()
        {
            string Username = Request.QueryString["Username"];
            UsernameLabel.Text = Username;
        }
        public void CheckUser()
        {
            var GetAllDataFromAccounts = bl.GetAllDataFromAccounts();
            string ProtectedString = Request.QueryString["Protect"];
            string HashedProtectedStringFrpmDB = "";

            foreach (DataRow row in GetAllDataFromAccounts.AsEnumerable())
            {
                HashedProtectedStringFrpmDB = row["ProtectedString"].ToString();
                if (HashedProtectedStringFrpmDB == ComputeSha256Hash(ProtectedString))
                {
                    break;
                }
            }
            if (ComputeSha256Hash(ProtectedString) != HashedProtectedStringFrpmDB)
            {
                Response.Redirect("Login.aspx");
            }

            string UsernameFromQueryString = Request.QueryString["Username"];
            string IDFromQueryString = Request.QueryString["ID"];
            string Username;
            string ID;

            foreach (DataRow row in GetAllDataFromAccounts.AsEnumerable())
            {
                Username = row["Username"].ToString();
                ID = row["ID"].ToString();
                if (Username != UsernameFromQueryString && ID == IDFromQueryString || Username == UsernameFromQueryString && ID != IDFromQueryString)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}