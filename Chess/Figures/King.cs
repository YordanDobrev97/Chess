namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Interfaces;
    using System;

    public class King : BasicFigure
    {
        public King(IPlayer player, Position pos)
            : base (player,pos)
        {
        }
        public override string StringRepresentation => "♚";

    }
}
