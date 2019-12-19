namespace Chess.Figures
{
    using Chess.Interfaces;

    public class Bishop : BasicFigure
    {
        public override string StringRepresentation => "♝";

        public Bishop(IPlayer player, Position pos) 
            : base(player, pos)
        {
        }        

    }
}
