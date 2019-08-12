using Chess.Figures;
using Chess.Interfaces;

namespace Chess
{
    public class Board
    {
        public readonly static IFigure[,] board = new IFigure[Controller.DEFAULT_VALUE, Controller.DEFAULT_VALUE];

        public Board()
        {
            IntilizateFigures();
        }

        public void MoveFigure(string currentPostion, string newPosition)
        {
            int col = currentPostion[0] - 'a';
            int row = Controller.DEFAULT_VALUE - (currentPostion[1] - '0');

            IFigure currentFigure = board[row, col];
        }

        private static void IntilizatePawns(int dimension)
        {
            for (int i = 0; i < Controller.DEFAULT_VALUE; i++)
            {
                board[dimension, i] = new Pawn();
            }
        }

        private static void IntilizateFigures()
        {
            board[0, 0] = new Rook();
            board[0, 1] = new Knight();
            board[0, 2] = new Bishop();
            board[0, 3] = new Queen();
            board[0, 4] = new King();
            board[0, 5] = new Bishop();
            board[0, 6] = new Knight();
            board[0, 7] = new Rook();
            IntilizatePawns(1); // pawns of first player

            IntilizatePawns(6); // pawns of second player
            board[7, 0] = new Rook();
            board[7, 1] = new Knight();
            board[7, 2] = new Bishop();
            board[7, 3] = new Queen();
            board[7, 4] = new King();
            board[7, 5] = new Bishop();
            board[7, 6] = new Knight();
            board[7, 7] = new Rook();
        }
    }
}
