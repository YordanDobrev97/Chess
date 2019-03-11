using Chess.Figures;
using System.Collections.Generic;

namespace ChessEngine.Engine.Figures
{
    public class Queen : ISymbolRepresentation, IFigure
    {
        private List<string> validMoves;

        public Queen()
        {
            this.validMoves = new List<string>();
        }

        public string Representation => Constants.QueenRepresentation;
        public string Name => "Queen";
        public int Healt => Constants.HealFigure;

        public List<string> ValidMoves => this.validMoves;

        public void AddValidMove()
        {
            //TODO...
        }
    }
}
