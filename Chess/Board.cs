using Chess.Figures;
using Chess.Interfaces;

namespace Chess
{
    public class Board
    {
        public static IFigure[,] board = new IFigure[Controller.DEFAULT_VALUE, Controller.DEFAULT_VALUE];

        public Board()
        {
            InitializeFigures();
        }

        public void MoveFigure(string currentPosition, string newPosition)
        {
            int col = currentPosition[0] - 'a';
            int row = Controller.DEFAULT_VALUE - (currentPosition[1] - '0');

            IFigure currentFigure = board[row, col];

            int newCol = newPosition[0] - 'a';
            int newRow = Controller.DEFAULT_VALUE - (newPosition[1] - '0');

            Board.board[row, col] = null;
            Board.board[newRow, newCol] = currentFigure;

            currentFigure.Position.Height -= 3;

            Painter.DrawFigures(false);
        }

        private static void InitializeFigures()
        {
            int end = 8;
            int row = 0;
            int col = 0;
            for (int i = 0; i < Painter.figuresOfFirstPlayer.Length; i++)
            {
                if (i == end)
                {
                    row++;
                    col = 0;
                }
                board[row, col++] = Painter.figuresOfFirstPlayer[i];
            }

            row = 6;
            col = 0;
            for (int i = 0; i < Painter.figuresOfSecondPlayer.Length; i++)
            {
                if (i == end)
                {
                    row++;
                    col = 0;
                }
                board[row, col++] = Painter.figuresOfSecondPlayer[i];
            }
        }
    }
}
