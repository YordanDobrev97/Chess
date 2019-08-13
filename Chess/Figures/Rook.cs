using Chess.Interfaces;

namespace Chess.Figures
{
    public class Rook : IFigure
    {
        public string StringRepresentation => "♖";

        public Position Position { get; set; } = new Position();
    }
}
