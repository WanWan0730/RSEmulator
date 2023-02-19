using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Database
{
    public class UserModel : DB
    {
        private string username;
        private string password;

        public UserModel(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Boolean IsLoggedIn() {
            MySqlCommand query = new MySqlCommand($"SELECT * FROM connected_users WHERE username = '{this.username}' LIMIT 1", connection);
            int count = query.ExecuteReader().RecordsAffected;
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public void RegisterUserLogin()
        {
            connection.ClearAllPoolsAsync();
            MySqlCommand query = new MySqlCommand($"INSERT INTO connected_users (username, password) VALUES ('{this.username}', '{this.password}')", connection);
            query.ExecuteNonQuery();
        }
    }
}
