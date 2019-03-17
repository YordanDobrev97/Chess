namespace ChessEngine.Engine.Figures
{
    using Chess.Figures;
    using Chess.Interfaces;
    using System.Collections.Generic;

    public class Queen : ISymbolRepresentation, IFigure, IRule
    {

        public string Representation => Constants.QueenRepresentation;
        public string Name => "Queen";
        public int Healt => Constants.HealFigure;

        public string RulePerMove { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
