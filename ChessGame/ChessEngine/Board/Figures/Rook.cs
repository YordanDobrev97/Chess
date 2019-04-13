using System.Collections.Generic;

namespace ChessEngine.Board.Figures
{
    public class Rook : IFigure
    {
        public Rook(string name)
        {
            this.Name = name;
        }

        public string StringRepresentation => "♖";

        public string Name { get; set; }
    }
}
