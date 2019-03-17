using System.Collections.Generic;

namespace Chess.Common
{
    public class ValidMove
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
    }
}
