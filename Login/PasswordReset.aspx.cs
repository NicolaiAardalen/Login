using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace Login
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        private BLayer db = new BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUser();
            }
        }
        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            string ProtectedString = Request.QueryString["Protect"];
            string Email = Request.QueryString["Email"];
            string NewPassword = ComputeSha256Hash(NewPasswordTextbox.Text);
            if (ProtectedString == null || ProtectedString == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (NewPasswordTextbox.Text == ConfirmPasswordTextbox.Text && ProtectedStringTextbox.Text == ProtectedString)
            {
                db.ChangePassword(NewPassword, Email);
                Message.Text = "Password changed";
                Message.Visible = true;
                ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function() { window.location.replace('Login.aspx'); }, 1000);", true);
            }
            else { Message.Text = "Error"; Message.Visible = true; }
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
        public void CheckUser()
        {
            try
            {
                string EmailFromQueryString = Request.QueryString["Email"].ToLower();
                if (EmailFromQueryString == null)
                {
                    Response.Redirect("Login.aspx");
                }
                string IDFromQueryString = Request.QueryString["ID"];
                string Email = "";
                string ID;

                var GetAllDataFromAccounts = db.GetAllDataFromAccounts();

                foreach (DataRow row in GetAllDataFromAccounts.AsEnumerable())
                {
                    Email = row["Email"].ToString().ToLower();
                    ID = row["ID"].ToString();
                    if (Email != EmailFromQueryString && ID == IDFromQueryString || Email == EmailFromQueryString && ID != IDFromQueryString)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }

                string ProtectedString = Request.QueryString["Protect"];
                if (ProtectedString == null || ProtectedString == "")
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception) { }
        }
    }
}