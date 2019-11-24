namespace Chess
{
    using System;
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;

    public abstract class Validator
    {
        public static bool IsValidMoveOfPawn(IFigure pawn, int row, int col, int newRow, 
            int newCol, bool isFirstPlayer)
        {
            //out of range from board
            bool isValid = true;
            if (!MovePawnInRangeBoard(newRow))
            {
                return false;
            }

            if (GlobalConstants.IsFirstPlayer)
            {
                if (!IsFigureOfCurrentPlayer())
                {
                    isValid = false;
                }
                
                if (!HasOneOrOneMove(pawn, row, col, isFirstPlayer))
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        private static bool IsAlreadyMoveTwo()
        {
            throw new NotImplementedException();
        }

        private static bool IsOneMove()
        {
            throw new NotImplementedException();
        }

        private static bool IsFigureOfCurrentPlayer()
        {
            return true;
        }

        private static bool MovePawnInRangeBoard(int newRow)
        {
            return newRow > 2 && newRow <= 8;
        }

        private static bool HasOneOrOneMove(IFigure pawn, int currentRow, int newRow, bool isFirstPlayer)
        {
            int move = 1;
            if (isFirstPlayer)
            {
                //has double move (first player)
                if (((Pawn)pawn).HasInitialState && newRow - currentRow == currentRow)
                {
                    return true;
                }

                // has single move (first player)
                return (currentRow + move) != newRow;
            }

            //has double move (second player)
            if (((Pawn)pawn).HasInitialState && newRow == move - 1)
            {
                return false;
            }

            // has single move (second player)
            return (currentRow - move) != newRow;

        }
    }
}