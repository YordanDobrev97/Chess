namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Interfaces;
    using System;

    public class Rook : BasicFigure
    {
        public Rook(IPlayer player, Position pos)
            :base(player,pos)
        {
        }
        public override string StringRepresentation => "♖";
   
    }
}
