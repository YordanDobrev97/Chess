namespace ChessEngine
{
    using ChessEngine.UI;
    using System;

    public abstract class Game
    {
        public static void Start()
        {
            Drawing drawing = new Drawing();
            drawing.DrawPlayground();

            drawing.DrawFigures();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter your move: ");
            string inputUser = Console.ReadLine();

            while (true)
            {
                inputUser = Console.ReadLine();
            }
        }
    }
}
