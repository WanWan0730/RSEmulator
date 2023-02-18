using LoginServer.Settings;
using RSLIB;
using System.Diagnostics;
using System.Text;

namespace LoginServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RSEmu | Login server";
            Config.servers = new Login[Config.IPS.Length];

            for (byte i = 0; i < Config.servers.Length; i++)
            {
                Config.servers[i] = new Login(i, Config.IPS[i]);
            }

            Process.GetCurrentProcess().WaitForExit();
        }

    }
}