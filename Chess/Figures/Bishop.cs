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

        public void Move(bool isFirstPlayer,int row, int col, int newRow, int newCol, IFigure[,] board, IFigure figure)
        {
            //TODO Add any jump! 
            if (board[newRow, newCol] != null)
            {
                throw new ArgumentException(GlobalConstants.MessageForBusyPlace);
            }

            if (isFirstPlayer)
            {
                if (IsMoveLeft(col, newCol))
                {
                    figure.Position.Width -= 10;
                }
                else
                {
                    figure.Position.Width += 10;
                }

                figure.Position.Height -= 3;

            }
            else
            {
                if (IsMoveLeft(col, newCol))
                {
                    figure.Position.Width -= 10;
                }

                figure.Position.Height += 3;
            }
            board[row, col] = null;
            board[newRow, newCol] = figure; 
        }

        private static bool IsMoveLeft(int col, int newCol)
        {
            return newCol < col;
        }
    }
}
