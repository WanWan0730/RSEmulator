using GameServer.Settings;
using System.Diagnostics;

namespace GameServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RSEmu | Game server";
            Config.servers = new Game[Config.IPS.Length];

            for (byte i = 0; i < Config.servers.Length; i++)
            {
                Config.servers[i] = new Game(i, Config.IPS[i]);
            }

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}