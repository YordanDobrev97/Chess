namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Interfaces;
    using System;

    public class Knight : IFigure
    {
        public string StringRepresentation => "♞";

        public Position Position { get; set; } = new Position();

        public Color Color { get; set; }

        public void Move(bool isFirstPlayer, int row, int col, int newRow, int newCol, IFigure[,] board, IFigure figure)
        {
            if (board[newRow, newCol] != null)
            {
                throw new ArgumentException(GlobalConstants.MessageForBusyPlace);
            }

            if (isFirstPlayer)
            {
                if (IsLeftMove(col, newCol))
                {
                    figure.Position.Width -= 10;
                }
                else
                {
                    figure.Position.Width += 10;
                }
                figure.Position.Height -= 6;
            }

            board[row, col] = null;
            board[newRow, newCol] = figure;
        }

        private bool IsLeftMove(int col, int newCol)
        {
            return newCol < col;
        }
    }
}
