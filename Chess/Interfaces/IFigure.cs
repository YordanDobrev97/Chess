using Chess.Common;

namespace Chess.Interfaces
{
    public interface IFigure
    {
        string StringRepresentation { get; }

        Position Position { get; set; }

        Color Color { get; set; }

        void Move(bool isFirstPlayer, int row, int col, int newRow, 
            int newCol, IFigure[,] board, IFigure figure, bool revivalNewFigure = false);
    }
}
