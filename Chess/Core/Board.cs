namespace Chess
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;
    using System;

    public class Board
    {
        public IFigure[,] board;

        public Board(IPlayer firstPlayer, IPlayer secondPlayer, int size)
        {
            this.FirstPlayer = firstPlayer;
            this.SecondPlayer = secondPlayer;
            this.BoardSize = size;
            this.board = new IFigure[BoardSize, BoardSize];
            InitializeFigures(FirstPlayer, SecondPlayer);
        }

        public int BoardSize { get; }
        public IPlayer FirstPlayer { get; }
        public IPlayer SecondPlayer { get; }
        public void MoveFigure(string currentPosition, string newPosition, 
            bool isFirstPlayer)
        {
            int col = GetPositionCol(currentPosition);
            int row = GetPositionRow(currentPosition);

            int newCol = GetPositionCol(newPosition);
            int newRow = GetPositionRow(newPosition);

            IFigure currentFigure = board[row, col];

            if (currentFigure == null)
            {
                throw new ArgumentException("Invalid move!");
            }

            if (currentFigure is Bishop || currentFigure is Rook)
            {
                GlobalConstants.StartPosition = currentPosition;
                GlobalConstants.Destination = newPosition;
                //HACK
            }

            currentFigure.Move(isFirstPlayer, row, col, newRow, newCol, board, currentFigure);        
        }

        private int GetPositionRow(string currentPosition)
        {
            return this.BoardSize - (currentPosition[1] - '0');
        }

        private static int GetPositionCol(string currentPosition)
        {
            return currentPosition[0] - 'a';
        }

        private void InitializeFigures(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            int end = GlobalConstants.EndRowOfBoard;
            int row = GlobalConstants.StartRowOfBoard;
            int col = GlobalConstants.StartColOfBoard;

            for (int i = 0; i < firstPlayer.Figures.Count; i++)
            {
                if (i == end)
                {
                    row++;
                    col = GlobalConstants.StartColOfBoard;
                }
                this.board[row, col++] = firstPlayer.Figures[i];
            }

            row = GlobalConstants.EndRowOfBoard - 2;
            col = GlobalConstants.StartColOfBoard;

            for (int i = 0; i < secondPlayer.Figures.Count; i++)
            {
                if (i == end)
                {
                    row++;
                    col = GlobalConstants.StartColOfBoard;
                }
                this.board[row, col++] = secondPlayer.Figures[i];
            }
        }
    }
}