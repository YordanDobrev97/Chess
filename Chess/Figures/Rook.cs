namespace Chess.Figures
{
    using Chess.Interfaces;

    public class Rook : BasicFigure
    {
        public Rook(IPlayer player, Position pos)
            :base(player,pos)
        {
        }
        public override string StringRepresentation => "♖";

        public override bool Move(Position newPos, Board board)
        {
            if (this.PlayerHasFigureOnRequestedField(newPos)) return false;
            var matrix = this.GetBoardMatrix(board);
            if (TryMoveWithoutObstacles(0, 1, matrix, newPos)) //up
            {
                this.Position = newPos;
                return true;
            }
            if(TryMoveWithoutObstacles(0, -1, matrix, newPos)) //down
            {
                this.Position = newPos;
                return true;
            }
            if (TryMoveWithoutObstacles(-1, 0, matrix, newPos)) //left
            {
                this.Position = newPos;
                return true;
            }
            if (TryMoveWithoutObstacles(1, 0, matrix, newPos)) //right
            {
                this.Position = newPos;
                return true;
            }
            return false;
        }
    }
}
