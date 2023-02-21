using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginServer.Settings
{
    public static class Config
    {
        public static Login[]? servers = null;
        public static string[] IPS = {
            "127.0.0.1"
        };
        public static string SERVER_NAME = "Prandel";
        public static int SERVER_PORT = 55661;
        public static Int32 MAX_CONNECTIONS = 100;
    }
}
