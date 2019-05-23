using System.Collections.Generic;

namespace ChessEngine.Board.Figures
{
    public class Pawn : IFigure
    {
        public Pawn(string name)
        {
            this.Name = name;
        }

        public string StringRepresentation => "♙";

        public string Name { get; set; }

        public bool IsBeginState => true;
    }
}