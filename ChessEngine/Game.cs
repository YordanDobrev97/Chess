namespace ChessEngine
{
    using ChessEngine.Board.Figures;
    using ChessEngine.UI;
    using System;

    public abstract class Game
    {   
        public static void Start()
        {
            Painter.DrawBoard();
            Painter.DrawFigures();

            while (true)
            {
                User.WriteUserCommand();
            }
        }
    }
}
