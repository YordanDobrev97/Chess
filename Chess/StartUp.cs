namespace Chess
{
    using Chess.Core;
    using Chess.Interfaces;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            IGame currentGame = new ConsoleGame();
            currentGame.StartMenu();
        }
    }
}
