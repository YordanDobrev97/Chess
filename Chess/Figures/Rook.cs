namespace Chess.Figures
{
    using Chess.Interfaces;

    public class Rook : BasicFigure
    {
        public Rook(IPlayer player, Position pos)
            :base(player,pos)
        {
        }
        public override string StringRepresentation => "♖";
   
    }
}
