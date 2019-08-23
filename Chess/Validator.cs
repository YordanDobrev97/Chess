using Chess.Figures;
using Chess.Interfaces;

namespace Chess
{
    public class Validator
    {
        public static bool IsValidMoveOfPawn(IFigure pawn, int row, int col, int newRow, int newCol, bool isFirstPlayer)
        {

            if (!MovePawnInRangeBoard(newRow))
            {
                return false;
            }

            if (HasMoreOneMove(pawn, row, newRow, isFirstPlayer))
            {
                return false;
            }

            return true;
        }

        private static bool MovePawnInRangeBoard(int newRow)
        {
            return newRow > 2 && newRow <= 8;
        }

        private static bool HasMoreOneMove(IFigure pawn, int currentRow, int newRow, bool isFirstPlayer)
        {
            int move = 1;
            if (isFirstPlayer)
            {
                //has double move
                if (((Pawn)pawn).HasInitialState && newRow == move + 1)
                {
                    return false;
                }

                // has single move
                return (currentRow + move) != newRow;
            }

            //has double move
            if (((Pawn)pawn).HasInitialState && newRow == move - 1)
            {
                return false;
            }

            // has single move
            return (currentRow - move) != newRow;

        }
    }
}
