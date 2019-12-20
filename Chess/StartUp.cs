namespace Chess
{
    using Chess.Core;
    using Chess.Interfaces;

    public class StartUp
    {
        public static void Main()
        {  
            IGame currentGame = new ConsoleGame();
            currentGame.StartMenu();
        }
    }
}
