namespace Chess.Figures
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
            if (TryMoveWithoutObstacles(0, 1, matrix, newPos)) //up
            {
                this.Position = newPos;
                return true;
            }
            if (TryMoveWithoutObstacles(0, -1, matrix, newPos)) //down
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

        // A basic check route function
        // Directions can be:
        // * widthDirection  =-1 -> left; =0 -> no change; =1 -> right
        // * heightDirection =-1 -> down; =0 -> no change; =1 -> up
        // probably needs to be moved in BasicFigure class because can be used also from bishops and queens

        private bool TryMoveWithoutObstacles(int widthDirection, int heightDirection, IFigure[,] matrix, Position newPos)
        {
            int width = this.Position.Width + widthDirection;
            int height = this.Position.Height + heightDirection;
            while (width >= 0 && width < matrix.GetLength(0) && height >= 0 && height < matrix.GetLength(1))
            {
                if (width == newPos.Width && height == newPos.Height) return true; //reached requested field
                if (matrix[width, height] != null) return false; // a figure on route
                width += widthDirection;
                height += heightDirection;
            }
            return false; // requested field not on route
        }
    }
}
