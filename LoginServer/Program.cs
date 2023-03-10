using LoginServer.Packets.Send;
using RSLIB;
using RSLIB.Network;
using System.Diagnostics;
using System.Text;
using RSLIB.Settings;

namespace LoginServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<uint, INetworkPacketAdapter> handlers = new Dictionary<uint, INetworkPacketAdapter>();

            handlers.Add(4096, new ServerListPacket());
            handlers.Add(4103, new ServerListPacket());
            handlers.Add(4097, new LoginPacket());
            handlers.Add(4100, new CharacterCreatePacket());
            handlers.Add(4101, new CharacterDeletePacket());
            handlers.Add(4102, new SendCharacterToWorld());

            Server login = new Server(Config.LOGIN_SERVER_IP, Config.LOGIN_SERVER_PORT, "RS Emulator | Login", Config.CONNECTIONS_LIMIT);
            login.InitializeInterceptor(handlers);

            Process.GetCurrentProcess().WaitForExit();
        }

    }
}