using System;

namespace LionEngine.LionEngine
{
    public static class Log
    {
        public static void Normal(Object msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[MSG] - {msg.ToString()}");
        }

        public static void Info(Object msg)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[INFO] - {msg.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error(Object msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] - {msg.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warning(Object msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] - {msg.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
