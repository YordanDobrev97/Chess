using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Chess
{
    public class StartUp
    {

        static void Main()
        {
            //More advanced console settings can be changed programmatically in
            //the Controller class
            Console.Title = "Chess";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.OutputEncoding = Encoding.UTF8;
            Controller.Start();
        }

    }
}
