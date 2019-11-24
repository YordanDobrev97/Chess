namespace Chess.IO
{
    using System;
    using System.Threading;

    public class ConsoleIO
    {
        public static string ReadFromConsole()
        {
            return Console.ReadLine();
        }

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

        public static void Sleep(int time)
        {
            Thread.Sleep(time);
        }

        public static void SetBufferSize(int width, int height)
        {
            Console.SetBufferSize(width, height);
        }
    }
}
