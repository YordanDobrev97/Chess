using Chess.Core;
using Chess.Interfaces;
using System;
using System.Text;

namespace Chess
{
    public class StartUp
    {
        public static void Main()
        {
            ////More advanced console settings can be changed programmatically in
            ////the SystemSetting class
            Console.Title = "Chess";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.OutputEncoding = Encoding.UTF8;

            IGame currentGame = new ConsoleGame();
            currentGame.Start();
        }
    }
}
