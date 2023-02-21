using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Database
{
    public class LoginModel : DB
    {
        private string username;
        private string mac_address;
        private string server_name;
        private int client_id;

        private string tableName = "connected_users";

        public LoginModel(string username, string mac_address, string server_name, int clientID)
        {
            this.username = username;
            this.mac_address= mac_address;
            this.server_name = server_name;
            this.client_id = clientID;
            this.SetTable(this.tableName);
        }

        public Boolean IsLoggedIn()
        {
            int count = Select($"username = '{this.username}'").Count;
            if (count > 0)
            {
                return true;
            }
            return false;
        }

        public void RegisterUserLogin()
        {
            Dictionary<string, object> userRegister = new Dictionary<string, object>();
            userRegister.Add("username", username);
            userRegister.Add("mac_address", mac_address);
            userRegister.Add("server_name", server_name);
            userRegister.Add("client_id", client_id);

            Insert(userRegister);
        }
    }
}
