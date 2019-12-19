namespace Chess
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;
    using Chess.IO;
    using System;

    public class ConsolePainter : IPainter
    {
        private const int CountSpacePaipDrawBoard = 2;
        private const int WidthCursorPositionDrawFigures = 25;
        private const int CountSpaceDrawBox = 6;
        private const int StartCountSpaces = 5;
        private const int IncrementFiguresPosition = 10;
        private const int StartValuePawnPosition = 5;
        private const int IncrementStartValuePawnPosition = 10;

        public void DrawAdminPanel()
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

       /* public IFigure RevivalNewFigure() Probably not on place. Should be in pawns and controller
        {
            ConsoleIO.WriteConsole("Queen: 1   ");
            ConsoleIO.WriteConsole("Knight: 2  ");
            ConsoleIO.WriteConsole("Rook: 3    ");
            ConsoleIO.WriteConsole("Bishop: 4  ");

            int choiseFigureUser = int.Parse(ConsoleIO.ReadFromConsole());

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
                   // figure = new Bishop();
                    break;
            }

            return figure;
        } */

        public void DrawBoard(Board board)
        {
            ConsoleIO.ClearConsole();
            int countSpacePaip = CountSpacePaipDrawBoard;
            ConsoleIO.WriteLineConsole(string.Empty);

            int row = 0;
            int num = board.BoardSize;

            // print boxes rows
            for (int col = 0; col < board.BoardSize; col++)
            {
                DrawBox(countSpacePaip, row, num, board);
                row++;
                num--;
            }

            // print labels
            int countSpace = StartCountSpaces;
            
            for (char symbol = 'a'; symbol <='h'; symbol++)
            {
                ConsoleIO.SetCursorPositionConsole(countSpace, WidthCursorPositionDrawFigures);
                ConsoleIO.WriteConsole(symbol);
                countSpace += IncrementFiguresPosition;
            }

            //print names of players
            countSpace += IncrementFiguresPosition;
            ConsoleIO.SetCursorPositionConsole(countSpace, WidthCursorPositionDrawFigures);
            ConsoleIO.WriteConsole(board.FirstPlayer.Name);            
            ConsoleIO.SetCursorPositionConsole(countSpace, 1);
            ConsoleIO.WriteConsole(board.SecondPlayer.Name);

            this.PrintFiguresOfPlayer(board.FirstPlayer, 0);
            this.PrintFiguresOfPlayer(board.SecondPlayer, 1);
        }

        public void DrawMessage(string message)
        {
            ConsoleIO.SetCursorPositionConsole(GlobalConstants.CursorWidthPositionOfConsole,
                        GlobalConstants.CursorHeightPositionOfConsole);

            Console.ForegroundColor = ConsoleColor.White;
            ConsoleIO.WriteConsole(message);
        }

        public void DrawErrorMessage(string message)
        {
            ConsoleIO.SetCursorPositionConsole(1, 28);
            Console.ForegroundColor = ConsoleColor.Red;
            ConsoleIO.WriteConsole(message);            
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void PrintFiguresOfPlayer(IPlayer player, int numberPlayer)
        {
            foreach (var figure in player.Figures)
            {
            
                int width = (StartValuePawnPosition)+(figure.Position.Width*IncrementStartValuePawnPosition);
                int height = 23 - figure.Position.Height*3;

                ConsoleIO.SetCursorPositionConsole(width, height);
                //ConsoleIO.ConsoleForegroundColor(ConsoleColor.Gray);??
                // var typeColor = (ConsoleColor)Enum.GetValues(typeof(Color))
                //   .GetValue(numberPlayer);               
                var typeColor = (ConsoleColor)figure.Color;
                ConsoleIO.ConsoleForegroundColor(typeColor);

                ConsoleIO.WriteConsole(figure.StringRepresentation + " ");
            }
        }

        private void DrawFront(Board board)
        {
            for (int col = 0; col < board.BoardSize ; col++)
            {
                for (int i = 0; i < board.BoardSize; i++)
                {
                    ConsoleIO.WriteConsole("=");
                }

                ConsoleIO.WriteConsole(new string(' ', CountSpacePaipDrawBoard));
            }
        }

        private void DrawBox(int countSpacePaip, int row, int num, Board board)
        {
            ConsoleIO.WriteConsole(new string(' ', countSpacePaip));
            DrawFront(board);

            ConsoleIO.WriteLineConsole(string.Empty);
            ConsoleIO.WriteConsole(num);
            ConsoleIO.WriteConsole(new string(' ', countSpacePaip - 1));

            for (int col = 0; col < board.BoardSize; col++)
            {
                ConsoleIO.WriteConsole("|");
                for (int i = 0; i < CountSpaceDrawBox; i++)
                {
                    ConsoleIO.WriteConsole(" ");
                }

                ConsoleIO.WriteConsole("|");
                ConsoleIO.WriteConsole(new string(' ', 2));
            }

            ConsoleIO.WriteLineConsole(string.Empty);
            ConsoleIO.WriteConsole(new string(' ', countSpacePaip));
            DrawFront(board);

            ConsoleIO.WriteLineConsole(string.Empty);
        }
    }
}