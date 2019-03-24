namespace Chess.Common
{
    using Chess.Controller;
    using System;
    using System.Threading;

    public static class ViewUser
    {
        public static void ViewUserInvalidMovementMessage()
        {
            Console.WriteLine("Sorry, Invalid move!");
        }

        public static void SetCursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        public static void MessageUser(string message)
        {
            Console.Write(message);
        }

        public static string ConsoleReadLine()
        {
            string line = Console.ReadLine();

            return line;
        }

        public static void SetBackgroundColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static void ConsoleClear()
        {
            Console.Clear();
        }

        public static void SleepConsole(int time)
        {
            Thread.Sleep(time);
        }

        public static void ViewException()
        {
            MessageExceptionUser.MessageExceptionOfUser();
        }

        public static void ResetColorConsole()
        {
            Console.ResetColor();
        }

        public static void WriteLine(string currentPaw)
        {
            Console.WriteLine(currentPaw);
        }
    }
}