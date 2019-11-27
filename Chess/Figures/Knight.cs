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

        public void Move(bool isFirstPlayer, int row, int col, int newRow, 
            int newCol, IFigure[,] board, IFigure figure)
        {
            if (isFirstPlayer)
            {
                if (figure.Color == Color.Yellow)
                {
                    IFigure figureOut = board[newRow, newCol];

                    if (NotFree(board, newRow, newCol) 
                        && board[newRow,newCol].Color is Color.DarkYellow)
                    {
                        var playerFigures = GlobalConstants.FiguresOfFirstPlayer;
                        playerFigures.Remove(figureOut);
                        board[newRow, newCol] = null;
                    }

                    if (board[newRow, newCol] != null)
                    {
                        throw new ArgumentException(GlobalConstants.MessageForBusyPlace);
                    }

                    if (IsLeftMove(col, newCol))
                    {
                        figure.Position.Width -= 10;
                    }
                    else
                    {
                        figure.Position.Width += 10;
                    }
                    figure.Position.Height -= 6;

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
                    if (IsLeftMove(col, newCol))
                    {
                        figure.Position.Width -= 10;
                    }
                    else
                    {
                        figure.Position.Width += 10;
                    }

                    figure.Position.Height += 6;

                    board[row, col] = null;
                    board[newRow, newCol] = figure;
                }
                else
                {
                    throw new ArgumentException(GlobalConstants.ThisFigureNotMoveMessage);
                }
            }
        }

        private bool NotFree(IFigure[,] board, int newRow, int newCol)
        {
            return board[newRow, newCol] != null;
        }

        private bool IsLeftMove(int col, int newCol)
        {
            return newCol < col;
        }
    }
}
