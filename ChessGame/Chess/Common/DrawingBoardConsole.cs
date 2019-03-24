namespace Chess.Common
{
    using ChessEngine;

    public static class DrawingBoardConsole
    {
        private static readonly int row = 2;
        private static readonly int column = 8;
        private static int y = 3;

        private static string[,] board = Board.GetBoard();

        public static void DrawBoard(int ROW_SIZE_BOARD_MATRIX, int COL_SIZE_BOARD_MATRIX, int x, int y)
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

        public static void DrawFigureOfBoard(string figureOfUser, int y)
        {
            if (figureOfUser == "Red")
            {
                //ViewUser.SetBackgroundColor(System.ConsoleColor.Red);
                //draw first blue figures
                DrawBoard(row, column, 0, 2);
                DrawFirstPartFigures(row, column, row, y);
                y += 2;
                DrawPawnFigure(row, column, row, y);

                //DrawBoard(row + row + row, column, 0, 2);

                //draw second red figures
                DrawBoard(row, column, 0, 14);
                DrawPawnFigure(row, column, row, 15);
                DrawFirstPartFigures(row, column, row, 17);
            }
            else
            {
                //ViewUser.SetBackgroundColor(System.ConsoleColor.Blue);
            }
            //ResetColor();
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
