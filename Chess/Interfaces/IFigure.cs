using Chess.Common;

namespace Chess.Interfaces
{
    public interface IFigure
    {
        string StringRepresentation { get; }

        Position Position { get; set; }

        IPlayer Player { get; }

        Color Color { get; set; }

        bool Move(Position newPos, Board board);
    }
}
