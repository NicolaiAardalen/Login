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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private BLayer db = new BLayer();
        protected void Login_Click(object sender, EventArgs e)
        {
            var GetAllDataFromBildeOgPassord = db.GetAllDataFromAccounts();
            int ID;
            var Username = "";
            var Email = "";
            var Password = "";

            string lettersString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            char[] letters = lettersString.ToCharArray();
            Random random = new Random();
            string ProtectedString = "";
            for (int i = 0; i < 50; i++)
            {
                ProtectedString += letters[random.Next(0, 60)];
            }

            foreach (DataRow row in GetAllDataFromBildeOgPassord.AsEnumerable())
            {
                ID = int.Parse(row["ID"].ToString());
                Email = row["Email"].ToString().ToLower();
                Password = row["Password"].ToString();
                Username = HttpUtility.UrlEncode(row["Username"].ToString());
                string HashedPasswordFromTextbox = ComputeSha256Hash(PasswordTextbox.Text);
                if (HashedPasswordFromTextbox == Password && Email == EmailTextbox.Text.ToLower())
                {
                    FormsAuthentication.RedirectFromLoginPage(HashedPasswordFromTextbox, false);
                    Response.Redirect($"Default.aspx?ID={ID}&username={Username}&Protect={ProtectedString}");
                }
                else
                {
                    WrongPassword.Visible = true;
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
        protected void ForgotPassword_Click(object sender, EventArgs e)
        {
            string Email = HttpUtility.UrlEncode(EmailTextbox.Text);
            Response.Redirect($"ResetLinkToEmail.aspx?Email={Email}");
        }
        protected void SignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}