using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Settings
{
    public static class Config
    {
        public static Game[]? servers = null;
        public static string[] IPS = {
            "127.0.0.1"
        };
        public static int SERVER_PORT = 54631;
        public static Int32 MAX_CONNECTIONS = 100;
    }
}
