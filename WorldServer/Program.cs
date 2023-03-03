using RSLIB.Network;
using System.Diagnostics;
using WorldServer.Settings;

namespace WorldServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RSEmu | World server";
            Config.servers = new World[Config.IPS.Length];

            for (byte i = 0; i < Config.servers.Length; i++)
            {
                Config.servers[i] = new World(i, Config.IPS[i]);
            }


            //Server xpto = new Server()

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}