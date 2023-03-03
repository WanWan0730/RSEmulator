using RSLIB.Network;
using System.Diagnostics;
using RSLIB.Settings;

namespace WorldServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<uint, INetworkPacketAdapter> handlers = new Dictionary<uint, INetworkPacketAdapter>();

            Server world = new Server(Config.WORLD_SERVER_IP, Config.WORLD_SERVER_PORT, "RS Emulator | World", Config.CONNECTIONS_LIMIT);
            world.InitializeInterceptor(handlers);

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}