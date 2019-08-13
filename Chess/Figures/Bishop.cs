using Chess.Interfaces;

namespace Chess.Figures
{
    public class Bishop : IFigure
    {
        public string StringRepresentation => "♝";

        public Position Position { get; set; } = new Position();
    }
}
