using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using BusinessLayer;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Login
{
    public partial class ResetLinkToEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EmailInTextbox();
            }
        }
        private BLayer bl = new BLayer();
        public void EmailInTextbox()
        {
            string Email = Request.QueryString["Email"];
            EmailTextbox.Text = Email;
        }

        protected void SendEmailLink_Click(object sender, EventArgs e)
        {
            string CharactersString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_";
            char[] Characters = CharactersString.ToCharArray();
            Random random = new Random();
            string newProtectedString = "";
            for (int i = 0; i < 50; i++)
            {
                newProtectedString += Characters[random.Next(0, 63)];
            }

            string HashedenewProtectedString = ComputeSha256Hash(newProtectedString);

            string Email = EmailTextbox.Text;
            string EmailFromDB = "";
            string ID = "";

            var GetAllDataFromAccounts = bl.GetAllDataFromAccounts();
            foreach (DataRow row in GetAllDataFromAccounts.AsEnumerable())
            {
                EmailFromDB = row["Email"].ToString();
                ID = row["ID"].ToString();
                if (Email.ToLower() == EmailFromDB.ToLower())
                {
                    break;
                }
            }

            MailMessage message = new MailMessage();

            message.From = new MailAddress("Ialocin3459@gmail.com");
            message.To.Add(Email);

            message.Subject = "Password reset";
            message.Body = $"Click the link to reset your password: https://localhost:44395/PasswordReset.aspx?ID={ID}&Email={Email}&Protect={newProtectedString} \nCopy this line, and paste it in the \"Portected field\" on the site: {newProtectedString}";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new NetworkCredential("Ialocin3459@gmail.com", "oeeucxjyaibrojwi");

            smtpClient.EnableSsl = true;

            smtpClient.Send(message);
            bl.UpdateProtectedString(HashedenewProtectedString, ID);
            ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function() { window.location.replace('Login.aspx'); }, 1000);", true);
        }

        protected void BackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
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