namespace Chess
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;
    using Chess.IO;
    using System;
    using System.Linq;

    public abstract class Painter
    {
        public static FirstPlayer GetPlayerName(FirstPlayer player)
        {
            return player;
        }

        public static void DrawAdminPanel()
        {
            Console.Write(new string(' ', 20));
            Console.WriteLine(new string('=', 50));

            for (int i = 0; i < 3; i++)
            {
                Console.Write(new string(' ', 20));
                Console.Write("|");
                Console.Write(new string(' ', 49));
                Console.Write("|");
                Console.WriteLine();
            }

            Console.Write(new string(' ', 20));
            Console.WriteLine(new string('=', 50));

            Console.SetCursorPosition(42, 2);
            Console.WriteLine("ADMIN PANEL");

            int x = 6;

            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, x);
                Console.Write(new string(' ', 20));
                Console.Write("+");
                Console.Write(new string(' ', 50));
                Console.WriteLine("+");

                x++;
            }

            Console.SetCursorPosition(0, 17);
            Console.Write(new string(' ', 20));
            Console.WriteLine(new string('=', 50));

            Console.SetCursorPosition(22, 6);
            Console.WriteLine("Option 1: Start Game");

            Console.SetCursorPosition(22, 7);
            Console.WriteLine("Option 2: Exit");

            Console.SetCursorPosition(20, 20);
            Console.WriteLine("Enter your choice: ");
            Console.SetCursorPosition(39, 20);
        }

        public static IFigure RevivalNewFigure()
        {
            ConsoleIO.WriteConsole("Queen: 1   ");
            ConsoleIO.WriteConsole("Knight: 2  ");
            ConsoleIO.WriteConsole("Rook: 3    ");
            ConsoleIO.WriteConsole("Bishop: 4");

            Console.WriteLine();
            int choiseFigureUser = int.Parse(Console.ReadLine());

            IFigure figure = null;
            switch (choiseFigureUser)
            {
                case 1:
                    figure = new Queen();
                    break;
                case 2:
                    figure = new Knight();
                    break;
                case 3:
                    figure = new Rook();
                    break;
                case 4:
                    figure = new Bishop();
                    break;
            }

            return figure;
        }

        public static void DrawFigures(bool isDefault, IPlayer player, int numberPlayer)
        {
            PrintFiguresOfPlayer(player, numberPlayer);
        }

        public static void DrawBoard()
        {
            //TODO Add ConsolePainter
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

        private static void PrintFiguresOfPlayer(IPlayer player, int numberPlayer)
        {
            foreach (var figure in player.Figures)
            {
                int width = figure.Position.Width;
                int height = figure.Position.Height;

                Console.SetCursorPosition(width, height);
                Console.ForegroundColor = ConsoleColor.Gray;
                var typeColor = (ConsoleColor)Enum.GetValues(typeof(Color)).GetValue(numberPlayer);

                //ConsoleColor color = (ConsoleColor)typeColor;
               Console.ForegroundColor = typeColor;

                Console.Write(figure.StringRepresentation + " ");
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