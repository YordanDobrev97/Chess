using Chess.Common;
using Chess.Figures;
using Chess.Interfaces;

namespace Chess
{
    public class Board
    {
        public static IFigure[,] board = new IFigure[GlobalConstants.DefaultValueSizeOfBoard, GlobalConstants.DefaultValueSizeOfBoard];

        public Board()
        {
            InitializeFigures();
        }

        public void MoveFigure(string currentPosition, string newPosition, bool isFirstPlayer)
        {
            int col = GetPositionCol(currentPosition);
            int row = GetPositionRow(currentPosition);

            int newCol = GetPositionCol(newPosition);
            int newRow = GetPositionRow(newPosition);

            IFigure currentFigure = board[row, col];
            var type = currentFigure.GetType().Name;

            bool hasTakingPawn = false;
            switch (type)
            {
                case "Pawn":
                    int currentMovePawn = newPosition[1] - '0';
                    int currentRow = currentPosition[1] - '0';

                    if (!Validator.IsValidMoveOfPawn(currentFigure, currentRow,
                        col, currentMovePawn, newCol, isFirstPlayer))
                    {
                        Exception.ThrowInvalidMoveException();
                    }

                    //is have other pawn
                    if (board[newRow, newCol] is Pawn)
                    {
                        hasTakingPawn = true;
                        string takenPlayer = isFirstPlayer ? "First player" : "Second player";
                        Painter.WriteConsole($"The pawn was taken from {takenPlayer}");
                        Painter.Sleep(GlobalConstants.TimeSleepConsole);
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
                        SingleMove(currentFigure, isFirstPlayer, hasTakingPawn);
                    }

                    pawn.HasInitialState = false;
                    board[newRow, newCol] = pawn;
                    break;
            }

            Painter.DrawFigures(false);
        }

        private static int GetPositionRow(string currentPosition)
        {
            return GlobalConstants.DefaultValueSizeOfBoard - (currentPosition[1] - '0');
        }

        private static int GetPositionCol(string currentPosition)
        {
            return currentPosition[0] - 'a';
        }

        private static void DoubleMove(IFigure currentFigure)
        {
            currentFigure.Position.Height -= GlobalConstants.CurrentFigurePositionHeight;
        }

        private static bool HasDoubleMoveFromUser(int newRow, Pawn pawn)
        {
            return pawn.HasInitialState && newRow == GlobalConstants.RowDoubleMoveUser;
        }

        private static void SingleMove(IFigure currentFigure, bool isFirstPlayer, bool hasTaking)
        {
            if (isFirstPlayer)
            {
                if (hasTaking)
                {
                    currentFigure.Position.Width += GlobalConstants.IncrementPositionWidthSingleMove;
                }
                currentFigure.Position.Height -= GlobalConstants.DecrementPositionHeightSingleMove;
            }
            else
            {
                currentFigure.Position.Height += GlobalConstants.DecrementPositionHeightSingleMove;
            }
        }

        private static void InitializeFigures()
        {
            int end = GlobalConstants.EndRowOfBoard;
            int row = GlobalConstants.StartRowOfBoard;
            int col = GlobalConstants.StartColOfBoard;

            for (int i = 0; i < Painter.figuresOfFirstPlayer.Length; i++)
            {
                if (i == end)
                {
                    row++;
                    col = GlobalConstants.StartColOfBoard;
                }
                board[row, col++] = Painter.figuresOfFirstPlayer[i];
            }

            row = GlobalConstants.EndRowOfBoard - 2;
            col = GlobalConstants.StartColOfBoard;

            for (int i = 0; i < Painter.figuresOfSecondPlayer.Length; i++)
            {
                if (i == end)
                {
                    row++;
                    col = GlobalConstants.StartColOfBoard;
                }
                board[row, col++] = Painter.figuresOfSecondPlayer[i];
            }
        }
    }
}