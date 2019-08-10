using System;
using System.Text;

namespace Chess
{
    public class StartUp
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.OutputEncoding = Encoding.UTF8;
            Controller.Start();
        }
    }
}
