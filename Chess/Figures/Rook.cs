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

        public void Move(bool isFirstPlayer, int row, int col, int newRow, 
            int newCol, IFigure[,] board, IFigure figure)
        {
            if (board[newRow,newCol] != null)
            {
                throw new ArgumentException(GlobalConstants.MessageForBusyPlace);
            }

            if (isFirstPlayer)
            {
                int move = 3;
                if (MoveUp(col, newCol, row, newRow))
                {
                    int numberStartPosition = GlobalConstants.StartPosition[1] - '0';
                    int numberDestination = GlobalConstants.Destination[1] - '0';

                    figure.Position.Height -= move * (numberDestination - numberStartPosition);
                }
                else if (MoveDown())
                {

                }
                else if (MoveLeft())
                {

                }
                else if (MoveRigt())
                {

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

        private bool MoveRigt()
        {
            throw new NotImplementedException();
        }

        private bool MoveLeft()
        {
            throw new NotImplementedException();
        }

        private bool MoveDown()
        {
            throw new NotImplementedException();
        }

        private bool MoveUp(int col,int newCol, int row, int newRow)
        {
            return col == newCol && newRow < row;
        }
    }
}
