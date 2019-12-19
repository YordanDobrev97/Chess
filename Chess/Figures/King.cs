namespace Chess.Figures
{
    using Chess.Interfaces;

    public class King : BasicFigure
    {
        public King(IPlayer player, Position pos)
            : base (player,pos)
        {
        }
        public override string StringRepresentation => "♚";

    }
}
