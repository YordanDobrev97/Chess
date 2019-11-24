namespace Chess.Interfaces
{
    public interface IMovement
    {
        void Move(int newRow, int newCol, int row, int col, IFigure[,] board);
    }
}
