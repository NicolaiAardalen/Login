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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        private BLayer bl = new BLayer();
        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string Username = UsernameTextBox.Text;
            string Email = EmailTextBox.Text;
            string Password = ComputeSha256Hash(PasswordTextBox.Text);
            bool Admin = false;
            string AdminPassword = "";
            string HashedAdminPasswordFromTextbox = ComputeSha256Hash(AdminTextbox.Text);

            var GetAllDataFromAdmin = bl.GetAllDataFromAdmin();

            foreach (DataRow row in GetAllDataFromAdmin.AsEnumerable())
            {
                AdminPassword = row["AdminPassword"].ToString();
            }

            if (HashedAdminPasswordFromTextbox == AdminPassword)
            {
                Admin = true;
            }

            bl.SignUpANewAccoutnt(Username, Email, Password, Admin);
            ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function() { window.location.replace('Login.aspx'); }, 1000);", true);
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

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}