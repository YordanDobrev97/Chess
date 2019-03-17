namespace ChessEngine.Engine.Figures
{
    using Chess.Common;
    using Chess.Figures;
    using Chess.Interfaces;

    public class Pawn : ISymbolRepresentation, IFigure, IRule
    {
        private const int MAX_MOVE = 2;
        
        public string Representation => Constants.PawnRepresentation;
        public string Name => "Pawn";
        public int Healt => Constants.HealFigure;

        public string RulePerMove
        {
            get
            {
                return "UP";
            }
        }
    }
}
