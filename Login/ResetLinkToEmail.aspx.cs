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
            string lettersString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";
            char[] letters = lettersString.ToCharArray();
            Random random = new Random();
            string ProtectedString = "";
            for (int i = 0; i < 50; i++)
            {
                ProtectedString += letters[random.Next(0, 60)];
            }

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
            message.Body = $"Click the link to reset your password: https://localhost:44395/PasswordReset.aspx?ID={ID}&Email={Email}&Protect={ProtectedString} \nCopy this line, and paste it in the \"Portected field\" on the site: {HttpUtility.UrlEncode(ProtectedString)}";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new NetworkCredential("Ialocin3459@gmail.com", "oeeucxjyaibrojwi");

            smtpClient.EnableSsl = true;

            smtpClient.Send(message);
            ClientScript.RegisterStartupScript(this.GetType(), "redirectScript", "setTimeout(function() { window.location.replace('Login.aspx'); }, 1000);", true);
        }

        protected void BackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}