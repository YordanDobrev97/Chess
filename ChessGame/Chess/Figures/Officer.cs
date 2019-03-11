using System.Collections.Generic;
using Chess.Figures;

namespace ChessEngine.Engine.Figures
{
    public class Officer : ISymbolRepresentation, IFigure
    {
        private List<string> validMoves;

        public Officer()
        {
            this.validMoves = new List<string>();
        }

        public string Representation => Constants.OfficerRepresentation;
        public string Name => "Officer";
        public int Healt => Constants.HealFigure;
        public List<string> ValidMoves => this.validMoves;

        public void AddValidMove()
        {
            //TODO...
        }
    }
}
