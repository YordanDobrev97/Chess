
namespace Chess.Figures
{
    using Chess.Common;
    using Chess.Interfaces;

    public class Pawn : BasicFigure
    {
        public Pawn(IPlayer player, Position pos)
            :base(player,pos)
        {
        }

        public override string StringRepresentation => "♙";

        public bool HasInitialState { get; set; }
       

        private static bool RevivalInNewFigure(int newRow, int newCol, IFigure[,] board)
        {
            // return newRow == 0 && board[newRow, newCol].Color is Color.DarkYellow;
            return false;
        }       
    }
}
