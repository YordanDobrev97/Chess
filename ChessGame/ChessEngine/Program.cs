using System;

namespace ChessEngine
{
    class Program
    {
        static void Main()
        {
            Console.Title = "My Chess";

            Console.BufferHeight = 30;
            Console.WindowHeight = 30;
            Console.WindowWidth = 86;

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Game.Start();
        }
    }
}
