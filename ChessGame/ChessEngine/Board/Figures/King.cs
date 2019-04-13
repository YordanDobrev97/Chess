using System.Collections.Generic;

namespace ChessEngine.Board.Figures
{
    public class King : IFigure
    {
        public King(string name)
        {
            this.Name = name;
        }

        public string StringRepresentation => "♚";

        public string Name { get; set; }
    }
}
