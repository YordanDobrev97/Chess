namespace Chess.Movements
{
    using Chess.Common;
    using Chess.Interfaces;
    using System;

    public class PawnMovement : IMovement
    {
        public PawnMovement()
        {

        }

        public void Move(int newRow, int newCol, int row, int col, IFigure[,] board)
        {
            if (GlobalConstants.IsFirstPlayer)
            {
                MovePawnOfFirstPlayer(newRow, newCol, row, col, board);
            }
            else
            {
                MovePawnOfSecondPlayer(newRow, newCol, row, col, board);
            }
        }

        private static void MovePawnOfSecondPlayer(int newRow, int newCol, int row, int col, IFigure[,] board)
        {
            //1,0 -> 2, 0
            //normal up move
            if (newRow > row)
            {
                if (IsFreePlace(board, newRow, newCol))
                {
                    var pawn = board[row, col];
                    pawn.Position.Height += 3;
                    board[row, col] = null;
                    board[newRow, newCol] = pawn;
                }
            }
            //TODO: left and right move
        }

        private static void MovePawnOfFirstPlayer(int newRow, int newCol, int row, int col, IFigure[,] board)
        {
            //try move down
            if (newRow > row)
            {
                throw new ArgumentException("Invalid move!");
            }

            var pawn = board[row, col];

            //try get other figure (from right)
            if ((newCol > col))
            {
                if (board[newRow, newCol] != null)
                {
                    pawn.Position.Width += 10;
                    pawn.Position.Height -= 3;
                    board[row, col] = null;
                    board[newRow, newCol] = pawn;
                }
                else
                {
                    throw new ArgumentException("Invalid move!");
                }

            }

            //try get other figure(from left)
            if ((col > newCol))
            {
                if (board[newRow, newCol] != null)
                {
                    pawn.Position.Width -= 10;
                    pawn.Position.Height -= 3;
                    board[row, col] = null;
                    board[newRow, newCol] = pawn;
                }
                else
                {
                    throw new ArgumentException("Invalid move!");
                }

            }
            //normal move up
            if (board[newRow, newCol] == null)
            {
                pawn = board[row, col];
                pawn.Position.Height -= 3;
                board[row, col] = null;
                board[newRow, newCol] = pawn;
            }
        }

        private static bool IsFreePlace(IFigure[,] board, int newRow, int newCol)
        {
            return board[newRow, newCol] == null;
        }
    }
}
