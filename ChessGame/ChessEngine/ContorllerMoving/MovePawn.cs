using ChessEngine.Board.Figures;
using ChessEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessEngine.ContorllerMoving
{
    public class MovePawn
    {
        private static HashSet<string> movingOfPawns = new HashSet<string>();

        public static void ChangeCurrentCordinatesOfPawnWithNew(int x, int y)
        {
            //var pawn = Drawing.CordinatesFigures;
        }

        private static void MovingFigureOfFirstPlayer(Drawing drawing, string oldPostion, string newPosition)
        {
            switch (oldPostion)
            {
                case "a2":
                    try
                    {
                        if (ValidMoving.ValidMovePawn(newPosition))
                        {
                            Drawing.SaveFigureCordinates(newPosition, 0, true);
                            Console.Clear();
                            drawing.DrawPlayground();
                            drawing.DrawFigures();
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "a3":
                    if (ValidMoving.ValidMovePawn(newPosition))
                    {
                        Drawing.SaveFigureCordinates(newPosition, 1, true);
                        Console.Clear();
                        drawing.DrawPlayground();
                        drawing.DrawFigures();
                    }
                    break;
                case "a4":
                    if (ValidMoving.ValidMovePawn(newPosition))
                    {
                        Drawing.SaveFigureCordinates(newPosition, 2, true);
                        Console.Clear();
                        drawing.DrawPlayground();
                        drawing.DrawFigures();
                    }
                    break;
                case "a5":
                    if (ValidMoving.ValidMovePawn(newPosition))
                    {
                        Drawing.SaveFigureCordinates(newPosition, 3, true);
                        Console.Clear();
                        drawing.DrawPlayground();
                        drawing.DrawFigures();
                    }
                    break;
            }
        }
    }
}
