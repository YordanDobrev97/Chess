using Chess.Common;
using Chess.Interfaces;
using System.Linq;

namespace Chess.Figures
{
    public abstract class BasicFigure : IFigure
    {
        protected BasicFigure(IPlayer player, Position pos)
        {
            this.Player = player;
            this.Position = pos;
        }
        public abstract string StringRepresentation { get;}

        public Position Position { get ; set; }

        public IPlayer Player { get;}

        public Color Color { get; set; }
        public virtual bool Move(Position newPos,Board board)
        {
            // basic Move function -> everywhere except over his own figures
            if (this.PlayerHasFigureOnRequestedField(newPos)) return false;

            this.Position = newPos;
            return true;
        }

        protected bool PlayerHasFigureOnRequestedField(Position newPos)
        {
            if (this.Player.Figures.Any(x => x.Position.Width == newPos.Width 
            && x.Position.Height == newPos.Height))
                return true;
            return false;
        }

        protected IFigure[,] GetBoardMatrix(Board board)
        {
            var matrix = new IFigure[board.BoardSize, board.BoardSize];
            foreach (var item in board.FirstPlayer.Figures)
            {
                matrix[item.Position.Width, item.Position.Height] = item;
            }
            foreach (var item in board.SecondPlayer.Figures)
            {
                matrix[item.Position.Width, item.Position.Height] = item;
            }
            return matrix;
        }

        // A basic check route function
        // Directions can be:
        // * widthDirection  =-1 -> left; =0 -> no change; =1 -> right
        // * heightDirection =-1 -> down; =0 -> no change; =1 -> up
        protected bool TryMoveWithoutObstacles(int widthDirection, int heightDirection, IFigure[,] matrix, Position newPos)
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
