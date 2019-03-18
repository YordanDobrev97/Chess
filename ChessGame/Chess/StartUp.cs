namespace Chess
{
    using Chess.Logic;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class StartUp
    {
        public static void Main()
        {
            GameSet gameSet = new GameSet();
            gameSet.Start();
        }
    }
}
