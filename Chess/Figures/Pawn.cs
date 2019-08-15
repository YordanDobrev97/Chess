using Chess.Interfaces;

namespace Chess.Figures
{
    public class Pawn : IFigure
    {
        public Pawn()
        {
            this.HasInitialState = true;
        }

        public string StringRepresentation => "♙";

        public Position Position { get; set; } = new Position();

        public bool HasInitialState { get; set; }
    }
}
