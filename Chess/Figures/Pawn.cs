namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Interfaces;
    using System;

    public class Pawn : IFigure
    {
        public Pawn()
        {
            this.HasInitialState = true;
        }

        public string StringRepresentation => "♙";

        public Position Position { get; set; } = new Position();

        public bool HasInitialState { get; set; }

        public Color Color { get; set; }

        public void Move(bool isFirstPlayer, int row, int col, int newRow, int newCol, IFigure[,] board, IFigure figure)
        {
            if (isFirstPlayer)
            {
                if (figure.Color == Color.Yellow)
                {
                    figure.Position.Height -= 3;

                    board[row, col] = null;
                    board[newRow, newCol] = figure;
                }
                else
                {
                    throw new ArgumentException(GlobalConstants.ThisFigureNotMoveMessage);
                }
            }
            else
            {
                if (figure.Color == Color.DarkYellow)
                {
                    figure.Position.Height += 3;

                    board[row, col] = null;
                    board[newRow, newCol] = figure;
                }
                else
                {
                    throw new ArgumentException(GlobalConstants.ThisFigureNotMoveMessage);
                }
            }
        }
    }
}
