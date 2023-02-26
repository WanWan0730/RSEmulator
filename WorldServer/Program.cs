using RSLIB;
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

            Skill teste = new Skill();



            for (byte i = 0; i < Config.servers.Length; i++)
            {
                Config.servers[i] = new World(i, Config.IPS[i]);
            }

            Process.GetCurrentProcess().WaitForExit();
        }
    }
}