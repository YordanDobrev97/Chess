namespace Chess.Figures
{
    using Chess.Interfaces;

    public class Queen : BasicFigure
    {
        public Queen(IPlayer player, Position pos)
            : base(player, pos)
        {
        }

        public override string StringRepresentation => "♛";       

    }
}
