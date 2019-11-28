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

        public void Move(bool isSecondPlayer, int row, int col, int newRow, 
            int newCol, IFigure[,] board, IFigure figure)
        {
            if (isSecondPlayer)
            {
                //two move pawn
                int move = 3; //default value one move up
                if (row - 2 == newRow && this.HasInitialState)
                {
                    move = 6;
                    this.HasInitialState = false;
                }
                else if (row - 2 == newRow && !this.HasInitialState)
                {
                    throw new ArgumentException("You can now only make one move!");
                }

                if (col == newCol && figure.Color == Color.Yellow)
                {
                    figure.Position.Height -= move;

                    board[row, col] = null;
                    board[newRow, newCol] = figure;
                    this.HasInitialState = false;
                }
                else if (CanTurnOffFigureOfОpponent(board, figure, newRow, newCol))
                {
                    IFigure figureOut = board[newRow, newCol];

                    var playerFigures = GlobalConstants.FiguresOfFirstPlayer;
                    playerFigures.Remove(figureOut);
                    board[newRow, newCol] = null;

                    if (IsLeft(col, newCol))
                    {
                        figure.Position.Width -= 10;
                        figure.Position.Height -= 3;
                    }
                    else
                    {
                        figure.Position.Width += 10;
                        figure.Position.Height -= 3;
                    }

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

        private bool IsLeft(int col, int newCol)
        {
            return newCol < col;
        }

        private bool CanTurnOffFigureOfОpponent(IFigure[,] board, IFigure figure, int newRow, int newCol)
        {
            IFigure wishFigure = board[newRow, newCol];
            return wishFigure.Color != figure.Color;
        }
    }
}
