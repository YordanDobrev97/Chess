using Chess.Figures;
using System.Collections.Generic;

namespace ChessEngine.Engine.Figures
{
    public class Rook : ISymbolRepresentation, IFigure
    {
        private List<string> validMoves;

        public Rook()
        {
            this.validMoves = new List<string>();
        }

        public string Representation => Constants.RookRepresentation;
        public string Name => "Rook";
        public int Healt => Constants.HealFigure;

        public List<string> ValidMoves => this.validMoves;

        public void AddValidMove()
        {
            //TODO...
        }
    }
}
