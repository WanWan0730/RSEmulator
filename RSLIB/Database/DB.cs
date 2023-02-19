using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Database
{
    public class DB
    {
        private string host = "localhost";
        private string user = "root";
        private string password = "myrootpassword";
        private string database = "redstone";
        private int port = 3306;

        public MySqlConnection connection;

        public DB()
        {
            string con = $"server={host};database={database};port={port};uid={user};pwd={password}";
            try
            {
                if (this.connection == null)
                {
                    this.connection = new MySqlConnection(con);
                    this.connection.Open();
                    Log.Success("Connected to the database with success");
                }
            }
            catch(Exception ex) {
                Log.Error($"{ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
