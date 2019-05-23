using System.Collections.Generic;

namespace ChessEngine.Board.Figures
{
    public class Queen : IFigure
    {
        public Queen(string name)
        {
            this.Name = name;
        }

        public string StringRepresentation => "♕";

        public string Name { get; set; }

        public bool IsBeginState => true;
    }
}