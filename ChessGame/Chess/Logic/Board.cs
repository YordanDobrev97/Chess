﻿namespace ChessEngine
{
    using Chess.Common;
    using Chess.Interfaces;
    using ChessEngine.Engine.Figures;
    
    public class Board : IBoard
    {
        private int ROW_SIZE_BOARD_MATRIX = 2;
        private int COL_SIZE_BOARD_MATRIX = 8;
       
        private string[,] board;

        public Board()
        {
            board = new string[ROW_SIZE_BOARD_MATRIX, COL_SIZE_BOARD_MATRIX];
        }

        public void LoadingBoard()
        {
            FillBoardMatrix();
            DrawBoardConsole();
            DrawFigureOfBoard();
        }

        private void DrawFigureOfBoard()
        {
            ViewUser.SetBackgroundColor(System.ConsoleColor.Red);

            DrawFirstPartFigures(2, 3);
            DrawPawnFigure(2, 5);

            ResetColor();

            ViewUser.SetBackgroundColor(System.ConsoleColor.Blue);

            DrawPawnFigure(2, 15);
            DrawFirstPartFigures(2, 17);

            ResetColor();
        }

        private static void ResetColor()
        {
            ViewUser.ResetColorConsole();
        }

        private void DrawPawnFigure(int x, int y)
        {
            for (int i = 0; i < COL_SIZE_BOARD_MATRIX; i++)
            {
                string currentPaw = board[1, i];
                ViewUser.SetCursorPosition(x, y);
                ViewUser.WriteLine(currentPaw);
                x += 4;
            }
        }

        private void DrawFirstPartFigures(int x, int y)
        {
            for (int i = 0; i < COL_SIZE_BOARD_MATRIX; i++)
            {
                string currentFigure = board[0, i];
                ViewUser.SetCursorPosition(x, y);
                ViewUser.WriteLine(currentFigure);
                x += 4;
            }
        }

        private void FillBoardMatrix()
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

        private void DrawBoardConsole()
        {
            int x = 0;
            int y = 2;
            for (int row = 1; row <= COL_SIZE_BOARD_MATRIX; row++)
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

        private void DrawBox(int x, int y)
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