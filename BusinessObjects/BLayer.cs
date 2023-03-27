using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLayer;

namespace BusinessLayer
{
    public class BLayer
    {
        private DBLayer dbl = new DBLayer();
        public DataTable GetAllDataFromAccounts()
        {
            return dbl.GetAllDataFromAccounts();
        }
        public DataTable GetAllDataFromAdmin()
        { 
            return dbl.GetAllDataFromAdmin();
        }
            public void ChangePassword(string Password, string Email)
        {
            dbl.ChangePassword(Password, Email);
        }
        public void SignUpANewAccoutnt(string Username, string Email, string Password, bool Admin)
        {
            dbl.SignUpANewAccoutnt(Username, Email, Password, Admin);
        }
        public void UpdateProtectedString(string ProtectedString, bool ProtectedStringUsed, string ID)
        {
            dbl.UpdateProtectedString(ProtectedString, ProtectedStringUsed, ID);
        }
        public void UpdateProtectedStringUsed(bool ProtectedStringUsed, string ID)
        {
            dbl.UpdateProtectedStringUsed(ProtectedStringUsed, ID);
        }
    }
}
