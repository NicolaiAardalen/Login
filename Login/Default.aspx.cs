using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace Login
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckUser();
                WelcomeUser();
            }
        }
        private BLayer bl = new BLayer();
        public void WelcomeUser()
        {
            string Username = Request.QueryString["Username"];

            UsernameLabel.Text = Username;
        }
        public void CheckUser()
        {
            string ProtectedString = Request.QueryString["Protect"];

            if (ProtectedString == null || ProtectedString == "")
            {
                Response.Redirect("Login.aspx");
            }

            string UsernameFromQueryString = Request.QueryString["Username"];
            string IDFromQueryString = Request.QueryString["ID"];
            string Username = "";
            string ID;

            var GetAllDataFromAccounts = bl.GetAllDataFromAccounts();

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
    }
}