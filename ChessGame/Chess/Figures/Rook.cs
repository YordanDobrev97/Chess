using Chess.Figures;
using Chess.Interfaces;
using System.Collections.Generic;

namespace ChessEngine.Engine.Figures
{
    public class Rook : ISymbolRepresentation, IFigure, IMoving
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

        public void Move(int count)
        {
            
        }

        public void Validate()
        {
            
        }
    }
}
