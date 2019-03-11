using System.Collections.Generic;
using Chess.Figures;

namespace ChessEngine.Engine.Figures
{
    public class Horse : ISymbolRepresentation, IFigure
    {
        private List<string> validMoves;

        public Horse()
        {
            this.validMoves = new List<string>();
        }

        public string Representation => Constants.HorseRepresentation;

        public string Name => "Horse";

        public int Healt => Constants.HealFigure;

        public List<string> ValidMoves => this.validMoves;

        public void AddValidMove()
        {
            for (int i = 1; i <=8; i++)
            {
                this.validMoves.Add($"P{i}");
            }
        }
    }
}
