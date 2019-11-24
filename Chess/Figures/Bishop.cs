namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Interfaces;

    public class Bishop : IFigure
    {
        public string StringRepresentation => "♝";

        public Bishop()
        {
            this.Position = new Position();
        }

        public Position Position { get; set; }

        public Color Color { get; set; }

        public void Move(bool isFirstPlayer,int row, int col, int newRow, int newCol, IFigure[,] board, IFigure figure)
        {
            if (isFirstPlayer)
            {
                figure.Position.Width -= 10;
                figure.Position.Height -= 3;
            }
            //TODO..
            board[row, col] = null;
            board[newRow, newCol] = figure; 
        }
    }
}
