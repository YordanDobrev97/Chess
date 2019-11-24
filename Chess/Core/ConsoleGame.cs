namespace Chess.Core
{
    using Chess.Common;
    using Chess.Interfaces;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    public class ConsoleGame : IGame
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        public void StartMenu()
        {
            FullScreen();
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

            string userChoice = Console.ReadLine();

            if (userChoice== "Start Game")
            {
                Console.Clear();
                StartGame();
            }
            else if (userChoice == "Exit")
            {
                Environment.Exit(0);
            }
        }

        public void StartGame()
        {
            Console.Title = "Chess";
            Console.ForegroundColor = ConsoleColor.White;
            Console.OutputEncoding = Encoding.UTF8;

            SystemSetting.SetSettingOfFontMsGothic();
            FirstPlayer peshoPlayer = new FirstPlayer("Pesho", Color.Yellow);
            peshoPlayer.SaveCoordinates();

            SecondPlayer goshoPlayer = new SecondPlayer("Gosho", Color.DarkYellow);
            goshoPlayer.SaveCoordinates();

            Painter.DrawBoard();
            Painter.DrawFigures(true, peshoPlayer, 0);
            Painter.DrawFigures(true, goshoPlayer, 1);

            Board board = new Board(peshoPlayer, goshoPlayer);

            IPlayer currentPlayer = goshoPlayer; //first

            Controller controller = new Controller(peshoPlayer, goshoPlayer, currentPlayer, board);
            controller.Start();
        }

        private void FullScreen()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }
    }
}
