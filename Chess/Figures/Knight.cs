namespace Chess.Figures
{
    using Chess.Interfaces;  

    public class Knight : BasicFigure
    {
        public Knight(IPlayer player, Position pos)
            : base (player,pos)
        {
        }   

        public override string StringRepresentation => "♞";

    }
}
