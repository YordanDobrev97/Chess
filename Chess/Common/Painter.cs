using Chess.Common;
using Chess.Figures;
using Chess.Interfaces;
using System;
using System.Threading;

namespace Chess
{
    public abstract class Painter
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

        public static string ReadFromConsole()
        {
            return Console.ReadLine();
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

        public static void Sleep(int time)
        {
            Thread.Sleep(time);
        }

        public static void SetBufferSize(int width, int height)
        {
            Console.SetBufferSize(width, height);
        }

        public static Player GetPlayerName(Player player)
        {
            return player;
        }

        public static void DrawFieldWithAliveFigures()
        {
            Console.SetCursorPosition(GlobalConstants.WidthPositionDeadFigure,
                GlobalConstants.HeightPositionDeadFigure);

            Console.Write("Dead figures");

            Console.SetCursorPosition(GlobalConstants.WidthNameFirstPlayerPosition, 
                GlobalConstants.HeightNamePlayerPosition);

            Console.WriteLine("Pesho");

            Console.SetCursorPosition(GlobalConstants.WidthNameSecondPlayerPosition,
                GlobalConstants.HeightNamePlayerPosition);
            Console.WriteLine("Gosho");

            Console.SetCursorPosition(GlobalConstants.WidthPositionDrawAliveFigure, 
                GlobalConstants.HeightPositionDrawAliveFigure);

            for (int i = 0; i < GlobalConstants.LengthDrawAliveFigure; i++)
            {
                Console.Write("-----");
            }

            int currentRow = GlobalConstants.LengthDrawAliveFigure + 1;
            
            for (int i = 0; i < GlobalConstants.RowSizeDrawAliveFigure; i++)
            {
                Console.SetCursorPosition(GlobalConstants.WidthPositionDrawAliveFigure,
                    currentRow);

                for (int j = 0; j < GlobalConstants.ColSizeDrawAliveFigure; j++)
                {
                    Console.Write("|");
                    Console.Write(new string(' ', GlobalConstants.SpaceDrawAliveFigure));
                }
                Console.WriteLine("|");
                currentRow++;
            }

            Console.SetCursorPosition(GlobalConstants.WidthPositionDrawAliveFigure, 
                currentRow);

            for (int i = 0; i < GlobalConstants.LengthDrawAliveFigure; i++)
            {
                Console.Write("-----");
            }
        }

        public static void DrawFigures(bool isDefault)
        {
            Console.Clear();
            DrawBoard();

            if (isDefault)
            {
                Controller.SaveDefaultCoordinatesFigures();
            }

            var figuresOfSecondPlayer = Painter.figuresOfSecondPlayer;
            var figuresOfFirstPlayer = Painter.figuresOfFirstPlayer;

            PrintFiguresOfPlayer(figuresOfFirstPlayer);
            PrintFiguresOfPlayer(figuresOfSecondPlayer);
        }

        public static void DrawBoard()
        {
            int countSpacePaip = GlobalConstants.CountSpacePaipDrawBoard;
            Console.WriteLine();

            int row = 0;
            int num = GlobalConstants.DefaultValueSizeOfBoard;

            for (int col = 0; col < GlobalConstants.DefaultValueSizeOfBoard; col++)
            {
                DrawBox(countSpacePaip, row, num);
                row++;
                num--;
            }

            int countSpace = GlobalConstants.StartCountSpaces;
            
            for (char symbol = 'a'; symbol <='h'; symbol++)
            {
                Console.SetCursorPosition(countSpace, GlobalConstants.WidthCursorPositionDrawFigures);
                Console.Write(symbol);
                countSpace += GlobalConstants.IncrementStartValuePawnPosition;
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
            for (int col = 0; col < GlobalConstants.DefaultValueSizeOfBoard; col++)
            {
                for (int i = 0; i < GlobalConstants.DefaultValueSizeOfBoard; i++)
                {
                    Console.Write("=");
                }

                Console.Write(new string(' ', GlobalConstants.CountSpacePaipDrawBoard));
            }
        }

        private static void DrawBox(int countSpacePaip, int row, int num)
        {
            Console.Write(new string(' ', countSpacePaip));
            DrawFront();

            Console.WriteLine();
            Console.Write(num);
            Console.Write(new string(' ', countSpacePaip - 1));

            for (int col = 0; col < GlobalConstants.DefaultValueSizeOfBoard; col++)
            {
                Console.Write("|");
                for (int i = 0; i < GlobalConstants.CountSpaceDrawBox; i++)
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