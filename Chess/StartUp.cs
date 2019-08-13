using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Chess
{
    public class StartUp
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(84,28);
            Console.SetBufferSize(84,28);
            Controller.Start();
        }
    }
}
