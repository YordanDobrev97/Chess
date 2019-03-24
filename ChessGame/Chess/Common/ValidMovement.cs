namespace Chess.Common
{
    using System.Collections.Generic;

    public class ValidMovement
    {
        public static List<string> validMovePerPawn { get; set; }

        private static void AddValidMovePawn()
        {
            for (int i = 1; i <=8; i++)
            {
                validMovePerPawn.Add($"P{i}");
            }
        }

        public static bool IsValidMovePawn(string move)
        {
            validMovePerPawn = new List<string>();
            AddValidMovePawn();

            return validMovePerPawn.Contains(move);
        }

        public static bool IsValidCountPawn(int count)
        {
            return count == 1 || count == 2;
        }
    }
}
