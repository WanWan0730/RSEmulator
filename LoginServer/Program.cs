using LoginServer.Packets.Send;
using LoginServer.Settings;
using RSLIB;
using RSLIB.Network;
using System.Diagnostics;
using System.Text;

namespace LoginServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RSEmu | Login server";

            Dictionary<uint, INetworkPacketAdapter> handlers = new Dictionary<uint, INetworkPacketAdapter>();

            handlers.Add(4096, new ServerListPacket());
            handlers.Add(4097, new LoginPacket());
            handlers.Add(4100, new CharacterCreatePacket());
            handlers.Add(4101, new CharacterDeletePacket());
            handlers.Add(4102, new SendCharacterToWorld());

            Server login = new Server("127.0.0.1", 55661, "Login", 2);
            login.InitializeInterceptor(handlers);

            Process.GetCurrentProcess().WaitForExit();
        }

    }
}