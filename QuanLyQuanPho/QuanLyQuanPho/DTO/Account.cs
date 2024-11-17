using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DTO
{
    public class Account
    {
        private string userName;
        private string userPassword;
        private string displayName;
        private int accountType;

        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public int AccountType { get => accountType; set => accountType = value; }

        public Account(string userName, string displayName, int accountType, string password = null)
        {
            this.UserName = userName;
            this.UserPassword = password;
            this.DisplayName = displayName;
            this.AccountType = accountType;
        }

        public Account(DataRow row)
        {
            this.UserName = row["UserName"].ToString();
            this.DisplayName = row["DisplayName"].ToString();
            this.AccountType = (int)row["AccountType"];
        }
    }
}
