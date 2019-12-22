namespace Chess.Figures
{
    using Chess.Interfaces;
    using System;

    public class King : BasicFigure
    {
        public King(IPlayer player, Position pos)
            : base (player,pos)
        {
        }
        public override string StringRepresentation => "♚";
        public override bool Move(Position newPos, Board board)
        {
            if (this.PlayerHasFigureOnRequestedField(newPos)) return false;
            var widthDirection = Math.Abs(newPos.Width - this.Position.Width);
            var heightDirection = Math.Abs(newPos.Height - this.Position.Height);
            if (widthDirection <= 1 && heightDirection <=1)
            {
                this.Position = newPos;
                return true;
            }
            return false;
        }
    }
}
