using Chess.Figures;
using Chess.Interfaces;
using System;
using System.Collections.Generic;

namespace Chess
{
    public class Painter
    {
        public static Dictionary<Tuple<IFigure>, Dictionary<int, int>> cordinatesOfFigures = new Dictionary<Tuple<IFigure>, Dictionary<int, int>>();

        public static IFigure[] figuresOfFirstPlayer =
        {
            new Rook(),
            new Knight(),
            new Bishop(),
            new Queen(),
            new King(),
            new Bishop(),
            new King(),
            new Rook(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
        };

        public static IFigure[] figuresOfSecondPlayer =
        {
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Pawn(),
            new Rook(),
            new Knight(),
            new Bishop(),
            new Queen(),
            new King(),
            new Bishop(),
            new King(),
            new Rook(),
        };

        public static void DrawFigures()
        {
            Controller.SaveDefaultCordinatesFigures<IFigure>();
            var keys = cordinatesOfFigures.Keys;

            foreach (var item in keys)
            {
                var currentFigure = cordinatesOfFigures[item];

                foreach (var valueFigure in currentFigure)
                {
                    Console.SetCursorPosition(valueFigure.Key, valueFigure.Value);
                    Console.Write(item.Item1.StringRepresentation);
                }
            }
        }

        public static void DrawBoard()
        {
            int startValueCountPaip = 2;
            Console.WriteLine();

            for (int col = 0; col < Controller.DEFAULT_VALUE; col++)
            {
                DrawBox(startValueCountPaip);
            }
        }

        private static void DrawFront()
        {
            for (int col = 0; col < Controller.DEFAULT_VALUE; col++)
            {
                for (int i = 0; i < Controller.DEFAULT_VALUE; i++)
                {
                    Console.Write("=");
                }

                Console.Write(new string(' ', 2));
            }
        }

        private static void DrawBox(int countSpacePaip)
        {
            Console.Write(new string(' ', countSpacePaip));
            DrawFront();

            Console.WriteLine();
            Console.Write(new string(' ', countSpacePaip));

            for (int col = 0; col < Controller.DEFAULT_VALUE; col++)
            {
                Console.Write("|");
                for (int i = 0; i < 6; i++)
                {
                    Console.Write(" ");
                }
				
                Console.Write("|");
                Console.Write(new string(' ', 2));
            }

            Console.WriteLine();
            Console.Write(new string(' ', countSpacePaip));
            DrawFront();

            Console.WriteLine();
        }
    }
}
