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

                var isRightBlocked = height + 1 == figure.Position.Height
                    && width + 1 == figure.Position.Width;

                bool isLeftBlocked = figure.Position.Height == height + 1
                    && figure.Position.Width == width - 1
                    && newHeight - 1 == figure.Position.Height
                    && newWidth + 1 == figure.Position.Width;

                if (isLeftBlocked || isRightBlocked)
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