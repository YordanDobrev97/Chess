namespace Chess.Common
{
    using ChessEngine;
    using Logic;

    public static class DrawBoardConsole
    {
        private static string[,] board = Board.GetBoard();

        public static void DrawBoard(int ROW_SIZE_BOARD_MATRIX,
            int COL_SIZE_BOARD_MATRIX, int x,
        int y)
        {
            for (int row = 1; row <= ROW_SIZE_BOARD_MATRIX; row++)
            {
                for (int col = 1; col <= COL_SIZE_BOARD_MATRIX; col++)
                {
                    DrawBox(x, y);
                    x += 4;
                }
                x = 0;
                y += 2;
            }
        }

        public static void DrawFigureOfBoard()
        {
            ViewUser.SetBackgroundColor(System.ConsoleColor.Red);

            DrawFirstPartFigures(2,8,2, 3);
            DrawPawnFigure(2,8,2, 5);

            ResetColor();

            DrawBoard(2, 8, 0, 14);
            ViewUser.SetBackgroundColor(System.ConsoleColor.Blue);

            DrawPawnFigure(2,8,2, 15);
            DrawFirstPartFigures(2,8,2, 17);

            ResetColor();
        }

        private static void ResetColor()
        {
            ViewUser.ResetColorConsole();
        }

        private static void DrawPawnFigure(int ROW_SIZE_BOARD_MATRIX,
            int COL_SIZE_BOARD_MATRIX, int x, int y)
        {
            for (int i = 0; i < COL_SIZE_BOARD_MATRIX; i++)
            {
                string currentPaw = board[1, i];
                ViewUser.SetCursorPosition(x, y);
                ViewUser.WriteLine(currentPaw);
                x += 4;
            }
        }

        private static void DrawFirstPartFigures(int ROW_SIZE_BOARD_MATRIX,
            int COL_SIZE_BOARD_MATRIX, int x, int y)
        {
            for (int i = 0; i < COL_SIZE_BOARD_MATRIX; i++)
            {
                string currentFigure = board[0, i];
                ViewUser.SetCursorPosition(x, y);
                ViewUser.WriteLine(currentFigure);
                x += 4;
            }
        }

        private static void DrawBox(int x, int y)
        {
            ViewUser.SetCursorPosition(x, y);
            ViewUser.WriteLine("----");
            ViewUser.SetCursorPosition(x, y + 1);
            ViewUser.WriteLine("|  ");
            ViewUser.SetCursorPosition(x, y + 2);
            ViewUser.WriteLine("----");
        }
    }
}
