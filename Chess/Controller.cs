using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Chess.Interfaces;

namespace Chess
{
    public abstract class Controller
    {
        public const int DEFAULT_VALUE = 8;
        private const int STD_OUTPUT_HANDLE = -11;
        private const int TMPF_TRUETYPE = 4;
        private const int LF_FACESIZE = 32;
        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_CLOSE = 0xF060;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_SIZE = 0xF000;
        //Const, struct and dll imported files needed for more advannced settings on the console 
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal unsafe struct CONSOLE_FONT_INFO_EX
        {
            internal uint cbSize;
            internal uint nFont;
            internal COORD dwFontSize;
            internal int FontFamily;
            internal int FontWeight;
            internal fixed char FaceName[LF_FACESIZE];
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct COORD
        {
            internal short X;
            internal short Y;

            internal COORD(short x, short y)
            {
                X = x;
                Y = y;
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetCurrentConsoleFontEx(
            IntPtr consoleOutput,
            bool maximumWindow,
            ref CONSOLE_FONT_INFO_EX consoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int dwType);


        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int SetConsoleFont(
            IntPtr hOut,
            uint dwFontNum
        );

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        public static void Start()
        {
            SetConsoleSettings();
            Painter.DrawBoard();
            Painter.DrawFigures(true);

            Board board = new Board();
            
            while (true)
            {
                Console.SetCursorPosition(2, 26);

                Console.Write("Enter your move: ");
                string[] userMove = Console.ReadLine().Split();
                string currentPosition = userMove[0];
                string newPosition = userMove[1];
                board.MoveFigure(currentPosition, newPosition);
            }
        }

        private static void SetConsoleSettings()
        {
            //SetWindowSize and SetBufferSize should be the same, otherwise the scrollbar will appear
            //If resize is not prevented in this method the scrollbar will appear if resize by user!
            Console.SetWindowSize(84, 28);
            Console.SetBufferSize(84, 28);
            //Set the font
            SetConsoleFont();
            //Prevent user from closing/minimizing/maximizing/resizing the console
            //Permissions can be edited in the next if check
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                //Prevent close(currently off)
                //DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);

                //Prevent minimize(currently off)
                //DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);

                //Prevent maximize(currently off)
                //DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);

                //Prevent resize by the user(currently on)
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
        }
        //Font name
        private const string FONT_NAME = "MS Gothic";

        private static void SetConsoleFont(string fontName = FONT_NAME)
        {
            unsafe
            {
                IntPtr hnd = GetStdHandle(STD_OUTPUT_HANDLE);
                if (hnd != INVALID_HANDLE_VALUE)
                {
                    CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
                    info.cbSize = (uint)Marshal.SizeOf(info);

                    // Set console font to MS Gothic.
                    CONSOLE_FONT_INFO_EX newInfo = new CONSOLE_FONT_INFO_EX();
                    newInfo.cbSize = (uint)Marshal.SizeOf(newInfo);
                    newInfo.FontFamily = TMPF_TRUETYPE;
                    IntPtr ptr = new IntPtr(newInfo.FaceName);
                    Marshal.Copy(fontName.ToCharArray(), 0, ptr, fontName.Length);

                    // Get some settings from current font.
                    newInfo.dwFontSize = new COORD(info.dwFontSize.X, info.dwFontSize.Y);
                    newInfo.FontWeight = info.FontWeight;
                    SetCurrentConsoleFontEx(hnd, false, ref newInfo);
                }
            }
            
        }
        public static void SaveDefaultCoordinatesFigures<T>()
        {
            CoordinatesOfFirstPlayer<T>();

            CoordinatesOfSecondPlayer<T>();
        }

        private static void CoordinatesOfSecondPlayer<T>()
        {
            int startValuePawnPosition = 5;
            for (int i = 0; i < 8; i++)
            {
                var currentPawn = Painter.figuresOfSecondPlayer[i];
                currentPawn.Position.Width = startValuePawnPosition;
                currentPawn.Position.Height = 20;
                startValuePawnPosition += 10;
            }

            int startIndex = 8;
            int positionFigure = 5;
            for (int i = 0; i < 8; i++)
            {
                var currentFigure = Painter.figuresOfSecondPlayer[startIndex];
                currentFigure.Position.Width = positionFigure;
                currentFigure.Position.Height = 23;
                positionFigure += 10;
                startIndex++;
            }
        }

        private static void CoordinatesOfFirstPlayer<T>()
        {
            int position = 5; // default start value
            for (int i = 0; i < 8; i++)
            {
                var figure = Painter.figuresOfFirstPlayer[i]; //figures[i];
                figure.Position.Width = position;
                figure.Position.Height = 2;
                position += 10;
            }

            //save coordinates of pawns
            int pawnStartValue = 5;
            int startIndex = 8;
            for (int i = 0; i < 8; i++)
            {
                var pawn = Painter.figuresOfFirstPlayer[startIndex]; // get pawn
                pawn.Position.Width = pawnStartValue;
                pawn.Position.Height = 5;
                pawnStartValue += 10;
                startIndex++;
            }
        }
    }
}