using Chess.Figures;
using Chess.Interfaces;
using System;
using System.Collections.Generic;

namespace Chess
{
    public class Painter
    {
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

        public static void DrawFigures(bool isDefault)
        {
            Console.Clear();
            DrawBoard();
            if (isDefault)
            {
                Controller.SaveDefaultCoordinatesFigures<IFigure>();
            }

            var figuresOfSecondPlayer = Painter.figuresOfSecondPlayer;
            var figuresOfFirstPlayer = Painter.figuresOfFirstPlayer;

            PrintFiguresOfSecondPlayer(figuresOfSecondPlayer);
            PrintFiguresOfSecondPlayer(figuresOfFirstPlayer);
        }

        public static void DrawBoard()
        {
            int  countSpacePaip = 2;
            Console.WriteLine();

            for (int col = 0; col < Controller.DEFAULT_VALUE; col++)
            {
                DrawBox(countSpacePaip);
            }
        }

        private static void PrintFiguresOfSecondPlayer(IFigure[] figures)
        {
            foreach (var figure in figures)
            {
                int width = figure.Position.Width;
                int height = figure.Position.Height;

                Console.SetCursorPosition(width, height);
                Console.Write(figure.StringRepresentation);
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
