using ChessEngine.UI;
using System;
using System.Collections.Generic;

namespace ChessEngine
{
    class Program
    {
        static void Main()
        {
            Console.WindowHeight = 28;
            Console.WindowWidth = 84;

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Game.Start();
        }
    }
}
