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
            if (this.Player.Figures.Any(x => x.Position.Width == newPos.Width && x.Position.Height == newPos.Height))
                return false;

            this.Position = newPos;
            return true;
        }
    }
}
