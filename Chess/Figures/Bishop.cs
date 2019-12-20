namespace Chess.Figures
{
    using Chess.Interfaces;
    using System;

    public class Bishop : BasicFigure
    {
        public override string StringRepresentation => "♝";

        public Bishop(IPlayer player, Position pos)
            : base(player, pos)
        {
        }

        public static IFigure CurrentBishop { get; set; }

        public override bool Move(Position newPos, Board board)
        {
            if (this.PlayerHasFigureOnRequestedField(newPos)) return false;

            if (IsMoveDiagonal(newPos) && !IsBlockedAnotherFigure(newPos, board))
            {
                this.Position = newPos;

                return true;
            }

            return false;
        }

        private bool IsBlockedAnotherFigure(Position newPos, Board board)
        {
            foreach (var figure in this.Player.Figures)
            {
                var height = CurrentBishop.Position.Height;
                var width = CurrentBishop.Position.Width;

                var newHeight = newPos.Height;
                var newWidth = newPos.Width;

                bool isBlocked = 
                    figure.Position.Height == (height <= figure.Position.Height ? height + 1 : height - 1) 
                    && figure.Position.Width == (width >= figure.Position.Width ? width - 1 : width + 1)
                    && (newHeight >= figure.Position.Height ? newHeight - 1 : newHeight + 1) == figure.Position.Height
                    && (newWidth <= figure.Position.Width ? newWidth + 1 : newWidth - 1) == figure.Position.Width;

                if (isBlocked)
                {
                    return true;
                }
            }

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