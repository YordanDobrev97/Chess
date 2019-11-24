namespace Chess.Core
{
    using Chess.Common;
    using Chess.Interfaces;
    using Chess.Movements;
    using System;

    public static class Moveable
    {
        public static void Move(IFigure currentFigure, int newRow, int newCol, int row, int col, IFigure[,] board)
        {
            var typeFigure = currentFigure.GetType();
            var figure = (IFigure)Activator.CreateInstance(typeFigure);

            Console.WriteLine();
            //switch (typeFigure.Name)
            //{
            //    case "Pawn":
            //        MovePawn(newRow, newCol, row, col, board);
            //        break;
            //    case "Knight":
            //        MoveKnight(newRow, newCol, row, col, board);
            //        break;
            //}
        }

        private static void MoveKnight(int newRow, int newCol, int row, int col, IFigure[,] board)
        {
            //is up move
            
        }

        private static void MovePawn(int newRow, int newCol, int row, int col, IFigure[,] board)
        {
            
        }


        private static void MoveBishop(IFigure currentFigure, int newCol1, int newCol2, IFigure[,] board)
        {
            throw new NotImplementedException();
        }

        private static void MoveKing(IFigure currentFigure, int newCol1, int newCol2, IFigure[,] board)
        {
            throw new NotImplementedException();
        }

        private static void MoveQueen(IFigure currentFigure, int newCol1, int newCol2, IFigure[,] board)
        {
            throw new NotImplementedException();
        }

        private static void MoveRook(IFigure currentFigure, int newCol1, int newCol2, IFigure[,] board)
        {
            throw new NotImplementedException();
        }

        private static bool InvalidUserMove(int row, int newRow)
        {
            return row - 2 > newRow;
        }

        private static bool IsUserDoubleMove(int newRow, int row)
        {
            return row - 2 == newRow;
        }

        private static bool IsCanMove(int newRow, int row)
        {
            return row >= newRow && newRow <= 7;
        }
    }
}
