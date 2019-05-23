namespace ChessEngine
{
    using System;
    class StartUp
    {
        static void Main()
        {
            Console.Title = "My Chess";
            Console.OutputEncoding = System.Text.Encoding.Unicode;


            Game.Start();
        }
    }
}
