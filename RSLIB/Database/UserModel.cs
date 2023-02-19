using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Database
{
    public class UserModel : DB
    {
        private string username;
        private string password;
        private string table = "users";

        public UserModel(string username, string password)
        {
            this.username = username;
            this.password = password;
            this.SetTable(this.table);
        }

        public Boolean Exists()
        {
            int total = Select($"username = '{this.username}' AND password = '{this.password}'", limit: 1).Count;
            if ( total > 0 ) {
                return true;
            }
            return false;
        }
    }
}
