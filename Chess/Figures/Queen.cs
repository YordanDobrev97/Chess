﻿namespace Chess.Figures
{
    using Chess.Interfaces;

    public class Queen : BasicFigure
    {
        public Queen(IPlayer player, Position pos)
            : base(player, pos)
        {
        }

        public override string StringRepresentation => "♛";

        public override bool Move(Position newPos, Board board)
        {
            if (this.PlayerHasFigureOnRequestedField(newPos)) return false;
            var matrix = this.GetBoardMatrix(board);
            var widthDirection = newPos.Width.CompareTo(this.Position.Width);
            var heightDirection = newPos.Height.CompareTo(this.Position.Height);
            if (TryMoveWithoutObstacles(widthDirection, heightDirection, matrix, newPos))
            {
                this.Position = newPos;
                return true;
            }           
            return false;
        }
    }
}
