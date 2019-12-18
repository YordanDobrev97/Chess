namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Interfaces;
    using System;

    public class Rook : IFigure
    {
        public string StringRepresentation => "♖";

        public Position Position { get; set; } = new Position();

        public Color Color { get; set; }

        public IPlayer Player => throw new NotImplementedException();

        public void Move(bool isFirstPlayer, int row, int col, int newRow, 
            int newCol, IFigure[,] board, IFigure figure)
        {
            //if (board[newRow,newCol] != null)
            //{
            //    throw new ArgumentException(GlobalConstants.MessageForBusyPlace);
            //}

            if (isFirstPlayer)
            {
                int move = 3;
                int numberStartPosition = GlobalConstants.StartPosition[1] - '0';
                int numberDestination = GlobalConstants.Destination[1] - '0';

                if (MoveUp(col, newCol, row, newRow))
                {
                    figure.Position.Height -= move * (numberDestination - numberStartPosition);
                }
                else if (MoveDown(col, newCol, row, newRow))
                {
                    figure.Position.Height += move * (numberStartPosition - numberDestination);
                }
                else if (MoveLeft(col, newCol))
                {

                }
                else if (MoveRigt(col, newCol))
                {
                    move = 9;
                    numberStartPosition = GlobalConstants.StartPosition[0];
                    numberDestination = GlobalConstants.Destination[0];

                    figure.Position.Width += move * (numberDestination - numberStartPosition) * 2;
                }
                else
                {

                }
            }
            else
            {
                figure.Position.Height += 3;
            }
            board[row, col] = null;
            board[newRow, newCol] = figure;
        }

        private bool MoveRigt(int col, int newCol)
        {
            return newCol > col;   
        }

        private bool MoveLeft(int col, int newCol)
        {
            return false;
        }

        private bool MoveDown(int col, int newCol, int row, int newRow)
        {
            return col == newCol && row < newRow;
        }

        private bool MoveUp(int col,int newCol, int row, int newRow)
        {
            return col == newCol && newRow < row;
        }
    }
}
