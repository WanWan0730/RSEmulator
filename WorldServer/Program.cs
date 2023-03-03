using RSLIB.Network;
using System.Diagnostics;
using WorldServer.Settings;

namespace WorldServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<uint, INetworkPacketAdapter> handlers = new Dictionary<uint, INetworkPacketAdapter>();

            Server login = new Server(Config.SERVER_IP, Config.SERVER_PORT, "RS Emulator | World", 2);
            login.InitializeInterceptor(handlers);

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}