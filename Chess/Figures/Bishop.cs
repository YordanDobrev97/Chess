namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Interfaces;
    using System;

    public class Bishop : IFigure
    {
        public string StringRepresentation => "♝";

        public Bishop()
        {
            this.Position = new Position();
        }

        public Position Position { get; set; }

        public Color Color { get; set; }

        public void Move(bool isFirstPlayer,int row, int col, int newRow, int newCol, 
            IFigure[,] board, IFigure figure)
        {
            if (board[newRow, newCol] != null)
            {
                throw new ArgumentException(GlobalConstants.MessageForBusyPlace);
            }

            if (isFirstPlayer)
            {
                if (figure.Color == Color.Yellow)
                {
                    if (IsMoveLeft(col, newCol))
                    {
                        figure.Position.Width -= row - newRow;
                    }
                    else
                    {
                        figure.Position.Width += 10;
                    }

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
                    if (IsMoveLeft(col, newCol))
                    {
                        figure.Position.Width -= row - newRow;
                    }
                    else
                    {
                        figure.Position.Width += 10;
                    }

                    figure.Position.Height += 3 * (row - newRow);

                    board[row, col] = null;
                    board[newRow, newCol] = figure;
                }
                else
                {
                    throw new ArgumentException(GlobalConstants.ThisFigureNotMoveMessage);
                }
            }
            
        }

        private static bool IsMoveLeft(int col, int newCol)
        {
            return newCol < col;
        }
    }
}
