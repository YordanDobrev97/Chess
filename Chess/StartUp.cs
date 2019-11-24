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
            //Console.OutputEncoding = Encoding.UTF8;
            //SystemSetting.SetSettingOfFontMsGothic();
            
            //Console.WriteLine("♙ ");

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.Gray;
            //Console.BackgroundColor = ConsoleColor.DarkYellow;
            //Console.WriteLine("♚ ");
            

            //Console.WriteLine("♚");

            IGame currentGame = new ConsoleGame();
            currentGame.StartGame();
        }
    }
}
