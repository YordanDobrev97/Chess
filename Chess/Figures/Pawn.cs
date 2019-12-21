
namespace Chess.Figures
{
    using Chess.Interfaces;

    public class Pawn : BasicFigure
    {
        public Pawn(IPlayer player, Position pos)
            :base(player,pos)
        {
        }

        public override string StringRepresentation => "♙";

        public bool HasInitialState { get; set; }

        public override bool Move(Position newPos, Board board)
        {
            if (this.PlayerHasFigureOnRequestedField(newPos)) return false;
            int direction = GetPawnsDirection(board);
            var matrix = this.GetBoardMatrix(board);
            
            if((newPos.Width == this.Position.Width 
                    && newPos.Height == this.Position.Height+(direction*2))
                    && this.HasInitialState)
                {
                    if (matrix[this.Position.Width, this.Position.Height + direction] != null 
                        || matrix[this.Position.Width, this.Position.Height + (direction*2)] != null) 
                        return false;                        
                    this.MoveToNewPosition(newPos);
                    return true;                
                }            
           
               if (newPos.Width == this.Position.Width && newPos.Height == this.Position.Height+direction)
                {
                    if (matrix[this.Position.Width, this.Position.Height + direction] != null) return false;
                    this.MoveToNewPosition(newPos);
                    return true;
                }
                if (newPos.Width == this.Position.Width-1 && newPos.Height == this.Position.Height + direction)
                {
                    if (matrix[newPos.Width, newPos.Height] != null)
                    {
                        this.MoveToNewPosition(newPos);
                        return true;
                    }
                }
                if (newPos.Width == this.Position.Width + 1 && newPos.Height == this.Position.Height + direction)
                {
                    if (matrix[newPos.Width, newPos.Height] != null)
                    {
                        this.MoveToNewPosition(newPos);
                        return true;
                    }
                
            }
            return false;
        }

        private void MoveToNewPosition(Position newPos)
        {
            this.Position = newPos;
            this.HasInitialState = false;
        }
        private int GetPawnsDirection(Board board)
        {
            if (this.Player == board.FirstPlayer) return 1;
            return -1;
        }

        private static bool RevivalInNewFigure(int newRow, int newCol, IFigure[,] board)
        {
            // return newRow == 0 && board[newRow, newCol].Color is Color.DarkYellow;
            return false;
        }       
    }
}
