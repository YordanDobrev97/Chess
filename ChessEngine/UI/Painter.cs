namespace ChessEngine.UI
{
    using System;
    public static class Painter
    {
        private const int Size = 8;
        private static int width = 5;
        public static void DrawBoard()
        {
            int count = 8;
            char alhabet = 'a';
            int x = 5;

            for (int i = 0; i < Size; i++)
            {
                Console.SetCursorPosition(x + 1, 0);
                Console.Write(alhabet);
                alhabet++;
                x += 7;
            }

            Console.WriteLine();

            for (int row = 0; row < Size; row++)
            {
                Console.Write(count);
                Console.Write(new string(' ', 2));
                Console.Write("|");
                
                for (int col = 0; col < Size; col++)
                {
                    Console.Write(new string(' ', width + 1));
                    Console.Write("|");
                    if (col == Size - 1)
                    {
                        Console.Write(count);
                    }                 
                }

                Console.WriteLine();
                Console.WriteLine(new string('-', 57));
                count--;
            }
        }

        public static void DrawFigures()
        {
            DrawFrontFigures();
            DrawBackFigures();
        }

        private static void DrawBackFigures()
        {
            int height = 13;
            int width = 4;

            for (int i = 0; i < Size; i++)
            {
                Console.SetCursorPosition(width, height);
                Console.Write("Pawn");
                width += 7;
            }

            height += 2;

            width = 4;
            Console.SetCursorPosition(width, height);
            Console.Write("Rook");

            width += 7;
            Console.SetCursorPosition(width, height);
            Console.Write("Horse");

            width += 7;
            Console.SetCursorPosition(width, height);
            Console.Write("Bishop");

            width += 7;
            Console.SetCursorPosition(width, height);
            Console.Write("King");

            width += 7;
            Console.SetCursorPosition(width, height);
            Console.Write("Queen");

            width += 7;
            Console.SetCursorPosition(width, height);
            Console.Write("Bishop");

            width += 7;
            Console.SetCursorPosition(width, height);
            Console.Write("Horse");

            width += 7;
            Console.SetCursorPosition(width, height);
            Console.Write("Rook");
        }
        private static void DrawFrontFigures()
        {
            int height = 1;
            Console.SetCursorPosition(4, height);
            Console.Write("Rook");

            Console.SetCursorPosition(11, height);
            Console.Write("Horse");

            Console.SetCursorPosition(18, height);
            Console.Write("Bishop");

            Console.SetCursorPosition(25, height);
            Console.Write("Queen");

            Console.SetCursorPosition(32, height);
            Console.Write("King");

            Console.SetCursorPosition(39, height);
            Console.Write("Bishop");

            Console.SetCursorPosition(46, height);
            Console.Write("Horse");

            Console.SetCursorPosition(53, height);
            Console.Write("Rook");

            int width = 4;

            for (int i = 0; i < Size; i++)
            {
                Console.SetCursorPosition(width, 3);
                Console.Write("Pawn");
                width += 7;
            }
        }
    }
}