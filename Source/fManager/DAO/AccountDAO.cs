using fManager.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace fManager.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO(); return instance;
            }

            private set
            {
                instance = value;
            }
        
        }
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName FROM dbo.Account");
        }
        private AccountDAO() { }
        public bool Login (string userName , string passWord)
        {
            
            //var list = hasData.ToString();
            //list.Reverse();

            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName , passWord });
            return result.Rows.Count>0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Account WHERE UserName =' " + userName+"'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);

            }
            return null;
            
        }
        public bool InsertAccount(string name, string displayName)
        {
            string query = string.Format("INSERT dbo.Account ( UserName, DisplayName )VALUES  ( N'{0}', N'{1}')", name, displayName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateAccount(string name, string displayName)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{1}' WHERE UserName = N'{0}'", name, displayName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {  
            string query = string.Format("Delete Account where UserName = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        
    }
}
