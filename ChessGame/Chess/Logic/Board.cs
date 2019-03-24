namespace ChessEngine
{
    using System;
    using Chess.Common;
    using Chess.Interfaces;
    using ChessEngine.Engine.Figures;

    public class Board : IBoard
    {
        private int ROW_SIZE_BOARD_MATRIX = 2;
        private int COL_SIZE_BOARD_MATRIX = 8;

        private static string[,] board;

        public Board()
        {
            board = new string[ROW_SIZE_BOARD_MATRIX, COL_SIZE_BOARD_MATRIX];
        }

        public int RowSizeBoard => this.ROW_SIZE_BOARD_MATRIX;

        public int ColSizeBoard => this.COL_SIZE_BOARD_MATRIX;

        public void LoadingFigures()
        {
            FillMatrixValues();
        }

        public void InitilizateBoard(int x, int y)
        {
            DrawBoard(x, y);
        }

        public void DrawBoard(int x, int y)
        {
            Top(x, y);
            y = 2;
            Middle(x, y);
            y = 14;
            Down(x, y);
        }

        private void Middle(int x, int y)
        {
            DrawingBoardConsole.DrawBoard(RowSizeBoard + RowSizeBoard + RowSizeBoard, ColSizeBoard, x, y);
        }

        public static string[,] GetBoard()
        {
            return board;
        }

        private void Down(int x, int y)
        {
            DrawingBoardConsole.DrawBoard(RowSizeBoard, ColSizeBoard, x, y);
        }

        private void Top(int x, int y)
        {
            DrawingBoardConsole.DrawBoard(RowSizeBoard, ColSizeBoard, x, y);
        }

        private void FillMatrixValues()
        {
            board[0, 0] = new Rook().Representation;
            board[0, 1] = new Horse().Representation;
            board[0, 2] = new Officer().Representation;
            board[0, 3] = new Queen().Representation;
            board[0, 4] = new King().Representation;
            board[0, 5] = new Officer().Representation;
            board[0, 6] = new Horse().Representation;
            board[0, 7] = new Rook().Representation;

            for (int i = 0; i < 8; i++)
            {
                board[1, i] = new Pawn().Representation;
            }

        }
    }
}
