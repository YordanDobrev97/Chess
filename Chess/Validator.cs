namespace Chess
{
    public class Validator
    {
        public static bool IsValidMoveOfPawn(int row, int col, int newRow, int newCol)
        {
            return newRow > 2 && newRow <= 8;
        }
    }
}
