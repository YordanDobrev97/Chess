using ChessEngine.UI;
using System;
using System.Collections.Generic;

namespace ChessEngine.ContorllerMoving
{
    public class ControllerPawn
    {
        private static List<string> SetValidMovingOfPawnOfUp()
        {
            var listFromValidMovePawn = new List<string>();

            for (int numberPostion = 3; numberPostion <= 8; numberPostion++)
            {
                listFromValidMovePawn.Add($"a{numberPostion}");
            }

            return listFromValidMovePawn;
        }

        public static bool ValidMoveOfPawn(string newPostion)
        {
            var validMoveOfPawn = SetValidMovingOfPawnOfUp();
            //move up
            if (!validMoveOfPawn.Contains(newPostion))
            {
                Exception.ThrowExceptionForInvalidMove();
            }

            if (IsBlockFromOtherFigure(newPostion))
            {
                Exception.ThrowExceptionFigureBlockFromOtherFigure();
            }

            return true;
        }

        private static bool IsBlockFromOtherFigure(string newPostion)
        {
            var cordinates = Drawing.CordinatesFigures.Values;
            return false;
        }
    }
}
