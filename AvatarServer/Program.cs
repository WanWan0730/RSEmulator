using RSLIB;
using System.Diagnostics;
using System.Text;

namespace WorldServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RSEmu | World server";
            Config.servers = new World[Config.IPS.Length];

            for (byte i = 0; i < Config.servers.Length; i++)
            {
                Config.servers[i] = new World(i, Config.IPS[i]);
            }
            Process.GetCurrentProcess().WaitForExit();


        }
    }
}
