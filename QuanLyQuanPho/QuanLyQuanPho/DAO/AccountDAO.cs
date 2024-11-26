using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanPho.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
            private set => instance = value;
        }

        private AccountDAO() { }

        public bool Login(string username, string password)
        {

            string query = @"EXEC USP_Login @UserName , @Password ";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { username, password });

            return result.Rows.Count > 0;
        }

        public DataTable GetAccountByUserName(string userName)
        {
            string query = @"EXEC USP_GetAccountByUserName @UserName ";
            return DataProvider.Instance.ExcuteQuery(query, new object[] { userName });
        }
    
        public bool UpdateAccountByUserNameAndPassword(string userName, string displayName, string password, string newPassword = null)
        {
            string query = @"EXEC USP_UpdateAccountByUserNameAndPassword @UserName , @DisplayName , @Password , @NewPassword ";
            if (DataProvider.Instance.ExcuteNonQuery(query, new object[] { userName, displayName, password, newPassword }) > 0 )
            {
                return true;
            }
            return false;
        }
    
        public DataTable GetAccountList()
        {
            string query = @"EXEC GetAccountList";
            return DataProvider.Instance.ExcuteQuery(query);
        }

        public bool AddNewAccount(string userName, string displayName, int accountType)
        {
            string query = @"EXEC USP_AddNewAccount @UserName , @DisplayName , @AccountType ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { userName, displayName, accountType });
            return result > 0;
        }

        public bool UpdateAccount(string userName, string displayName, int accountType)
        {
            string query = @"EXEC USP_UpdateAccount @UserName , @DisplayName , @AccountType ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { userName, displayName, accountType });
            return result > 0;
        }

        public bool DeleteAccount(string userName)
        {
            string query = @"EXEC USP_DeleteAccount @UserName ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { userName });
            return result > 0;
        }

        public bool ResetPassword(string userName)
        {
            string query = @"EXEC USP_ResetPassword @UserName ";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { userName });
            return result > 0;
        }
    }
}
