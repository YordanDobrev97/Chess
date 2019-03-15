
namespace ChessEngine.Engine.Figures
{
    using System.Collections.Generic;
    using Chess.Figures;
    using Chess.Interfaces;

    public class Horse : ISymbolRepresentation, IFigure, IMoving
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
        
        public void Move(int count)
        {
            
        }

        public void Validate()
        {
            
        }
    }
}
