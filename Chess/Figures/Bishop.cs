namespace Chess.Figures
{
    using System;
    using System.Linq;
    using Chess.Interfaces;

    public class Bishop : BasicFigure
    {
        public override string StringRepresentation => "♝";

        public Bishop(IPlayer player, Position pos)
            : base(player, pos)
        {
        }

        public override bool Move(Position newPos, Board board)
        {
            if (this.PlayerHasFigureOnRequestedField(newPos)) return false;

            if (IsMoveDiagonal(newPos) && IsNotBlockedAnotherFigure(newPos, board))
            {
                this.Position = newPos;

                return true;
            }

            return false;
        }

        private bool IsNotBlockedAnotherFigure(Position newPos, Board board)
        {
            //TODO - Add logic to when a figure is blocked by another and cannot be moved
            return false;
        }

        private bool IsMoveDiagonal(Position position)
        {
            if (position.Width == this.Position.Width || position.Height == this.Position.Height)
            {
                //this move not diagonal
                return false;
            }

            return true;
        }
    }
}