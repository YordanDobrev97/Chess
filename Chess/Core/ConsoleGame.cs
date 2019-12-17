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
        private Painter painter;

        public ConsoleGame()
        {
            this.painter = new Painter();
        }

        public void StartMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            FullScreen();
            painter.DrawAdminPanel();

            string userChoice = Console.ReadLine();

            if (userChoice == "Start Game")
            {
                Console.Clear();
                StartGame();
            }
            else if (userChoice == "Exit")
            {
                Environment.Exit(0);
            }
        }

        private void StartGame()
        {
            Console.Title = "Chess";
            Console.ForegroundColor = ConsoleColor.White;
            Console.OutputEncoding = Encoding.UTF8;

            SystemSetting.SetSettingOfFontMsGothic();
            IPlayer peshoPlayer = new FirstPlayer("Pesho", Color.Yellow);
            peshoPlayer.SaveCoordinates();

            IPlayer goshoPlayer = new SecondPlayer("Gosho", Color.DarkYellow);
            goshoPlayer.SaveCoordinates();

            Board board = new Board(peshoPlayer, goshoPlayer);

            painter.DrawBoard(board);
            painter.DrawFigures(true, peshoPlayer, 0);
            painter.DrawFigures(true, goshoPlayer, 1);

            

            IPlayer currentPlayer = goshoPlayer; //It starts first

            Controller controller = new Controller(board, painter);
            controller.Start();
        }

        private void FullScreen()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }
    }
}
