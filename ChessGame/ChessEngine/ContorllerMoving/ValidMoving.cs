using ChessEngine.ContorllerMoving;
using ChessEngine.UI;
using System;
using System.Collections.Generic;

namespace ChessEngine.Board.Figures
{
    public static class ValidMoving
    {
        public static string ValidMove { get; set; }

        public static void ValidMoveOfRook(string newPostion)
        {
            List<string> listValidMoveOfRook = SetValidMovingOfRook();

            //execute in class
            if (!listValidMoveOfRook.Contains(newPostion))
            {
                Exception.ThrowExceptionForInvalidMove();
            }
            //
        }

        private static List<string> SetValidMovingOfRook()
        {
            var listValidMoveOfRook = new List<string>();
            for (int i = 1; i <= 8; i++)
            {
                listValidMoveOfRook.Add($"a{i}");
            }

            for (char i = 'b'; i <= 'h'; i++)
            {
                listValidMoveOfRook.Add($"a{i}");
            }

            return listValidMoveOfRook;
        }

        public static bool ValidMovePawn(string newPosition)
        {
            return ControllerPawn.ValidMoveOfPawn(newPosition);
        }
    }
}