namespace ChessEngine.Engine.Figures
{
    using System.Collections.Generic;
    using Chess.Figures;
    using Chess.Interfaces;

    public class Officer : ISymbolRepresentation, IFigure, IMoving
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
        }

        public void Move(int count)
        {
            
        }

        public void Validate()
        {
            
        }
    }
}
