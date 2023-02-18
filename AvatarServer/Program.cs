using RSLIB;
using System.Diagnostics;
using System.Text;

namespace AvatarServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RSEmu | Avatar server";
            ResourceManager manager = new ResourceManager();
            Process.GetCurrentProcess().WaitForExit();
        }
    }
}