using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login
{
    public partial class Login : System.Web.UI.Page
    {
        private BLayer bl = new BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            var GetAllDataFromAccounts = bl.GetAllDataFromAccounts();
            string ID;
            string Username;
            string Email;
            string Password;
            string ProtectedString;

            string CharactersString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_";
            char[] Characters = CharactersString.ToCharArray();
            Random random = new Random();
            string newProtectedString = "";
            for (int i = 0; i < 50; i++)
            {
                newProtectedString += Characters[random.Next(0, 63)];
            }

            string HashedenewProtectedString = ComputeSha256Hash(newProtectedString);

            foreach (DataRow row in GetAllDataFromAccounts.AsEnumerable())
            {
                ID = row["ID"].ToString();
                Email = row["Email"].ToString().ToLower();
                Password = row["Password"].ToString();
                Username = row["Username"].ToString();
                ProtectedString = row["ProtectedString"].ToString();

                string HashedPasswordFromTextbox = ComputeSha256Hash(PasswordTextbox.Text);

                if (HashedPasswordFromTextbox == Password && Email == UsernameOrEmailTextbox.Text.ToLower() || HashedPasswordFromTextbox == Password && Username == UsernameOrEmailTextbox.Text)
                {
                    FormsAuthentication.RedirectFromLoginPage(HashedPasswordFromTextbox, false);
                    bl.UpdateProtectedString(HashedenewProtectedString, ID);
                    Response.Redirect($"Default.aspx?ID={ID}&username={Username}&Protect={newProtectedString}");
                }
            }
            WrongPassword.Visible = true;
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
        protected void ForgotPassword_Click(object sender, EventArgs e)
        {
            var GetAllDataFromAccounts = bl.GetAllDataFromAccounts();
            string Email = UsernameOrEmailTextbox.Text;
            string EncodeedEmail = HttpUtility.UrlEncode(Email);
            string UsernameFromDB;

            foreach (DataRow row in GetAllDataFromAccounts.AsEnumerable())
            {
                UsernameFromDB = row["Username"].ToString();
                if (UsernameFromDB == Email)
                {
                    Response.Redirect("ResetLinkToEmail.aspx");
                }
            }
            Response.Redirect($"ResetLinkToEmail.aspx?Email={EncodeedEmail}");
        }
        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}