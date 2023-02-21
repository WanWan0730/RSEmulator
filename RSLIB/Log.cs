using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLIB
{
    public static class Log
    {
        public static void Info(string message)
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Write(message);
            Console.ResetColor();
        }
        
        public static void Error(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Write(message);
            Console.ResetColor();
        }
        public static void Warning(string message)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Write(message);
            Console.ResetColor();
        }
        public static void Success(string message)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Write(message);
            Console.ResetColor();
        }
        public static void Debug(string message)
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Write(message);
            Console.ResetColor();
        }
        public static void Packet(byte[] message)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Write(BitConverter.ToString(message).Replace("-", ""));
            Console.ResetColor();
        }
        private static void Write(string message)
        {
            DateTime dateTime= DateTime.Now;
            Console.WriteLine($"[{dateTime}] - {message}");
        }
    }
}