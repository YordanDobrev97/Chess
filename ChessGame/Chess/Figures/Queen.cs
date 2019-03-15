namespace ChessEngine.Engine.Figures
{
    using Chess.Figures;
    using Chess.Interfaces;
    using System.Collections.Generic;

    public class Queen : ISymbolRepresentation, IFigure, IMoving
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
        

        public void Move(int count)
        {
            
        }

        public void Validate()
        {

        }
    }
}
