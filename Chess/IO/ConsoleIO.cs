using System;

namespace Chess.IO
{
    public class ConsoleIO
    {
        public static string ReadFromConsole()
        {
            return Console.ReadLine();
        }

        public static void WriteConsole(string input)
        {
            Console.Write(input);
        }
    }
}
