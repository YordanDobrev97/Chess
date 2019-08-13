using Chess.Interfaces;

namespace Chess.Figures
{
    public class Queen : IFigure
    {
        public string StringRepresentation => "♛";

        public Position Position { get; set; } = new Position();
    }
}
