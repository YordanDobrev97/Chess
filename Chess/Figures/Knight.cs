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
            var widthDirection = newPos.Width.CompareTo(this.Position.Width);
            var heightDirection = newPos.Height.CompareTo(this.Position.Height);

            if (widthDirection == 0 || heightDirection == 0) return false;
            if ((newPos.Width == this.Position.Width+(widthDirection*2) 
                && newPos.Height == this.Position.Height+heightDirection)
                || (newPos.Width == this.Position.Width + widthDirection 
                && newPos.Height == this.Position.Height + (heightDirection*2)))
            {
                this.Position = newPos;
                return true;
            }
            return false;
        }
    }
}
