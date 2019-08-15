namespace Chess
{
    public class Validator
    {
        public static bool IsValidMoveOfPawn(int row, int col, int newRow, int newCol)
        {
            if (!MovePawnInRangeBoard(newRow))
            {
                return false;
            }

            if (HasMoreOneMove(row, newRow))
            {
                return false;
            }

            return true;
        }

        private static bool MovePawnInRangeBoard(int newRow)
        {
            return newRow > 2 && newRow <= 8;
        }

        private static bool HasMoreOneMove(int currentRow, int newRow)
        {
            return (currentRow + 1) != newRow;
        }
    }
}
