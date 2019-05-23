using System.Collections.Generic;

namespace ChessEngine.Board.Figures
{
    public class Horse : IFigure
    {
        public Horse(string name)
        {
            this.Name = name;
        }
        public string StringRepresentation => "♘";

        public string Name { get; set; }

        public bool IsBeginState => true;
    }
}