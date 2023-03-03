using GameServer.Packets.Receive;
using RSLIB.Network;
using System.Diagnostics;
using RSLIB.Settings;

namespace GameServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<uint, INetworkPacketAdapter> handlers = new Dictionary<uint, INetworkPacketAdapter>();

            handlers.Add(4129, new AccountJoinGameRequest());
            handlers.Add(4287, new RequestJoinGameResponse());
            handlers.Add(4130, new MapInfoRequestPacket());
            handlers.Add(4257, new AvatarInfoPacketResponse());
            handlers.Add(4132, new UnknowWalkPacketResponse());
            handlers.Add(4131, new MovementPacket());
            handlers.Add(4135, new TurnOnRunPacketResponse());
            handlers.Add(4136, new UpdateObjectsPacket());
            handlers.Add(4137, new LocalMessageRequestPacket());

            Server game = new Server(Config.GAME_SERVER_IP, Config.GAME_SERVER_PORT, "RS Emulator | Game", Config.CONNECTIONS_LIMIT);
            game.InitializeInterceptor(handlers);

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}