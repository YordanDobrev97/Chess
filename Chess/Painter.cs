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

        public static void WriteConsole(string input)
        {
            Console.Write(input);
        }

        public static void SetCursorPositionConsole(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void SetWindowSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
        }

        public static void SetBufferSize(int width, int height)
        {
            Console.SetBufferSize(width, width);
        }

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

            PrintFiguresOfPlayer(figuresOfFirstPlayer);
            PrintFiguresOfPlayer(figuresOfSecondPlayer);
        }

        public static void DrawBoard()
        {
            int countSpacePaip = 2;
            Console.WriteLine();

            int row = 0;
            int num = 8;
            for (int col = 0; col < Controller.DEFAULT_VALUE; col++)
            {
                DrawBox(countSpacePaip, row, num);
                row++;
                num--;
            }

            int countSpace = 5;
            
            for (char symbol = 'a'; symbol <='h'; symbol++)
            {
                Console.SetCursorPosition(countSpace, 25);
                Console.Write(symbol);
                countSpace+= 10;
            }
        }

        private static void PrintFiguresOfPlayer(IFigure[] figures)
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

        private static void DrawBox(int countSpacePaip, int row, int num)
        {
            Console.Write(new string(' ', countSpacePaip));
            DrawFront();

            Console.WriteLine();
            Console.Write(num);
            Console.Write(new string(' ', countSpacePaip - 1));

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