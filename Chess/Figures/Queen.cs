namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Interfaces;

    public class Queen : IFigure
    {
        public string StringRepresentation => "♛";

        public Position Position { get; set; } = new Position();

        public Color Color { get; set; }

        public void Move(bool isFirstPlayer, int row, int col, int newRow, 
            int newCol, IFigure[,] board, IFigure figure, bool revivalNewFigure)
        {
            //TODO.
            board[row, col] = null;
            board[newRow, newCol] = figure;
        }
    }
}
