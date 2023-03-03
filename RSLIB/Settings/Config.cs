using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB.Settings
{
    public static class Config
    {
        public static string GAME_SERVER_IP = "127.0.0.1";
        public static string LOGIN_SERVER_IP = "127.0.0.1";
        public static string WORLD_SERVER_IP = "127.0.0.1";
        public static int GAME_SERVER_PORT = 54631;
        public static int LOGIN_SERVER_PORT = 55661;
        public static int WORLD_SERVER_PORT = 56621;
        public static int CONNECTIONS_LIMIT = 10;
    }
}
