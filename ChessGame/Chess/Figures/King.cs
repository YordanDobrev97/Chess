using System.Collections.Generic;
using Chess.Figures;

namespace ChessEngine.Engine.Figures
{
    public class King : ISymbolRepresentation, IFigure
    {
        private List<string> validMoves;

        public King()
        {
            this.validMoves = new List<string>();
        }

        public string Representation => Constants.KingRepresentation;
        public string Name => "King";
        public int Healt => Constants.HealFigure;
        public List<string> ValidMoves => this.validMoves;

        public void AddValidMove()
        {
            //TODO...
        }
    }
}
