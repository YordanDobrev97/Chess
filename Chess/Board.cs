using Chess.Figures;
using Chess.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace Chess
{
    public class Board
    {
        public static IFigure[,] board = new IFigure[Controller.DEFAULT_VALUE, Controller.DEFAULT_VALUE];

        public Board()
        {
            InitializeFigures();
        }

        public void MoveFigure(string currentPosition, string newPosition, bool isFirstPlayer)
        {
            int col = currentPosition[0] - 'a';
            int row = Controller.DEFAULT_VALUE - (currentPosition[1] - '0');

            int newCol = newPosition[0] - 'a';
            int newRow = Controller.DEFAULT_VALUE - (newPosition[1] - '0');

            IFigure currentFigure = board[row, col];
            var type = currentFigure.GetType().Name;


            switch (type)
            {
                case "Pawn":
                    int currentMovePawn = newPosition[1] - '0';
                    int currentRow = currentPosition[1] - '0';
                    if (!Validator.IsValidMoveOfPawn(currentFigure, currentRow, 
                        col, currentMovePawn, newCol, isFirstPlayer))
                    {
                        throw new ArgumentException("Invalid move of pawn! Try again");
                    }

                    board[row, col] = null;
                    board[newRow, newCol] = currentFigure;

                    var pawn = currentFigure as Pawn;

                    if (HasDoubleMoveFromUser(newRow, pawn))
                    {
                        DoubleMove(currentFigure);
                    }
                    else
                    {
                        SingleMove(currentFigure, isFirstPlayer);
                    }

                    pawn.HasInitialState = false;
                    board[newRow, newCol] = pawn;

                    break;
            }

            Painter.DrawFigures(false);
        }

        private static void DoubleMove(IFigure currentFigure)
        {
            currentFigure.Position.Height -= 6;
        }

        private static bool HasDoubleMoveFromUser(int newRow, Pawn pawn)
        {
            return pawn.HasInitialState && newRow == 4;
        }

        private static void SingleMove(IFigure currentFigure, bool isFirstPlayer)
        {
            if (isFirstPlayer)
            {
                currentFigure.Position.Height -= 3;
            }
            else
            {
                currentFigure.Position.Height += 3;
            }
        }

        private static void InitializeFigures()
        {
            int end = 8;
            int row = 0;
            int col = 0;
            for (int i = 0; i < Painter.figuresOfFirstPlayer.Length; i++)
            {
                if (i == end)
                {
                    row++;
                    col = 0;
                }
                board[row, col++] = Painter.figuresOfFirstPlayer[i];
            }

            row = 6;
            col = 0;
            for (int i = 0; i < Painter.figuresOfSecondPlayer.Length; i++)
            {
                if (i == end)
                {
                    row++;
                    col = 0;
                }
                board[row, col++] = Painter.figuresOfSecondPlayer[i];
            }
        }
    }
}