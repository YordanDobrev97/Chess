namespace Chess
{
    using Chess.Common;
    using Chess.Interfaces;
    using System;
    using System.Linq;

    public abstract class Painter
    {
        public static FirstPlayer GetPlayerName(FirstPlayer player)
        {
            return player;
        }

        public static void DrawFigures(bool isDefault, IPlayer player, int numberPlayer)
        {
            //Console.Clear();
            //DrawBoard();

            if (isDefault)
            {
                //Pl.SaveDefaultCoordinatesFigures();
            }
            
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