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

            var matrix = this.GetBoardMatrix(board);

            if (TryMoveWithoutObstacles(1, 1, matrix, newPos)) //upRight
            {
                this.Position = newPos;
                return true;
            }
            if (TryMoveWithoutObstacles(-1, 1, matrix, newPos)) //upLeft
            {
                this.Position = newPos;
                return true;
            }
            if (TryMoveWithoutObstacles(1, -1, matrix, newPos)) //downRight
            {
                this.Position = newPos;
                return true;
            }
            if (TryMoveWithoutObstacles(-1, -1, matrix, newPos)) //downLeft
            {
                this.Position = newPos;
                return true;
            }

            return false;
        }
    }
}