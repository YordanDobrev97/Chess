using Chess.Figures;
using System.Collections.Generic;

namespace ChessEngine.Engine.Figures
{
    public class Pawn : ISymbolRepresentation, IFigure
    {
        private List<string> validMoves;

        public Pawn()
        {
            this.validMoves = new List<string>();
        }

        public string Representation => Constants.PawnRepresentation;
        public string Name => "Pawn";
        public int Healt => Constants.HealFigure;

        public List<string> ValidMoves => this.validMoves;

        public void AddValidMove()
        {
            //TODO...
        }
    }
}
