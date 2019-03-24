namespace Chess
{
    using Chess.Logic;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            EntryPointGame gameSet = new EntryPointGame();
            gameSet.Start();
        }
    }
}
