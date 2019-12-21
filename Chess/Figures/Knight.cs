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

        public override bool Move(Position newPos, Board board)
        {
            //TODO - You have to think about how to reduce the copying of code, because things are repeated in a lot of places
            // the logic of TryMoveWithoutObstacles is not suitable for knights. They allways jump over other figures.
            if (this.PlayerHasFigureOnRequestedField(newPos)) return false;

            var matrix = this.GetBoardMatrix(board);
            if (TryMoveWithoutObstacles(1, 2, matrix, newPos)) //upRight
            {
                this.Position = newPos;
                return true;
            }
            if (TryMoveWithoutObstacles(-1, 2, matrix, newPos)) //upLeft
            {
                this.Position = newPos;
                return true;
            }
            if (TryMoveWithoutObstacles(1, -2, matrix, newPos)) //downRight
            {
                this.Position = newPos;
                return true;
            }
            if (TryMoveWithoutObstacles(-1, -2, matrix, newPos)) //downLeft
            {
                this.Position = newPos;
                return true;
            }

            return false;
        }
    }
}
